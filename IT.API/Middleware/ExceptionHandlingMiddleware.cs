using IT.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Net;

namespace IT.API.Middleware {
    public class ExceptionHandlingMiddleware {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            try {
                await _next(context);
            } catch(Exception ex) {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex) {
            // default properties
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            // handle custom exceptions
            switch(ex) {
                case ValidationException validationException: {
                    code = HttpStatusCode.BadRequest;
                    result = System.Text.Json.JsonSerializer.Serialize(validationException.Failures);
                    break;
                }
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code.GetHashCode();

            if(result == string.Empty) {
                result = System.Text.Json.JsonSerializer.Serialize(new {
                    error = ex.Message
                });
            }

            return context.Response.WriteAsync(result);
        }
    }

    public static class ExceptionHandlingExtension {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder) {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}