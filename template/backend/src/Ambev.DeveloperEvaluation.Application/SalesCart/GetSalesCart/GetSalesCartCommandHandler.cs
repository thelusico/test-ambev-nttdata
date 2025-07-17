using Ambev.DeveloperEvaluation.Application.SalesCart.GetSalesCart.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.GetSalesCart
{
    public class GetSalesCartCommandHandler : IRequestHandler<GetSalesCartCommand, GetSalesCartResult>
    {
        private readonly ISalesCartRepository _salesCartRepository;
        private readonly IMapper _mapper;

        public GetSalesCartCommandHandler(ISalesCartRepository repository, IMapper mapper)
        {
            _salesCartRepository = repository;
            _mapper = mapper;
        }
        public async Task<GetSalesCartResult> Handle(GetSalesCartCommand request, CancellationToken cancellationToken)
        {
            var salesCart = await _salesCartRepository.GetByIdAsync(request.SalesCartId);
            if (salesCart == null)
                throw new KeyNotFoundException($"Sales Cart with Id {request.SalesCartId} was not found!");
            
            return _mapper.Map<GetSalesCartResult>(salesCart);
        }
    }
}
