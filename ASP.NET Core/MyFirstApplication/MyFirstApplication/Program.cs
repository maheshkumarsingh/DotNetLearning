var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    //context.Response.StatusCode = 400;
    context.Response.Headers["MyKey"] = "my value";
    context.Response.Headers["Server"] = "Mahesh ka Sever";
    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h1>Hello Mahesh</h1>");
    await context.Response.WriteAsync("<h2> Kumar Singh</h2>");
});

app.Run();
