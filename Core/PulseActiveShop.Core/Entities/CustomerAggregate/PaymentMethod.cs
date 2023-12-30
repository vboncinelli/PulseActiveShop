namespace PulseActiveShop.Core.Entities;

public class PaymentMethod : BaseEntity
{
    public string? Alias { get; private set; }

    // In a real application, you NEVER store credit card numbers or any other relevant piece of information.
    // You should use an external payment gateway with top notch security.
    // This is just for mocking a real-life scenario.
    // Don't do it at home and, above all, don't blame your teacher if your credit card gets stolen!
    public string? CardId { get; private set; } 

    public string? LastFourDigits { get; private set; }
}
