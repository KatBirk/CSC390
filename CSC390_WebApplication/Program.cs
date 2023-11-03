using CSC390_WebApplication.Data;
using CSC390_WebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Register services here
builder.Services.AddControllersWithViews(); //add services needed for controllers
builder.Services.AddSingleton<IMyInterface,MyServiceClass>(); //Registering a service
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("myDB")));

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<MyDbContext>();
//context.Database.EnsureDeleted(); //Should be commented out when dev is done
context.Database.EnsureCreated();

//app.MapGet("/", () => );

//Middleware pipeline
app.UseStaticFiles(); //Middleware to enable static files, usually first
app.UseRouting(); //Add route matching to pipeline
app.MapControllerRoute(
    name: "main",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller="Booking", action="Index" });

app.MapControllerRoute(
    name: "dataviewer",
    pattern: "Show/{action}",
    defaults: new { controller="Service",action= "PrintTotalServices"});




app.Run(); //DO NOT delete 
