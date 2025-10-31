using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Wrappers
{
    public record UpdateSuccessResponse : SuccessResponse
    {
        public UpdateSuccessResponse(string message) : base(message, StatusCodes.Status204NoContent)
        {
        }
    }
}
