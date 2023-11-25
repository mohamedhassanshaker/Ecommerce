using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domian.Common
{
    public class OperationResult<T> where T : class
    {
        public OperationResult() { }
        public T Value { get; set; }


    }
}
