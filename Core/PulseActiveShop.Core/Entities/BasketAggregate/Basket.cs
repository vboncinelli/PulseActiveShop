using PulseActiveShop.Core.Interfaces.Core;

namespace PulseActiveShop.Core.Entities
{
    public class Basket : BaseEntity, IAggregateRoot
    {
        public string CustomerId { get; private set; }

        private readonly List<BasketItem> _items = new List<BasketItem>();

        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

        public int TotalItems => _items.Sum(i => i.Quantity);

        public Basket()
        {

        }

        public Basket(string customerId)
        {
            CustomerId = customerId;
        }

        public void AddItem(int productId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.ProductId == productId))
            {
                _items.Add(new BasketItem(productId, quantity, unitPrice));
                return;
            }

            var existingItem = Items.First(i => i.ProductId == productId);

            existingItem.AddQuantity(quantity);
        }

        public void RemoveEmptyItems() => this._items.RemoveAll(i => i.Quantity == 0);

        public void RemoveLine(Product product) => this._items.RemoveAll(item => item.ProductId == product.Id);

        public decimal ComputeTotalValue() => this._items.Sum(e => e.UnitPrice * e.Quantity);

        public void Clear() => this._items.Clear();
    }

    public class BasketCollection : BaseEntityCollection<Basket>
    {

    }
}
