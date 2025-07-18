using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SalesCart
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public CustomerInfo Customer { get; set; }
        public BranchInfo Branch { get; set; }
        public List<SalesCartItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? CancelledAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public SalesCart(string saleNumber, CustomerInfo customer, BranchInfo branch, List<SalesCartItem> items)
        {
            Id = Guid.NewGuid();
            SaleNumber = saleNumber;
            SaleDate = DateTime.UtcNow;
            Customer = customer;
            Branch = branch;
            Items = items ?? new List<SalesCartItem>();
            //TotalAmount = CalculateTotalAmount();
            IsCancelled = false;
            CreatedAt = DateTime.UtcNow;
        }
       
        public SalesCart(Guid id, string saleNumber, DateTime saleDate, CustomerInfo customer,
                   BranchInfo branch, List<SalesCartItem> items, decimal totalAmount, bool isCancelled,
                   DateTime? cancelledAt, DateTime createdAt, DateTime? updatedAt)
        {
            Id = id;
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            Customer = customer;
            Branch = branch;
            Items = items ?? new List<SalesCartItem>();
            TotalAmount = totalAmount;
            IsCancelled = isCancelled;
            CancelledAt = cancelledAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        
        public SalesCart()
        {
            Items = new List<SalesCartItem>();
        }


    }
}
