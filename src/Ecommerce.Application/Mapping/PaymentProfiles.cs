using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Contracts.Cart;
using Ecommerce.Application.Contracts.Product;
using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Entities;

namespace Ecommerce.Application.Mapping
{
    public class PaymentProfiles : Profile // this class inherits from AutoMapper profile class  
    {
        public PaymentProfiles()
        {
            
            CreateMap<Product, ProductDto > ().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems)).ReverseMap().IgnoreAllNonExisting();

            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest=>dest.Name, opt => opt.MapFrom(src=>src.Product.Name))
                .ReverseMap().IgnoreAllNonExisting();

        }
    }
}
