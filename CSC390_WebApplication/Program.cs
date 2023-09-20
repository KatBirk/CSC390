var builder = WebApplication.CreateBuilder(args);
//Register services here

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseDefaultFiles(); //Middleware to use default files - must be called before UseStaticFiles
app.UseStaticFiles(); //Middleware to enable static files

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello1");
    next.Invoke();
    await context.Response.WriteAsync("Hello2");
});
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello3");
});

app.Run();
