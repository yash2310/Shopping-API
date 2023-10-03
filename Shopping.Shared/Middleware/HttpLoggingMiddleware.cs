using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Shopping.Shared.Middleware
{
    public class HttpLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<HttpLoggingMiddleware> logger;

        public HttpLoggingMiddleware(RequestDelegate next, ILogger<HttpLoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            //var originalBodyStream = context.Response.Body;

            //var request = await GetRequestAsTextAsync(context.Request);
            //logger.LogInformation(request);

            //await using var responseBody = new MemoryStream();
            //context.Response.Body = responseBody;

            await next(context);

            //var response = await GetResponseAsTextAsync(context.Response);
            //logger.LogInformation(response);

            //await responseBody.CopyToAsync(originalBodyStream);
        }

        private async Task<string> GetRequestAsTextAsync(HttpRequest request)
        {
            var body = request.Body;

            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body = body;

            return $"Scheme - {request.Scheme}; Host - {request.Host}; Path - {request.Path}; Query String - {request.QueryString}; Body - {bodyAsText}";
        }

        private async Task<string> GetResponseAsTextAsync(HttpResponse response)
        {
            //response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            //response.Body.Seek(0, SeekOrigin.Begin);
            //var text = await new StreamReader("")
            return $"Status - {response.StatusCode}; Body - {text}";
        }
    }
}
