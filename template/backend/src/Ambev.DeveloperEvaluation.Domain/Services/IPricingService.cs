using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface IPricingService
    {
        /// <summary>
        /// Aplica descontos baseados nas regras de quantidade
        /// </summary>
        IEnumerable<SalesCartItem> ApplyQuantityDiscounts(IEnumerable<SalesCartItem> items);
    }
}
