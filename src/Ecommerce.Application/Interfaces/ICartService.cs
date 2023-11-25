using Ecommerce.Application.Contracts.Cart;
using Ecommerce.Application.Dto;

namespace Ecommerce.Application.Interfaces
{
    public interface ICartService
    {
        Task<ResultDto<CartDto>> AddItem(AddCartItemDto request);
        Task<ResultDto<CartDto>> DecreaseItemQauntity(DecreaseCartItemDto request);
        Task<ResultDto<CartDto>> IncreaseItemQauntity(IncreaseCartItemDto request);
        Task<ResultDto<CartDto>> RemoveItem(RemoveCartItemDto request);
    }
}