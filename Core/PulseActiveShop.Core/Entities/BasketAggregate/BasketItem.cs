using PulseActiveShop.Core.Constants;
using System;

namespace PulseActiveShop.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public decimal UnitPrice { get; private set; }

        public int Quantity { get; private set; }

        public int ProductId { get; private set; }

        public int BasketId { get; private set; }

        public BasketItem(int productId, int quantity, decimal unitPrice)
        {
            ProductId = productId;

            UnitPrice = unitPrice;

            this.SetQuantity(quantity);
        }

        public void AddQuantity(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative");

            if (this.Quantity + quantity > ShopConstants.MAX_QUANTITY)
                throw new ArgumentException($"Quantity cannot be greater than {ShopConstants.MAX_QUANTITY} items");

            // TODO: What does it mean?
            checked
            {
                this.Quantity += quantity;
            }
        }

        public void SetQuantity(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative");

            if (quantity > ShopConstants.MAX_QUANTITY)
                throw new ArgumentException($"Quantity cannot be greater than {ShopConstants.MAX_QUANTITY} items");

            this.Quantity = quantity;
        }
    }
}
