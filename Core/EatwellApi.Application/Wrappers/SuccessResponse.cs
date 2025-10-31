namespace EatwellApi.Application.Wrappers
{
    /// <summary>
    /// Write işlemleri için. (Ekleme, güncelleme, silme)
    /// </summary>
    public record SuccessResponse : Response
    {
        public string Message { get; init; }

        public SuccessResponse(string message, int statusCode)
        {
            Message = message;
            Success = true;
            StatusCode = statusCode;
        }
    }
}
