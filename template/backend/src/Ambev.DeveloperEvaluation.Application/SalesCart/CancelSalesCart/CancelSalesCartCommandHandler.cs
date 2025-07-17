using Ambev.DeveloperEvaluation.Application.SalesCart.CancelSalesCart.Results;
using Ambev.DeveloperEvaluation.Application.SalesCart.GetSalesCart.Results;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.CancelSalesCart
{
    public class CancelSalesCartCommandHandler : IRequestHandler<CancelSalesCartCommand, CancelSalesCartResult>
    {

        private readonly ISalesCartRepository _salesCartRepository;
        public CancelSalesCartCommandHandler(ISalesCartRepository salesCartRepository)
        {
            _salesCartRepository = salesCartRepository;            
        }


        public async Task<CancelSalesCartResult> Handle(CancelSalesCartCommand request, CancellationToken cancellationToken)
        {
            var salesCart = await _salesCartRepository.GetByIdAsync(request.SalesCartId);
            if (salesCart == null)
                throw new KeyNotFoundException($"Sales Cart with Id {request.SalesCartId} was not found!");

            salesCart.IsCancelled = true;
            salesCart.CancelledAt = DateTime.UtcNow;
            salesCart.UpdatedAt = DateTime.UtcNow;

            await _salesCartRepository.UpdateAsync(salesCart);

            return new CancelSalesCartResult { Message = $"Sales Cart with Id {request.SalesCartId} was canceled!"};
        }
    }
}
