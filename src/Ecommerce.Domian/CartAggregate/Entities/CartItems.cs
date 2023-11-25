using Ecommerce.Domian.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Domian.CartAggregate.Entities
{
    public class CartItem : BaseAuditableEntity
    {
        public Guid ProductID { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal Net { get => Price * Quantity; }

        public bool IsNew { get; private set; } = true;
      
        public bool IsDeleted { get; private set; }

        private CartItem()
        {
            IsNew=false;
        }
        [JsonConstructor]
        public CartItem(Product Product, int Quantity, decimal Price)
        {
            ID = Guid.NewGuid();
            this.Product = Product;
            ProductID = Product.ID;
            this.Price = Price;
            this.Quantity = Quantity;
           
            
        }
        public void updateQuantity(int Quantity)
        {
            this.Quantity = Quantity;
            

        }
        public void DecreaseQuantity(int quantity = 1)
        {
            Quantity -= quantity;
            

        }
        public void IncrementQuantity(int quantity = 1)
        {
            Quantity += quantity;
            

        }

        public void ChangePrice(decimal _Price)
        {
            Price = _Price;
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
