namespace EatwellApi.Application.Wrappers
{
    public record ErrorResponse : Response
    {
        public string Message { get; init; }

        public List<int>? Data { get; set; }


        public ErrorResponse(string message, int statusCode, List<int>? data = null)
        {
            Message = message;
            Success = false;
            StatusCode = statusCode;
            Data = data;
        }


    }
}
