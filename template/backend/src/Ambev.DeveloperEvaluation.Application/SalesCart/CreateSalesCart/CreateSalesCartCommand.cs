using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart
{
    public class CreateSalesCartCommand : IRequest<CreateSalesCartResult>
    {
        public Guid Customer { get; set; }
        public Guid Branch { get; set; }          
        public List<SalesCartItemCommand> Items { get; set; }
    }
}
