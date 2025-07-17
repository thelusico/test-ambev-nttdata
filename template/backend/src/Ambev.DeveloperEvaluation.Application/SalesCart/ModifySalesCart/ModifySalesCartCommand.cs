
using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart.Results;
using Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart
{
    public class ModifySalesCartCommand : IRequest<ModifySalesCartResult>
    {
        public Guid SalesCartId { get; set; }
        public Guid Customer { get; set; }
        public Guid Branch { get; set; }
        public List<ModifySalesCartItemCommand> Items { get; set; }
    }
}
