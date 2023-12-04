using CSC390_WebApplication.Data;
using CSC390_WebApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Register services here
builder.Services.AddControllersWithViews(); //add services needed for controllers
builder.Services.AddSingleton<IMyInterface,MyServiceClass>(); //Registering a service
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("myDB")));

//Define configurations of users
builder.Services.AddIdentity<User,IdentityRole> //custom made user class 
    (options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.User.RequireUniqueEmail = true;
    }).AddEntityFrameworkStores<MyDbContext>();



var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<MyDbContext>();
//context.Database.EnsureDeleted(); //Should be commented out when dev is done
context.Database.EnsureCreated();

//app.MapGet("/", () => );

//Middleware pipeline
if (app.Environment.IsDevelopment()) //Error page def depending on app status
{
    //Get detailed error page
    app.UseDeveloperExceptionPage();
}
else
{
    //Get user friendly error page
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithRedirects("/Home/Error");
}

app.UseStaticFiles(); //Middleware to enable static files, usually first
app.UseAuthentication(); //Order is important
app.UseRouting(); //Add route matching to pipeline
app.UseAuthorization();
app.MapControllerRoute(
    name: "main",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller="Home", action="HomePage" });

app.MapControllerRoute(
    name: "dataviewer",
    pattern: "Show/{action}",
    defaults: new { controller="Service",action= "Index"});


app.Run(); //DO NOT delete 
