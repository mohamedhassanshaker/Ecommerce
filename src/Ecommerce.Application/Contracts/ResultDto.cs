using Ecommerce.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dto
{
    public class ResultDto   : Contracts.Dto
    {
        public short Code { get; set; }
        public string Message { get; set; }
        

    }
    public class ResultDto<T> where T : Contracts.Dto
    {
        public short Code { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

    }
    public class ResultListDto<T> where T : Contracts.Dto
    {
        public short Code { get; set; }
        public string Message { get; set; }
        public List<T> Result { get; set; }

    }
}
