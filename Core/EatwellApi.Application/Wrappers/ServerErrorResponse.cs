using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Wrappers
{
    public record ServerErrorResponse : Response
    {
        public string TypeName { get; init; }

        public string Message { get; init; }

        public string? InnerExcpetionMessage { get; init; }


        public ServerErrorResponse(Type type, string message, string? innerExceptionMessage)
        {
            TypeName = type.Name;
            Message = message;
            InnerExcpetionMessage = innerExceptionMessage;
            StatusCode = StatusCodes.Status500InternalServerError;
            Success = false;
        }

    }
}
