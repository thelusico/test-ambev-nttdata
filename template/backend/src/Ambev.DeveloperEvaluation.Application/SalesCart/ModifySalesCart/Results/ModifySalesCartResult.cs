using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart.Results
{
    public class ModifySalesCartResult
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public Guid Customer { get; set; } = new();
        public Guid Branch { get; set; } = new();
        public List<ModifySalesCartItemResult> Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? CancelledAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
