﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart
{
    public class ModifySalesCartItemCommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
