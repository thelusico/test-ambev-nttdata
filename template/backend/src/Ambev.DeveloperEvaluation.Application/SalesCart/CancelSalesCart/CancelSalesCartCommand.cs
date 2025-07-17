using Ambev.DeveloperEvaluation.Application.SalesCart.CancelSalesCart.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.CancelSalesCart
{
    public class CancelSalesCartCommand: IRequest<CancelSalesCartResult>
    {
        public Guid SalesCartId { get; set; }
    }
}
