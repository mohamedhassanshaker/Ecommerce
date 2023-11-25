﻿using Ecommerce.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dto
{
    public class CartItemDto : DTO
    {
       
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}
