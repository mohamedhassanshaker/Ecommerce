using Ecommerce.Application.Contracts.Product;
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
    public class ProductController : ControllerBase
    {
 
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
           
            this.productService = productService;
        }

        [HttpPost("Search")]
        public async Task<ResultListDto<ProductDto>> Search(ProductSearchDto request)
        {
            return await productService.Search(request);
        }
        
    }
}
