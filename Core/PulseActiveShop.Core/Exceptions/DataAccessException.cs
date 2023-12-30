
namespace PulseActiveShop.Core.Exceptions
{
    public class DataAccessException : AppException
    {
        public DataAccessException() : base("An error occurred while accessing the data")
        {
        }

        public DataAccessException(string? message) : base(message)
        {
        }

        public DataAccessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
