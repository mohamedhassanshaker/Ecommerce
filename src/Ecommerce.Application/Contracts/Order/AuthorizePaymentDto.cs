using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Order
{
    public  class AuthorizePaymentDto:Dto
    {
        public Guid OrderID { get; set; }
        public decimal RecievedAmount { get;   set; }
        public string InvoiceNumber { get;   set; }
        public DateTime PaymentDate { get;   set; }
        public string PaymentRefernce { get;   set; }
    }
}
