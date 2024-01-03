namespace PulseActiveShop.Core.Exceptions
{
    public class UsernameAlreadyExistingException : AppException
    {
        public UsernameAlreadyExistingException()
        {
        }

        public UsernameAlreadyExistingException(string? message) : base(message)
        {
        }
    }
}
