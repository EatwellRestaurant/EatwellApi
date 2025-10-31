namespace EatwellApi.Application.Wrappers
{
    public abstract record Response
    {
        public bool Success { get; init; }
        public int StatusCode { get; init; }
    }
}
