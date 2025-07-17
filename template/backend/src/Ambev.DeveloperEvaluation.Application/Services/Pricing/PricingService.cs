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

        private const int CategoryQuantityLimit = 20;      
        
        /// <summary>
        /// Aplica desconto baseado na quantidade seguindo as regras de negócio
        /// </summary>
        public decimal ValidateQuantityAndApplyDiscounts(IEnumerable<SalesCartItem> items)
        {

            decimal fullAmmount = 0;
            decimal fullCartAmmout = 0;
            var groupCategory = IsCategoryQuantityAllowed(items);           

            foreach (var item in items)
            {
                decimal discountPercentage = CalculateDiscountPercentage(groupCategory[item.ProductCategory]);
                fullAmmount = item.UnitPrice * item.Quantity;
                item.Discount = fullAmmount * discountPercentage;
                item.TotalAmount = fullAmmount - item.Discount;

                fullCartAmmout += item.TotalAmount;
            }

            return fullCartAmmout;
        }

        /// <summary>
        /// Valida as regras de negócio para quantidade da categoru
        /// </summary>
        private Dictionary<string, int> IsCategoryQuantityAllowed(IEnumerable<SalesCartItem> items)
        {
            var itemByCategory = items.GroupBy(i => i.ProductCategory);
            var result = new Dictionary<string, int>();

            foreach (var categoryGroup in itemByCategory)
            {
                var totalQtdeByCategory = categoryGroup.Sum(i => i.Quantity);
                result.Add(categoryGroup.Key, totalQtdeByCategory);

                if (totalQtdeByCategory > CategoryQuantityLimit)
                {
                    throw new InvalidOperationException(
                      $"It's not possible to sell above {CategoryQuantityLimit} items per category. " +
                      $"Category '{categoryGroup.Key}' has {totalQtdeByCategory} items.");
                }
            }

            return result;
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
