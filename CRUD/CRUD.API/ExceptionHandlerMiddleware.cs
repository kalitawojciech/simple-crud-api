using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using CRUD.Services.Exceptions;

namespace CRUD.API
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.BadRequest;
            var response = new Object();
            var exceptionType = exception.GetType();
            switch (exception)
            {
                case Exception e when exceptionType == typeof(BadRequestException):
                    statusCode = HttpStatusCode.BadRequest;
                    break;

                case Exception e when exceptionType == typeof(NotFoundException):
                    statusCode = HttpStatusCode.NotFound;
                    break;

                //TODO: Custom exception

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            response = new { message = exception.Message };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(payload);
        }
    }
}
