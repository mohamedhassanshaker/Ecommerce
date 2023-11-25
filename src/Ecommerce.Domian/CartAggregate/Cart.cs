
using Ecommerce.Domian.CartAggregate.Entities;
using Ecommerce.Domian.CartAggregate.Events;
using Ecommerce.Domian.CartAggregate.Exceptions;
using Ecommerce.Domian.Common;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Domian.CartAggregate
{
    public class Cart : BaseAuditableAggregate
    {

        //public Guid ID { get; private set; }
        public long RefernceNumber { get; private set; }
        public decimal Total { get => _cartItems.Sum(en => en.Net); }


        private readonly List<CartItem> _cartItems = new List<CartItem>();
        public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly<CartItem>();
        
        [JsonConstructor]
        private Cart(Guid ID, long RefernceNumber,  IReadOnlyCollection<CartItem>?   CartItems)
        {
            this.ID = ID;
            this.RefernceNumber = RefernceNumber;

            this._cartItems = CartItems != null ? CartItems.ToList() : new List<CartItem>();


        }
  
        public Cart(Guid ID,long RefernceNumber)
        {
            this.ID = ID;
            this.RefernceNumber = RefernceNumber;
        }

        public void AddItem(Product product, int quantity = 1)
        {
            CartItem existingItem = _cartItems.FirstOrDefault(i => i.ProductID == product.ID);
            if (existingItem == null)
            {
                _cartItems.Add(new CartItem(product, quantity, product.Price));
                AddDomainEvent(new CartUpdatedEvent(this));
            }
            else
            {
                existingItem.IncrementQuantity(quantity);
                AddDomainEvent(new CartUpdatedEvent(this));
            }
        }
        public void IncreaseItem(Product product, int quantity = 1)
        {
            CartItem existingItem = _cartItems.FirstOrDefault(i => i.ProductID == product.ID);
            if (existingItem == null)
            {

                throw new ItemNotExistException("Item not exist");
            }

            existingItem.IncrementQuantity(quantity);
            AddDomainEvent(new CartUpdatedEvent(this));


        }
        public void DecreaseItem(Product product, int quantity = 1)
        {
            CartItem existingItem = _cartItems.FirstOrDefault(i => i.ProductID == product.ID);
            if (existingItem == null)
            {

                throw new ItemNotExistException("Item not exist");
            }
            existingItem.DecreaseQuantity(quantity);
            if (existingItem.Quantity == 0)
                RemoveItem(product);
            else
                AddDomainEvent(new CartUpdatedEvent(this));
        }
        public void RemoveItem(Product product)
        {
            CartItem existingItem = _cartItems.FirstOrDefault(i => i.ProductID == product.ID);
            if (existingItem == null)
            {
                throw new ItemNotExistException("Item not exist");
            }
            existingItem.MarkAsDeleted();
            _cartItems.Remove(existingItem);
            AddDomainEvent(new CartUpdatedEvent(this));
        }
        public void Clear()
        {
            _cartItems.Clear();
            AddDomainEvent(new CartUpdatedEvent(this));
        }
    }
}
