using PulseActiveShop.Core.Interfaces;

namespace PulseActiveShop.Core.Entities;

public class Customer : BaseEntity, IAggregateRoot
{
    public string IdentityGuid { get; private set; }

    private List<PaymentMethod> _paymentMethods = new();

    public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

    public Customer(string identity)
    {
        // TODO: Check for null or empty string before assigning the value

        IdentityGuid = identity;
    }
}
