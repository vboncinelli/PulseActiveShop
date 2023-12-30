namespace PulseActiveShop.Core.Exceptions
{
    public class EntityNotFoundException : AppException
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message) : base(message)
        {
        }
    }
}
