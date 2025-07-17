using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services.Pricing
{
    public class PricingService : IPricingService
    {

        /// <summary>
        /// Aplica desconto baseado na quantidade seguindo as regras de negócio
        /// </summary>
        public IEnumerable<SalesCartItem> ApplyQuantityDiscounts(IEnumerable<SalesCartItem> items)
        {

            foreach (var item in items)
            {
                IsQuantityAllowed(item.Quantity);

                decimal discountPercentage = CalculateDiscountPercentage(item.Quantity);
                item.TotalAmount = item.UnitPrice * item.Quantity;
                item.Discount = item.TotalAmount * discountPercentage;
            }

            return items;            
        }

        /// <summary>
        /// Valida as regras de negócio para quantidade
        /// </summary>
        private static void IsQuantityAllowed(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (quantity > 20)
                throw new InvalidOperationException("It's not possible to sell above 20 identical items");
        }

        /// <summary>
        /// Calcula a porcentagem de desconto baseado na quantidade
        /// Business Rules:
        /// - 4+ items: 10% discount
        /// - 10-20 items: 20% discount  
        /// - Below 4 items: No discount
        /// - Above 20 items: Not allowed
        /// </summary>
        private static decimal CalculateDiscountPercentage(int quantity)
        {
            return quantity switch
            {
                >= 10 and <= 20 => 0.20m, // 20% para 10-20 itens
                >= 4 and < 10 => 0.10m,   // 10% para 4-9 itens
                < 4 => 0m,                // Sem desconto para menos de 4 itens
                _ => throw new InvalidOperationException("Invalid quantity for discount calculation")
            };
        }
    }
}
