var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    //context.Response.StatusCode = 400;
    context.Response.Headers["MyKey"] = "my value";
    await context.Response.WriteAsync("Hello Mahesh");
    await context.Response.WriteAsync("Kumar Singh");
});

app.Run();
