using Core.Bases;
using Core.Exceptions.General;
using Core.Exceptions.User;
using Core.ResponseModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Security;
using System.Text.Json;

namespace Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }



        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int statusCode = GetResponseStatusCode(ex);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;


            string? response = null;

            if (statusCode == StatusCodes.Status500InternalServerError)
                response = JsonSerializer.Serialize(new ServerErrorResponse(ex.GetType(), ex.Message, ex.InnerException?.InnerException?.Message));
            
            else
                response = JsonSerializer.Serialize(GetExceptionModel(ex, statusCode));


            // errorResponse nesnesini JSON formatına dönüştürüp, HTTP yanıtını o şekilde gönderiyoruz.
            return context.Response.WriteAsync(response);
        }


        private static ErrorResponse GetExceptionModel(Exception ex, int statusCode)
        {
            if (statusCode == StatusCodes.Status404NotFound && ex is EntitiesNotFoundException notFoundException)
                return new ErrorResponse(
                   statusCode: statusCode,
                   message: notFoundException.Message,
                   data: notFoundException.Ids);
            

            return new ErrorResponse(GetErrors(ex), statusCode);
        }


        private static int GetResponseStatusCode(Exception ex) =>
             ex switch
             {
                 ValidationException => StatusCodes.Status422UnprocessableEntity,
                 ForbiddenException or SecurityException => StatusCodes.Status401Unauthorized,
                 NotFoundBaseException => StatusCodes.Status404NotFound,
                 BadRequestBaseException => StatusCodes.Status400BadRequest,
                 //Exceptions.ValidationException => StatusCodes.Status422UnprocessableEntity,
                 //DBBaseException => StatusCodes.Status409Conflict,
                 _ => StatusCodes.Status500InternalServerError
             };



        private static string GetErrors(Exception ex) =>
            ex switch
            {
                ValidationException => ((ValidationException)ex).Errors.First().ErrorMessage,
                _ => ex.Message
            };

    }
}
