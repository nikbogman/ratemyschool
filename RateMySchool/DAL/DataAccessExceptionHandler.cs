using MySql.Data.MySqlClient;
using System.Diagnostics;
using Core.Exceptions;
using Core.Enums;

namespace DAL
{
    public class DataAccessExceptionHandler
    {
        public static Exception Handle(Exception exception)
        {
            Debug.WriteLine(exception.Message);
            if (exception is MySqlException ex)
            {
                DataAccessExceptionCodeEnum error;
                if (Enum.IsDefined(typeof(DataAccessExceptionCodeEnum), ex.Number))
                {
                    error = (DataAccessExceptionCodeEnum)ex.Number;
                }
                else
                {
                    error = DataAccessExceptionCodeEnum.ER_OTHER;
                }
                string message = $"Unexpected error occured on DATABASE level with number {ex.Number}. " + ex.Message;
                return new DataAccessException(error, message, ex);
            }
            return exception;
        }
    }
}
