using Ecommerce.Application.Contracts.Cart;
using Ecommerce.Application.Contracts.Order;
using Ecommerce.Application.Dto;

namespace Ecommerce.Application.Interfaces
{
    public interface IOrderService
    {
        Task<ResultDto<OrderDTO>> Confirm(CartDto request);
        Task<ResultDto > AuthorizePayment(AuthorizePaymentDto request);
        Task<ResultDto > Ship(ShipOrderDto request);
        Task<ResultDto > ProvideDeliveryAddress(ProvideAddressDto address);
    }
}