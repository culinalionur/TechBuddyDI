using System.Text;

namespace Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseMiddleware> _logger;

        public RequestResponseMiddleware(RequestDelegate next, ILogger<RequestResponseMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Request
            _logger.LogInformation($"Query Keys : {httpContext.Request.QueryString}");
            //Response oluşmadan önce okuma yapabilmek için
            //Orjinal stream yedeğini al
            var originalStream = httpContext.Response.Body;

            MemoryStream requestBody = new MemoryStream();
            await httpContext.Request.Body.CopyToAsync(requestBody);
            requestBody.Seek(0,SeekOrigin.Begin);

            string requestText = await new StreamReader(requestBody).ReadToEndAsync();
            requestBody.Seek(0,SeekOrigin.Begin);

            var tempStream = new MemoryStream();
            httpContext.Response.Body= tempStream;


            await _next.Invoke(httpContext); //Response oluşuyor

            
            //Response
            tempStream.Seek(0, SeekOrigin.Begin); // En başa gidip tekrar okumasını istiyoruz
            string responseText = await new StreamReader(tempStream, Encoding.UTF8).ReadToEndAsync();
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            await httpContext.Response.Body.CopyToAsync(originalStream);
        }
    }
}
