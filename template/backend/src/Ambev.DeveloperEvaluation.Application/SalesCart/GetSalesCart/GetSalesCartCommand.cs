using Ambev.DeveloperEvaluation.Application.SalesCart.GetSalesCart.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.GetSalesCart
{
    public class GetSalesCartCommand :IRequest<GetSalesCartResult>
    {
        public Guid SalesCartId { get; set; }
    }
}
