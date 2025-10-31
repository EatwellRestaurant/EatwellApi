namespace EatwellApi.Domain.Exceptions.Bases
{
    public abstract class BadRequestBaseException : Exception
    {
        protected BadRequestBaseException(string message) : base(message) { }
    }
}
