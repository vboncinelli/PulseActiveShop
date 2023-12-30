namespace PulseActiveShop.Core.Exceptions;

public class EmptyBasketOnCheckoutException : AppException
{
    public EmptyBasketOnCheckoutException() : base($"Basket cannot have 0 items on checkout")
    {
    }

    public EmptyBasketOnCheckoutException(string message) : base(message)
    {
    }

    public EmptyBasketOnCheckoutException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
