using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SalesCartItem
    {
        public Guid ProductId { get; private set; } // External Identity - referência ao Product domain
        public string ProductTitle { get; private set; } // Denormalização - nome/título do produto
        public string ProductCategory { get; private set; } // Denormalização - categoria para relatórios
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalAmount { get; private set; }

        // Construtor para criação
        public SalesCartItem(Guid productId, string productTitle, string productCategory,
                       int quantity, decimal unitPrice, decimal discount = 0)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("Product ID cannot be empty");
            if (string.IsNullOrWhiteSpace(productTitle))
                throw new ArgumentException("Product title cannot be empty");
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");
            if (unitPrice < 0)
                throw new ArgumentException("Unit price cannot be negative");
            if (discount < 0 || discount > unitPrice * quantity)
                throw new ArgumentException("Invalid discount amount");

            ProductId = productId;
            ProductTitle = productTitle;
            ProductCategory = productCategory ?? string.Empty;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            //TotalAmount = CalculateTotalAmount();
        }

        // Construtor para reconstrução (MongoDB)
        public SalesCartItem(Guid productId, string productTitle, string productCategory,
                       int quantity, decimal unitPrice, decimal discount, decimal totalAmount)
        {
            ProductId = productId;
            ProductTitle = productTitle;
            ProductCategory = productCategory;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            TotalAmount = totalAmount;
        }

        // Construtor parameterless (MongoDB)
        public SalesCartItem() { }
    }
}
