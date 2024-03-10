using MiddleWare.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

//add cutom middleware class service
builder.Services.AddTransient<MyCustomMiddleware>();


var app = builder.Build();

//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("I am Mahesh Singh!!!");
//});
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("\nI am Mahesh AGAIN");
//});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\nMiddleware 1");
    await next(context);
});


//use when middleware

app.UseWhen(
    context => context.Request.Query.ContainsKey("userName"),
    app =>
    {
        app.Use(async (context,next) =>
        {
            await context.Response.WriteAsync("I am Mahesh using UseWhen");
            await next(context);
        });
    });
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\nMiddleware 1");
    await next(context);
});
//Custom Middleware class call
//app.UseMiddleware<MyCustomMiddleware>();
//made an extensible method to class custom middleware
app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\nMiddleware 2");
    await next(context);
});

//terminating MW
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("\nI am Mahesh Singh!!!");
});

//custom middleware class


app.Run();
