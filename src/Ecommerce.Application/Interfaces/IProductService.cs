using Ecommerce.Application.Contracts.Product;
using Ecommerce.Application.Dto;

namespace Ecommerce.Application.Interfaces
{
    public interface IProductService
    {
        Task<ResultListDto<ProductDto>> Search(ProductSearchDto request);
    }
}