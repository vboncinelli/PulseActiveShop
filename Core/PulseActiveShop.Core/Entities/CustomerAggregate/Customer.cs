using PulseActiveShop.Core.Interfaces.Core;

namespace PulseActiveShop.Core.Entities;

public class Customer : BaseEntity, IAggregateRoot
{
    public User User { get; private set; }

    private List<PaymentMethod> _paymentMethods = new();

    public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

    public Customer(User user)
    {
        User = user ?? throw new ArgumentNullException(nameof(user));
    }

    public void AddPaymentMethod(PaymentMethod paymentMethod)
    {
        this._paymentMethods.Add(paymentMethod);
    }
}
