namespace PulseActiveShop.Core.Exceptions
{
    public class EmailAlreadyExistingException : AppException
    {
        public EmailAlreadyExistingException()
        {
        }

        public EmailAlreadyExistingException(string? message) : base(message)
        {
        }
    }
}
