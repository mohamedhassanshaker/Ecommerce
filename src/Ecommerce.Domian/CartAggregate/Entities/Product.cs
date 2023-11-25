using Ecommerce.Domian.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ecommerce.Domian.CartAggregate.Entities
{
    public class Product : BaseAuditableEntity
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int Balance { get; private set; }
        
        public Product()
        {

        }
        [JsonConstructor]
        public Product(Guid ID, string Name, decimal Price, int Balance)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.Balance = Balance;
        }


    }
}
