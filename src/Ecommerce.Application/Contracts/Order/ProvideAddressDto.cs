using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Order
{
    public class ProvideAddressDto:Dto
    {
        public Guid OrderID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string FlatNo { get; set; }
    }
}
