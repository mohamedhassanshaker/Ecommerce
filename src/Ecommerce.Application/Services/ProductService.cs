using AutoMapper;
using Ecommerce.Application.Common;
using Ecommerce.Application.Contracts.Product;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Interfaces;
using Ecommerce.Domian.Common.Interfaces;
using Ecommerce.Domian.OrderAggregate.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class ProductService : BaseApplicationService, IProductService
    {

        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        private readonly ICacheProvider cacheProvider;

        public ProductService(IProductRepository productRepository, IMapper mapper, ICacheProvider cacheProvider)
        {

            this.productRepository = productRepository;
            this.mapper = mapper;
            this.cacheProvider = cacheProvider;
        }

        public async Task<ResultListDto<ProductDto>> Search(ProductSearchDto request)
        {
            var result = new ResultListDto<ProductDto>();
            var productList = await productRepository.Find(new ProductSearchSpec(request.Name, request.PriceFrom, request.PriceTo));
            if (productList == null)
            {
                result.Code = (short)ErrorCodes.Cannot_Get_Product_From_ItemCataloge;
                result.Message = ErrorCodes.Cannot_Get_Product_From_ItemCataloge.ToString();
                return result;
            }
            result.Result = new List<ProductDto>();
            mapper.Map(productList, result.Result);
            return result;
        }


    }
}
