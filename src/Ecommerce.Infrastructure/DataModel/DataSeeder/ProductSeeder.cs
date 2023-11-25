using Ecommerce.Domian.CartAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.DataModel.DataSeeder
{
    public class ProductSeeder : ISeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasData(
                new Product(Guid.NewGuid(), "Product 1", 100, 100),
                new Product(Guid.NewGuid(), "Product 2", 100, 100),
                new Product(Guid.NewGuid(), "Product 3", 100, 100)
             );
        }
    }
}
