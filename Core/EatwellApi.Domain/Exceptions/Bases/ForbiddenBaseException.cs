namespace EatwellApi.Domain.Exceptions.Bases
{
    public abstract class ForbiddenBaseException : Exception
    {
        protected ForbiddenBaseException(string message) : base(message) { }
    }
}
