using System.Diagnostics;
using Core.Enums;

namespace Core.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessExceptionCodeEnum Code { get; private set; }
        public DataAccessException() { }

        public DataAccessException(DataAccessExceptionCodeEnum code, string message) : base(message) { Code = code; }
        public DataAccessException(DataAccessExceptionCodeEnum code, string message, Exception innerException) : base(message, innerException) { Code = code; }
    }
}
