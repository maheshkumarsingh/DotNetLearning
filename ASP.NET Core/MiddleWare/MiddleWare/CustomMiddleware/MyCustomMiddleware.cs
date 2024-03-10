namespace MiddleWare.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nI am from Custom Middleware-- Starts");
            await next(context);
            //throw new NotImplementedException();
            await context.Response.WriteAsync("\nI am from Custom Middleware-- Ends");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
       
}
