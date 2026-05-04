namespace COMP003B.SP26.FinalProject.VillagranR.Middleware
{
    public class RequestTimingMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"[Request] {context.Request.Method} {context.Request.Path}");
            await _next(context);
            Console.WriteLine($"[Request] {context.Response.StatusCode}");
        }

    }
}
