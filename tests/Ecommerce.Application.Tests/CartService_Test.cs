using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Contracts.Cart;
using Ecommerce.Application.Services;
using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Entities;
using Ecommerce.Domian.CartAggregate.Interfaces;
using Ecommerce.Domian.Common.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Tests
{
    public class CartService_Test
    {
        Mock<ICartRepository> cartRepository=new Mock<ICartRepository>();
        Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
        Mock<IMapper> mapper = new Mock<IMapper>();
        Mock<ICacheProvider> cash = new Mock<ICacheProvider>();
        public CartService_Test() { }

        [Fact]
        public void AddItem_WrongProductID_ReturnCannotGetProductFromItemCataloge()
        {
            //arrange
            Guid cartID = Guid.NewGuid();
            Guid productID = Guid.NewGuid();
            
            AddCartItemDto request = new AddCartItemDto { ID = cartID, ProductID= productID, Qty=1 };
            CartService cartService = new CartService(cartRepository.Object, productRepository.Object, mapper.Object, cash.Object);
            cartRepository.Setup(s => s.FindByID(cartID)).ReturnsAsync(()=>null);
            productRepository.Setup(s => s.FindByID(productID)).ReturnsAsync(()=>null);
            //act
            var result=cartService.AddItem(request);
            //assert
            Assert.NotNull(result);
            Assert.Equal(result.Result.Message,ErrorCodes.Cannot_Get_Product_From_ItemCataloge.ToString());
        }

        [Fact]
        public void AddItem_QtyGreaterThanBalance_ReturnBalanceSHouldBeLessThanTheRequiredQty()
        {
            //arrange
            Guid cartID = Guid.NewGuid();
            Guid productID = Guid.NewGuid();
            
            CartService cartService = new CartService(cartRepository.Object, productRepository.Object, mapper.Object, cash.Object);
            cartRepository.Setup(s => s.FindByID(cartID)).ReturnsAsync(() => null);
            productRepository.Setup(s => s.FindByID(productID)).ReturnsAsync(new Product (productID,"Test",100,50));

            AddCartItemDto request = new AddCartItemDto { ID = cartID, ProductID = productID, Qty = 100 };
            //act

            var result = cartService.AddItem(request);
            //assert

            Assert.NotNull(result);
            Assert.Equal(result.Result.Message,  ErrorCodes.Product_Balance_Is_Less_Than_The_Required_Qty.ToString());
        }




    }
}
