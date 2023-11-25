using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Order
{
    public  class RejectPaymentDto : Dto
    {
        public Guid OrderID { get; set; }
        public string ReasoneCode { get;   set; }

        public string ReasoneMessage { get; set; }
    }
}
