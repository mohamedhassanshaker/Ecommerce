using Ecommerce.Domian.CartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.DataModel.Configurations
{
    public class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("T_Carts")
                .HasKey(c => c.ID);
            builder.OwnsMany(c => c.CartItems, CI =>
            {
                CI.ToTable("T_CartItems");
                CI.HasKey(c => c.ID);
                CI.Ignore("IsNew");
                CI.Ignore("IsDeleted");
                CI.WithOwner().HasForeignKey("CartID");
            });
            builder.Ignore(c => c.DomainEvents);

        }
    }
}
