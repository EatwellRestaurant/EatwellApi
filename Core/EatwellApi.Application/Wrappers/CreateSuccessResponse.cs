using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Wrappers
{
    public record CreateSuccessResponse : SuccessResponse
    {
        public int DataId { get; init; }

        public CreateSuccessResponse(string message) : base(message, StatusCodes.Status201Created)
        {
        }


        public CreateSuccessResponse(string message, int dataId) : this(message)
        {
            DataId = dataId;
        }
    }
}
