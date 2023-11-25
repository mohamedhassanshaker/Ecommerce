using Ecommerce.Domian.CartAggregate.Entities;
using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domian.OrderAggregate.Exceptions;
using Ecommerce.Domian.OrderAggregate.Enums;
using Ecommerce.Domian.OrderAggregate.ValueObjects;

namespace Ecommerce.Domain.Tests.OrderManagement
{

    public class Order_Test
    {
        [Fact]
        public void Ship_NonPaidOrder_Reject()
        {
            
            //arrange
            Cart cart = new Cart(123456789);
            Product product = new Product(Guid.NewGuid(), "Product 1", 10, 100);
            cart.AddItem(product, 1);
            Order order = new Order("0001",cart);
            Address address = new Address("Sharjah", "","","");
            //act & assert
            Assert.Throws<ShipNonPaidOrderException>(()=> order.Ship());
        }
        [Fact]
        public void Ship_PaidOrder_Accept()
        {

            //arrange
            Cart cart = new Cart(123456789);
            Product product = new Product(Guid.NewGuid(), "Product 1", 10, 100);
            cart.AddItem(product, 1);
            Order order = new Order("0001", cart);
            //act
            order.Confirm();
            order.AuthorizePayment(new PaymentData(order,10,"123",DateTime.Now,"123"));
            //assert
            Assert.Equal(OrderStatus.PaymentAccepted,order.status);
        }
        [Fact]
        public void Address_SameDetails_Equale()
        {

            //arrange
            Address address1 = new Address("Sharjah", "Wahda Street", "Plaza1", "102");
            Address address2 = new Address("Sharjah", "Wahda Street", "Plaza1", "102");
            //act
            
            //assert
            Assert.Equal(address1,address2);
        }
        [Fact]
        public void Address_InvalidCity_ThroughException() {
 
            Assert.Throws<InvalidCityException>(() => new Address("Ras Elkhima", "Wahda Street", "Plaza1", "102"));
        }
        [Fact]
        public void Address_ValidCity_Accepted()
        {
            Address address1 = new Address("Sharjah", "Wahda Street", "Plaza1", "102");
             
            //assert
            Assert.Equal(address1, new Address("Sharjah", "Wahda Street", "Plaza1", "102"));
        }

    }
}
