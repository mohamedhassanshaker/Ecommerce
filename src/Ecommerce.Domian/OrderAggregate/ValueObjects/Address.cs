using Ecommerce.Domian.Common;
using Ecommerce.Domian.OrderAggregate.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.OrderAggregate.ValueObjects
{
    public class Address : ValueObject
    {
        public string City { get; private set; }
        public string Street { get; private set; }
        public string Building { get; private set; }
        public string FlatNo { get; private set; }

        public Address(string city, string street, string building, string flatNo)
        {
            if (!Cities.Contains(city))
                throw new InvalidCityException("out of service city");
            City = city;
            Street = street;
            Building = building;
            FlatNo = flatNo;
        }
        IEnumerable<String> Cities
        {
            get
            {
                yield return "Sharjah";
                yield return "Dubai";
                yield return "Ajman";
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
            yield return Building;
            yield return FlatNo;
        }
         
    }
}
