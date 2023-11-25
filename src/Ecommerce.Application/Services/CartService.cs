using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Contracts.Cart;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Entities;
using Ecommerce.Domian.CartAggregate.Interfaces;
using Ecommerce.Domian.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class CartService : BaseApplicationService, ICartService
    {
        private readonly ICartRepository cartRepository;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly ICacheProvider cacheProvider;
        

        public CartService(ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper,ICacheProvider cacheProvider )
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.cacheProvider = cacheProvider;
           
        }

        public async Task<ResultDto<CartDto>> AddItem(AddCartItemDto request)
        {
            ResultDto<CartDto> result = new ResultDto<CartDto>();
            var existingCart = await cartRepository.FindByID(request.ID);

            if (existingCart == null)
            {
                Cart cart = new Cart(request.ID,new Random().Next(1000000, 2000000));
                Product product =this.cacheProvider.GetFromCache<Product>(request.ProductID.ToString()).Result;
                if (product == null)
                {
                    product = await productRepository.FindByID(request.ProductID);
                    this.cacheProvider.SetCache(request.ProductID.ToString(), product);
                }
                if (product == null)
                {
                    result.Code = (short)ErrorCodes.Cannot_Get_Product_From_ItemCataloge;
                    result.Message = ErrorCodes.Cannot_Get_Product_From_ItemCataloge.ToString();
                    return result;
                }
                if (product.Balance < request.Qty)
                {
                    result.Code = (short)ErrorCodes.Product_Balance_Is_Less_Than_The_Required_Qty;
                    result.Message = ErrorCodes.Product_Balance_Is_Less_Than_The_Required_Qty.ToString();
                    return result;
                }
                cart.AddItem(product, request.Qty);
               
                var InsertResult = await cartRepository.Insert(cart);
                if (!InsertResult)
                {
                    result.Code = (short)ErrorCodes.Cannot_Store_Data_To_DataStore;
                    result.Message = ErrorCodes.Cannot_Store_Data_To_DataStore.ToString();
                    return result;
                }
                result.Result = new CartDto();
                mapper.Map(cart, result.Result);
            }
            else
            {
                var product = await productRepository.FindByID(request.ProductID);

                if (product == null)
                {
                    result.Code = (short)ErrorCodes.Cannot_Get_Product_From_ItemCataloge;
                    result.Message = ErrorCodes.Cannot_Get_Product_From_ItemCataloge.ToString();
                    return result;
                }
                if (product.Balance < request.Qty)
                {
                    result.Code = (short)ErrorCodes.Product_Balance_Is_Less_Than_The_Required_Qty;
                    result.Message = ErrorCodes.Product_Balance_Is_Less_Than_The_Required_Qty.ToString();
                    return result;
                }
                existingCart.AddItem(product, request.Qty);
                var UpdateResult = await cartRepository.Update(existingCart);
                if (!UpdateResult)
                {
                    result.Code = (short)ErrorCodes.Cannot_Store_Data_To_DataStore;
                    result.Message = ErrorCodes.Cannot_Store_Data_To_DataStore.ToString();
                    return result;
                }
                result.Result = new CartDto();
                mapper.Map(existingCart, result.Result);
            }
            return result;
        }
        public async Task<ResultDto<CartDto>> IncreaseItemQauntity(IncreaseCartItemDto request)
        {
            ResultDto<CartDto> result = new ResultDto<CartDto>();
            var existingCart = await cartRepository.FindByID(request.ID);

            if (existingCart == null)
            {

                result.Code = (short)ErrorCodes.Cannot_Get_Product_From_ItemCataloge;
                result.Message = ErrorCodes.Cannot_Get_Product_From_ItemCataloge.ToString();
                return result;

            }
            else
            {
                var product = await productRepository.FindByID(request.ProductID);

                if (product == null)
                {
                    result.Code = (short)ErrorCodes.Cannot_Get_Product_From_ItemCataloge;
                    result.Message = ErrorCodes.Cannot_Get_Product_From_ItemCataloge.ToString();
                    return result;
                }
                if (product.Balance < 1)
                {
                    result.Code = (short)ErrorCodes.Product_Balance_Is_Less_Than_The_Required_Qty;
                    result.Message = ErrorCodes.Product_Balance_Is_Less_Than_The_Required_Qty.ToString();
                    return result;
                }
                existingCart.IncreaseItem(product);
                var UpdateResult = await cartRepository.Update(existingCart);
                if (!UpdateResult)
                {
                    result.Code = (short)ErrorCodes.Cannot_Store_Data_To_DataStore;
                    result.Message = ErrorCodes.Cannot_Store_Data_To_DataStore.ToString();
                    return result;
                }
                result.Result = new CartDto();
                mapper.Map(existingCart, result.Result);

            }
            return result;
        }

        public async Task<ResultDto<CartDto>> DecreaseItemQauntity(DecreaseCartItemDto request)
        {
            ResultDto<CartDto> result = new ResultDto<CartDto>();
            var existingCart = await cartRepository.FindByID(request.ID);

            if (existingCart == null)
            {

                result.Code = (short)ErrorCodes.Cannot_Get_Product_From_ItemCataloge;
                result.Message = ErrorCodes.Cannot_Get_Product_From_ItemCataloge.ToString();
                return result;

            }
            else
            {
                var product = await productRepository.FindByID(request.ProductID);

                if (product == null)
                {
                    result.Code = (short)ErrorCodes.Cannot_Get_Product_From_ItemCataloge;
                    result.Message = ErrorCodes.Cannot_Get_Product_From_ItemCataloge.ToString();
                    return result;
                }

                existingCart.DecreaseItem(product);
                var UpdateResult = await cartRepository.Update(existingCart);
                if (!UpdateResult)
                {
                    result.Code = (short)ErrorCodes.Cannot_Store_Data_To_DataStore;
                    result.Message = ErrorCodes.Cannot_Store_Data_To_DataStore.ToString();
                    return result;
                }
                result.Result = new CartDto();
                mapper.Map(existingCart, result.Result);
            }
            return result;
        }

        public async Task<ResultDto<CartDto>> RemoveItem(RemoveCartItemDto request)
        {
            ResultDto<CartDto> result = new ResultDto<CartDto>();
            var existingCart = await cartRepository.FindByID(request.ID);

            if (existingCart == null)
            {

                result.Code = (short)ErrorCodes.Cannot_Get_Product_From_ItemCataloge;
                result.Message = ErrorCodes.Cannot_Get_Product_From_ItemCataloge.ToString();
                return result;

            }
            else
            {
                var product = await productRepository.FindByID(request.ProductID);

                if (product == null)
                {
                    result.Code = (short)ErrorCodes.Cannot_Get_Product_From_ItemCataloge;
                    result.Message = ErrorCodes.Cannot_Get_Product_From_ItemCataloge.ToString();
                    return result;
                }

                existingCart.RemoveItem(product);
                var UpdateResult = await cartRepository.Update(existingCart);
                if (!UpdateResult)
                {
                    result.Code = (short)ErrorCodes.Cannot_Store_Data_To_DataStore;
                    result.Message = ErrorCodes.Cannot_Store_Data_To_DataStore.ToString();
                    return result;
                }
                result.Result = new CartDto();
                mapper.Map(existingCart, result.Result);
            }
            return result;
        }
    }
}
