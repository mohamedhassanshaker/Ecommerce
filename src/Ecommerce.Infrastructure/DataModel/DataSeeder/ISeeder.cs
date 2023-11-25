using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.DataModel.DataSeeder
{
    public interface ISeeder
    {
        public void Seed(ModelBuilder modelBuilder);
    }
}
