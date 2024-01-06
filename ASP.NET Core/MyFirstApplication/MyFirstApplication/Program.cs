var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    //context.Response.StatusCode = 400;
    context.Response.Headers["MyKey"] = "my value";
    context.Response.Headers["Server"] = "Mahesh ka Sever";

    string path = context.Request.Path;
    //string method = context.Request.Method;


    //http://localhost:5279/?id=1&name=Mahesh
    if (context.Request.Method == HttpMethod.Get.ToString())
    {
        if(context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p>{id}</p>");
        }
    } 
    if(context.Request.Method == HttpMethod.Get.ToString())
    {
        if(context.Request.Query.ContainsKey("name"))
        {
            string name = context.Request.Query["name"];
            await context.Response.WriteAsync($"<p>{name}</p>");
        }
    }
    
    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h1>Hello Mahesh</h1>");
    await context.Response.WriteAsync("<h2> Kumar Singh</h2>");
});

app.Run();
