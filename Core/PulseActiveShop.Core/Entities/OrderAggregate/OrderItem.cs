namespace PulseActiveShop.Core.Entities
{
    public class OrderItem : BaseEntity
    {
        public ProductOrdered ItemOrdered { get; private set; } = null!;

        public decimal UnitPrice { get; private set; }

        public int Units { get; private set; }

        public OrderItem()
        {

        }

        public OrderItem(ProductOrdered itemOrdered, decimal unitPrice, int units)
        {
            ItemOrdered = itemOrdered;
            UnitPrice = unitPrice;
            Units = units;
        }

        public void UpdateUnits(int delta)
        {
            if (this.Units + delta < 1)
                throw new InvalidOperationException("The number of remaining units cannot be negative");

            this.Units += delta;
        }
    }

    public class OrderItemCollection : BaseEntityCollection<OrderItem>
    {

    }
}
