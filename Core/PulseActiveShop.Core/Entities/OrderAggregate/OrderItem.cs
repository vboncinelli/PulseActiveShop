namespace PulseActiveShop.Core.Entities
{
    public class OrderItem : BaseEntity
    {
        public ProductOrdered ItemOrdered { get; private set; }
        
        public decimal UnitPrice { get; private set; }

        public int Units { get; private set; }

        public OrderItem(ProductOrdered itemOrdered, decimal unitPrice, int units)
        {
            ItemOrdered = itemOrdered;
            UnitPrice = unitPrice;
            Units = units;
        }
    }
}
