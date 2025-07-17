using Ambev.DeveloperEvaluation.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services.SalesCart
{
    public class SaleNumberGeneratorService : ISalesNumberGeneratorService
    {
        public string GenerateUniqueSaleNumber()
        {
            var now = DateTime.UtcNow;
            var datePart = now.ToString("yyyyMMdd");
            var timePart = now.ToString("HHmmss");
            var randomPart = new Random().Next(1000, 9999);

            return $"AMB-{datePart}-{timePart}-{randomPart}";
        }
    }
}
