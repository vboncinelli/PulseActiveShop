using PulseActiveShop.Core.Interfaces.Core;

namespace PulseActiveShop.Core.Entities;

public class Customer(User user) : BaseEntity, IAggregateRoot
{
    // TODO: What C# 12 feature are we using here?
    private readonly User _user = user ?? throw new ArgumentNullException(nameof(user));

    private List<PaymentMethod> _paymentMethods = new();

    public string? Username => _user.Username;

    public string? Email => _user.Email;

    public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

    public void AddPaymentMethod(PaymentMethod paymentMethod)
    {
        this._paymentMethods.Add(paymentMethod);
    }
}
