using Ecommerce.Domian.CartAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.DataModel.DataSeeder
{
    public static class ModelBuilderSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            
            var baseInstallers = typeof(ISeeder).Assembly.ExportedTypes.Where(x =>
                typeof(ISeeder).IsAssignableFrom(x) && !x.IsInterface && x.IsAbstract).Select(Activator.CreateInstance)
                .Cast<ISeeder>().ToList();

            var installers = typeof(ISeeder).Assembly.ExportedTypes.Where(x =>
                typeof(ISeeder).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance)
                .Cast<ISeeder>().ToList();

            baseInstallers.ForEach(installer => installer.Seed(modelBuilder));
            installers.ForEach(installer => installer.Seed(modelBuilder));
        }
    }
}
