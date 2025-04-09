namespace Core.Bases
{
    public abstract class BadRequestBaseException : Exception
    {
        protected BadRequestBaseException(string message) : base(message) { }
    }
}
