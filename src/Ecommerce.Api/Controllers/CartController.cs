using Ecommerce.Api.Filters;
using Ecommerce.Application.Contracts.Cart;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ecommerce.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(LogFilters))]
    public class CartController:ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost("AddItem")]
        public async Task<ResultDto<CartDto>> AddItem(AddCartItemDto request)
        {
            return await cartService.AddItem(request);
        }
        [HttpPost("IncreaseItem")]
        public async Task<ResultDto<CartDto>> IncreaseItem(IncreaseCartItemDto request)
        {
            return await cartService.IncreaseItemQauntity(request);
        }
        [HttpPost("DecreaseItem")]
        public async Task<ResultDto<CartDto>> DecreaseItem(DecreaseCartItemDto request)
        {
            return await cartService.DecreaseItemQauntity(request);
        }
        [HttpPost("RemoveItem")]
        public async Task<ResultDto<CartDto>> DecreaseItem(RemoveCartItemDto request)
        {
            return await cartService.RemoveItem(request);
        }
    }
}
