﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int? CategoryId { get; set; }
        public string? CategoryName { get; set;}

    }
}
