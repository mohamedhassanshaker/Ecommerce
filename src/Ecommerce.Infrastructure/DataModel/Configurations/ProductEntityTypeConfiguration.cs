using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.DataModel.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("T_Products")
                .HasKey(c => c.ID);
           
            builder.Ignore(c => c.DomainEvents);

        }
    }
}
