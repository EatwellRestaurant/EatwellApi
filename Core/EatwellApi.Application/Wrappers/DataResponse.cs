using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Wrappers
{
    public record DataResponse<T> : Response
    {
        public T Data { get; init; }
        public string? Message { get; init; }

        public DataResponse(T data, string? message = null)
        {
            Data = data;
            Message = message;
            Success = true;
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
