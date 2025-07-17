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
        public Guid Id { get; private set; }
        public string SaleNumber { get; private set; }
        public DateTime SaleDate { get; private set; }
        public CustomerInfo Customer { get; private set; }
        public BranchInfo Branch { get; private set; }
        public List<SalesCartItem> Items { get; private set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; private set; }
        public DateTime? CancelledAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

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
