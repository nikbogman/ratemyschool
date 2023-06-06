namespace Core.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException() { }

        public InternalServerException(Exception innerException) : base("Unexpected Internal Server Error", innerException) { }
        public InternalServerException(string message) : base(message) { }
        public InternalServerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
