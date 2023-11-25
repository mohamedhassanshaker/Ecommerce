using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Tests.OrderManagement
{

    public class Cart_Test
    {
       
        [Fact]
        public void AddItem_ItemNotInTheList_IncreaseItemLength()
        {
            //arrange
            Cart cart = new Cart(123456789);
            Product product = new Product(Guid.NewGuid(), "Product 1", 10, 100);
            //act
            cart.AddItem(product, 1);
            //assert
            Assert.Equal(1, cart.CartItems.Count);
        }
        [Fact]
        public void AddItem_ItemNotInTheList_GiveTheRightTotal()
        {
            //arrange
            Cart cart = new Cart(123456789);
            Product product = new Product(Guid.NewGuid(), "Product 1", 10, 100);
            //act
            cart.AddItem(product, 10);
            //assert
            Assert.Equal(100, cart.Total);
        }
        [Fact]
        public void AddItem_ItemInTheList_ShouldNotIncreaseItemLength()
        {
            //arrange
            Cart cart = new Cart(123456789);
            Product product = new Product(Guid.NewGuid(), "Product 1", 10, 100);
            //act
            cart.AddItem(product, 1);
            cart.AddItem(product, 1);
            //assert
            Assert.Equal(1, cart.CartItems.Count);
        }

        [Fact]
        public void AddItem_ItemInTheList_IncreaseItemQuantity()
        {
            //arrange
            Cart cart = new Cart(123456789);
            Product product = new Product(Guid.NewGuid(), "Product 1", 10, 100);
            //act
            cart.AddItem(product, 1);
            cart.AddItem(product, 1);
            //assert
            Assert.Equal(2, cart.CartItems.First().Quantity);
        }
        [Fact]
        public void IncreaseItem_ItemInTheList_IncreaseItemQuantity()
        {
            //arrange
            Cart cart = new Cart(123456789);
            Product product = new Product(Guid.NewGuid(), "Product 1", 10, 100);
            //act
            cart.AddItem(product, 1);
            cart.IncreaseItem(product, 1);
            //assert
            Assert.Equal(2, cart.CartItems.First().Quantity);
        }
        [Fact]
        public void DecreaseItem_DecreaseItemInTheList_WithQauntity1_RemoveFromTheList()
        {
            //arrange
            Cart cart = new Cart(123456789);
            Product product = new Product(Guid.NewGuid(), "Product 1", 10, 100);
            //act
            cart.AddItem(product, 1);
            cart.DecreaseItem(product, 1);
            //assert
            Assert.Equal(0, cart.CartItems.Count);
        }
        [Fact]
        public void RemoveItem_RemoveItemInTheList_RemoveFromTheList()
        {
            //arrange
            Cart cart = new Cart(123456789);
            Product product = new Product(Guid.NewGuid(), "Product 1", 10, 100);
            //act
            cart.AddItem(product, 1);
            cart.RemoveItem(product );
            //assert
            Assert.Equal(0, cart.CartItems.Count);
        }
    }
}
