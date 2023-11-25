using Ecommerce.Domian.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.DataModel.Configurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("T_Orders")
                .HasKey(c => c.ID);
            builder.OwnsMany(c => c.Details, sbuilder =>
            {
                sbuilder.ToTable("T_OrderItems");
                sbuilder.HasKey(c => c.ID);
                sbuilder.WithOwner().HasForeignKey("OrderID");
            });
            builder.OwnsOne(c => c.Address, sbuilder =>
            {
                sbuilder.Property(c => c.Street).HasColumnName("Street").IsRequired(false);
                sbuilder.Property(c => c.City).HasColumnName("City").IsRequired(false);
                sbuilder.Property(c => c.Building).HasColumnName("Building").IsRequired(false);
                sbuilder.Property(c => c.FlatNo).HasColumnName("FlatNo").IsRequired(false);
            });
            builder.OwnsOne(c => c.PaymentData, sbuilder =>
            {
                sbuilder.Property(c => c.PaymentRefernce).HasColumnName("PaymentRefernce").IsRequired(false);
                sbuilder.Property(c => c.PaymentDate).HasColumnName("PaymentDate").IsRequired(false);
                sbuilder.Property(c => c.InvoiceNumber).HasColumnName("InvoiceNumber").IsRequired(false);
                sbuilder.Property(c => c.RecievedAmount).HasColumnName("RecievedAmount").IsRequired(false);

            });
            builder.Ignore(c => c.DomainEvents);

        }
    }
}
