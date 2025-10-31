using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Wrappers
{
    public record DeleteSuccessResponse : SuccessResponse
    {
        public DeleteSuccessResponse(string message) : base(message, StatusCodes.Status204NoContent)
        {
        }
    }
}
