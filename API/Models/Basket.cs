using System.Collections.Generic;
using System.Linq;
using API.Models;

namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new();

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(x => x.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                return;
            }

            Items.Add(new BasketItem { Product = product, Quantity = quantity });
        }

        public void RemoveItem(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(x => x.ProductId == productId);

            if (item == null) return;

            item.Quantity -= quantity;

            if (item.Quantity <= 0)
                Items.Remove(item);
        }
    }
}