namespace PulseActiveShop.Core.Exceptions;

public class BasketNotFoundException : AppException
{
    public BasketNotFoundException(int basketId) : base($"No basket found with id {basketId}")
    {
    }
}
