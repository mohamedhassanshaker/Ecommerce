using Ecommerce.Domian.Common;
using Ecommerce.Domian.OrderAggregate.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate.ValueObjects
{
    public class PaymentData : ValueObject
    {
        private PaymentData() { }
        public PaymentData(Order order,decimal recievedAmount,string invoiceNumber,DateTime paymentDate,string paymentRefernce)
        {
            if(recievedAmount<order.Total)
                throw new RecievedAmountNotMatchOrderTotalException("Recieved amount is less than order total amount");
            if (recievedAmount > order.Total)
                throw new RecievedAmountNotMatchOrderTotalException("Recieved amount is greater than order total amount");

            RecievedAmount = recievedAmount;
            InvoiceNumber = invoiceNumber;
            PaymentDate = paymentDate;
            PaymentRefernce = paymentRefernce;
        }

        public decimal? RecievedAmount { get; private set; }
        public string InvoiceNumber { get; private set; }
        public DateTime? PaymentDate { get; private set; }
        public string PaymentRefernce { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RecievedAmount;
            yield return InvoiceNumber;
            yield return PaymentDate;
            yield return PaymentRefernce;
        }
    }
}
