using Ecommerce.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Cart
{
    public class IncreaseCartItemDto : Dto
    {
        public Guid ID { get; set; }

        public Guid ProductID { get; set; }

    }

}
