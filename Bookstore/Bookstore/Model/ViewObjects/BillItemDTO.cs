﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.ViewObjects
{
    public class BillItemDTO
    {
        public string ArticleName { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return ArticleName + "; Amount: " + Amount + "; Price: " + Price;
        }
    }
}
