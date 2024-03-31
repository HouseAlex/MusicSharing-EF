using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CustomPolicyHandlerExample
{
    public class CustomPolicyHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomPolicyHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestBody;
            using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
            {
                requestBody = await reader.ReadToEndAsync();
                // Reset the position of the request body stream so that it can be read again later
                //context.Request.Body.Position = 0;
            }

            // Log or inspect the request body as needed
            Console.WriteLine("Request Body: " + requestBody);

            // Call the next middleware if the condition is met
            await _next(context);
        }
    }
}