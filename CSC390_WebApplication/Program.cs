using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
//Register services here
builder.Services.AddControllersWithViews(); //add services needed for controllers

var app = builder.Build();

//app.MapGet("/", () => );

//Middleware pipeline
app.UseStaticFiles(); //Middleware to enable static files, usually first
app.UseRouting(); //Add route matching to pipeline
//app.MapDefaultControllerRoute(); //adds simple default routing
app.MapControllerRoute(
    name: "default",
    pattern: "{id}",
    defaults: new { controller = "Student", action = "Show" });

app.MapControllerRoute( //Specified routing
    name: "default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}" //Determines the pattern for the URL path
);




app.Run(); //DO NOT delete 
