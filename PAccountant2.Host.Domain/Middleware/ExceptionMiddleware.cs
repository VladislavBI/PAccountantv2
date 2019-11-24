using Microsoft.AspNetCore.Http;
using PAccountant2.Host.Domain.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PAccountant2.Host.Domain.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _log;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> log)
        {
            _next = next;
            _log = log;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _log.LogError($"{exception.Message} \n {exception.StackTrace}");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetailsViewModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
