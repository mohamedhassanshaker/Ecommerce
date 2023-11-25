using Ecommerce.Application.Contracts.Cart;
using Ecommerce.Application.Contracts.Order;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost("Confirm")]
        public async Task<ResultDto<OrderDTO>> Confirm(CartDto request)
        {
            return await orderService.Confirm(request);
        }

        [HttpPost("ProvideAddressDto")]
        public async Task<ResultDto> ProvideDeliveryAddress(ProvideAddressDto request)
        {
            return await orderService.ProvideDeliveryAddress(request);
        }
        [HttpPost("AuthorizePayment")]
        public async Task<ResultDto> AuthorizePayment(AuthorizePaymentDto request)
        {
            return await orderService.AuthorizePayment(request);
        }

        [HttpPost("Ship")]
        public async Task<ResultDto> Ship(ShipOrderDto request)
        {
            return await orderService.Ship(request);
        }

    }
}
