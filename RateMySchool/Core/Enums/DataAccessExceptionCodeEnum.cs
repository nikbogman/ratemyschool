namespace Core.Enums
{
    public enum DataAccessExceptionCodeEnum
    {
        // Invalid hostname
        ER_BAD_HOST_ERROR = 1042,
        // Invalid username/password
        ER_ACCESS_DENIED_ERROR = 1045,
        // Unknown database
        ER_BAD_DB_ERROR = 1049,
        // Syntax error
        ER_SYNTAX_ERROR = 1149,
        // Duplicate unique keys
        ER_DUP_UNIQUE = 1169,
        // Bad connection
        ER_OFFLINE = 0,
        // Other
        ER_OTHER = 1
    }
}
