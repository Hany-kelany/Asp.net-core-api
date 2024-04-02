namespace Api.Middlware
{
    public class RateLimitMiddlware
    {
        private readonly int counter = 0;

        private readonly RequestDelegate next;

        public RateLimitMiddlware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext context)
        {

            await next.Invoke(context);
        }
    }
}
