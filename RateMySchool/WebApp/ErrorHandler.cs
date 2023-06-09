using Core.Exceptions;

namespace WebApp
{
    public static class ErrorHandler
    {
        public static string GetPath(Exception ex)
        {
            if (ex is DataAccessException) return "InternalServerError";
            else if (ex is NotFoundException) return "NotFoundError";
            else if (ex is UnauthorizedException) return "UnauthorizedError";
            else if (ex is InputValidationException) return string.Empty;
            return "BadRequestError";
        }
    }
}
