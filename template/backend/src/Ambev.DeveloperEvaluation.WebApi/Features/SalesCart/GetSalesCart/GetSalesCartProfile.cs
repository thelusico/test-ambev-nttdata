using Ambev.DeveloperEvaluation.Application.SalesCart.GetSalesCart;
using Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.ModifySalesCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.GetSalesCart
{
    public class GetSalesCartProfile : Profile
    {
        public GetSalesCartProfile()
        {
            CreateMap<GetSalesCartRequest, GetSalesCartCommand>();          
        }
    }
}
