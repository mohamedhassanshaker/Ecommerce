using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Events;
using Ecommerce.Domian.Common;
using Ecommerce.Domian.OrderAggregate.Entities;
using Ecommerce.Domian.OrderAggregate.Enums;
using Ecommerce.Domian.OrderAggregate.Events;
using Ecommerce.Domian.OrderAggregate.Exceptions;
using Ecommerce.Domian.OrderAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate
{
    public class Order : BaseAuditableAggregate
    {
        
        public string OrderNumber { get; private set; }
        public OrderStatus status { get; private set; }
        private readonly List<OrderDetail> _orderDetails;
        public IReadOnlyCollection<OrderDetail> Details => _orderDetails.AsReadOnly<OrderDetail>();

        public Address Address { get; private set; }

        public PaymentData PaymentData { get; private set; }
        public decimal Total { get; private set; }
        public Order()
        {

        }
        public Order(string orderNumber,Cart cart)
        {
            OrderNumber = orderNumber;
            _orderDetails = cart.CartItems.Select(en => new OrderDetail(en.Product.ID, en.Quantity, en.Price)
            {
                Created = DateTime.Now,
                CreatedBy = cart.CreatedBy,
            }).ToList();
            status = OrderStatus.New;
            Total = _orderDetails.Sum(en => en.Qty * en.Price);
        }

        public void Confirm()
        {
            if (status != OrderStatus.New)
                throw new ConfirmOrderWithInvalidStatusException("Can't confirm order with status not in new status");
            status = OrderStatus.PendingPayment;
            AddDomainEvent(new PaymentRequestedEvent(this));
        }
        public void AuthorizePayment(PaymentData paymentData)
        {
            PaymentData = paymentData;
            status = OrderStatus.PaymentAccepted;
            AddDomainEvent(new PaymentAcceptedEvent(this));
        }
        public void RejectPayment()
        {
            if (status == OrderStatus.PaymentAccepted || status == OrderStatus.Completed || status == OrderStatus.Shipped)
                throw new RejectOrderWithInavlidStatusException("Can't reject order in this status");
            status = OrderStatus.PaymentRejected;
            AddDomainEvent(new PaymentRejectedEvent(this));
        }
        public void ProvideDeliveryAddress(Address address)
        {
            Address = address;
        }
        
        public void Ship( )
        {
           
            if (status != OrderStatus.PaymentAccepted)
                throw new ShipNonPaidOrderException("Can't ship non paid order");
            status = OrderStatus.Shipped;
            AddDomainEvent(new OrderCompletedEvent(this));
            AddDomainEvent(new InventoryUpdatedEvent(this));
        }

    }
}
