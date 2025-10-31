namespace EatwellApi.Domain.Exceptions.Bases
{
    public abstract class NotFoundBaseException : Exception
    {
        protected NotFoundBaseException(string message) : base(message) { }
    }
}
