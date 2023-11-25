using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Contracts.Cart;
using Ecommerce.Application.Contracts.Order;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Interfaces;
using Ecommerce.Domian.Common.Interfaces;
using Ecommerce.Domian.OrderAggregate;
using Ecommerce.Domian.OrderAggregate.Exceptions;
using Ecommerce.Domian.OrderAggregate.Interfaces;
using Ecommerce.Domian.OrderAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class OrderService : BaseApplicationService, IOrderService
    {
        private readonly ICartRepository cartRepository;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(ICartRepository cartRepository, IProductRepository productRepository,IOrderRepository orderRepository, IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<ResultDto > AuthorizePayment(AuthorizePaymentDto request)
        {
            ResultDto result = new ResultDto();
            var existingOrder = await orderRepository.FindByID(request.OrderID);

            if (existingOrder == null)
            {
                result.Code = (short)ErrorCodes.Invalid_Order_Details;
                result.Message = ErrorCodes.Invalid_Order_Details.ToString();
            }
            try
            {
                PaymentData paymentData = new PaymentData(existingOrder, request.RecievedAmount, request.InvoiceNumber, request.PaymentDate, request.PaymentRefernce);
                existingOrder.AuthorizePayment(paymentData);
                var UpdateResult = await orderRepository.Update(existingOrder);
                if (!UpdateResult)
                {
                    result.Code = (short)ErrorCodes.Cannot_Store_Data_To_DataStore;
                    result.Message = ErrorCodes.Cannot_Store_Data_To_DataStore.ToString();
                    return result;
                }
                result.Code = (short)ErrorCodes.Success;
            }
            catch(Exception ex)
            {
                existingOrder.RejectPayment();
                result.Code = (short)ErrorCodes.Invalid_Payment_Details;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ResultDto<OrderDTO>> Confirm(CartDto request)
        {
            ResultDto<OrderDTO>  result = new ResultDto<OrderDTO>();
            var existingCart = await cartRepository.FindByID(request.ID);

            if (existingCart == null)
            {
                    result.Code = (short)ErrorCodes.Cannot_Confirm_Order_With_Not_Existing_Cart;
                    result.Message = ErrorCodes.Cannot_Confirm_Order_With_Not_Existing_Cart.ToString();
                    return result;
            }
            else
            {
                Order order = new Order( new Random().Next(1000000, 2000000).ToString(), existingCart);
                try
                {
                    order.Confirm();
                    result.Code = (short)ErrorCodes.Success;
                }
                
                catch (Exception ex)
                {
                    result.Code = (short)ErrorCodes.Cannot_Confirm_Order;
                    result.Message = ex.Message;
                    return result;
                }
                var InsertResult = await orderRepository.Insert(order);
                if (!InsertResult)
                {
                    result.Code = (short)ErrorCodes.Cannot_Store_Data_To_DataStore;
                    result.Message = ErrorCodes.Cannot_Store_Data_To_DataStore.ToString();
                    return result;
                }
                result.Result = new OrderDTO();
                mapper.Map(order, result.Result);
            }
            return result;
        }

        public async Task<ResultDto > ProvideDeliveryAddress(ProvideAddressDto request)
        {
            ResultDto result = new ResultDto();
            var existingOrder = await orderRepository.FindByID(request.OrderID);

            if (existingOrder == null)
            {
                result.Code = (short)ErrorCodes.Invalid_Order_Details;
                result.Message = ErrorCodes.Invalid_Order_Details.ToString();
            }
            try
            {
                Address address = new Address(request.City,request.Street,request.Building,request.FlatNo);
                existingOrder.ProvideDeliveryAddress(address);
                var UpdateResult = await orderRepository.Update(existingOrder);
                if (!UpdateResult)
                {
                    result.Code = (short)ErrorCodes.Cannot_Store_Data_To_DataStore;
                    result.Message = ErrorCodes.Cannot_Store_Data_To_DataStore.ToString();
                    return result;
                }
                result.Code = (short)ErrorCodes.Success;
            }
            catch (Exception ex)
            {
                result.Code = (short)ErrorCodes.Invalid_Shipping_Details;
                result.Message = ex.Message;
            }
            return result;
        }

        
        public async Task<ResultDto> Ship(ShipOrderDto request)
        {
            ResultDto result = new ResultDto();
            var existingOrder = await orderRepository.FindByID(request.OrderID);

            if (existingOrder == null)
            {
                result.Code = (short)ErrorCodes.Invalid_Order_Details;
                result.Message = ErrorCodes.Invalid_Order_Details.ToString();
            }
            try
            {
                existingOrder.Ship();
                var UpdateResult = await orderRepository.Update(existingOrder);
                if (!UpdateResult)
                {
                    result.Code = (short)ErrorCodes.Cannot_Store_Data_To_DataStore;
                    result.Message = ErrorCodes.Cannot_Store_Data_To_DataStore.ToString();
                    return result;
                }
                result.Code = (short)ErrorCodes.Success;
            }
            catch (Exception ex)
            {
                result.Code = (short)ErrorCodes.Invalid_Payment_Details;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
