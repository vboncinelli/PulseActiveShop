namespace PulseActiveShop.Core.Exceptions
{
    public class InvalidParameterException : AppException
    {
        public InvalidParameterException()
        {
        }

        public InvalidParameterException(string? message) : base(message)
        {
        }
    }
}
