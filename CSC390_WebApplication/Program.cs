using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
//Register services here
builder.Services.AddControllersWithViews(); //add services needed for controllers

var app = builder.Build();

//app.MapGet("/", () => );

//Middleware pipeline
app.UseStaticFiles(); //Middleware to enable static files, usually first
app.UseRouting(); //Add route matching to pipeline
app.MapControllerRoute(
    name: "main",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller="Home", action="Index" });

app.MapControllerRoute(
    name: "dataviewer",
    pattern: "Show/{action}",
    defaults: new { controller="Service",action= "PrintTotalServices"});




app.Run(); //DO NOT delete 
