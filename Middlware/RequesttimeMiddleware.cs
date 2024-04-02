using System.Diagnostics;

namespace Api.Middlware
{
    public class RequesttimeMiddleware
    {

        private readonly RequestDelegate next;

        public RequesttimeMiddleware(RequestDelegate next, ILogger<RequesttimeMiddleware> logger)
        {
            this.next = next;
            Logger = logger;
        }

        public ILogger<RequesttimeMiddleware> Logger { get; }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();  
            await next(context);
            stopwatch.Stop();
            Logger.LogInformation($" requst {context.Request.Path} and take {stopwatch.ElapsedMilliseconds} ms ...");
        }

    }
}
