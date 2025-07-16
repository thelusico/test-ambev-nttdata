using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    public class Rating
    {
        public decimal Rate { get; set; } = 0;
        public int Count { get; set; } = 0;
    }
}
