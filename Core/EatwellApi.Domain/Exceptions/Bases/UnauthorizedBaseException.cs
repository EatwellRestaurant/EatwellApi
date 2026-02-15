namespace EatwellApi.Domain.Exceptions.Bases
{
    public abstract class UnauthorizedBaseException : Exception
    {
        protected UnauthorizedBaseException(string message) : base(message) { }
    }
}
