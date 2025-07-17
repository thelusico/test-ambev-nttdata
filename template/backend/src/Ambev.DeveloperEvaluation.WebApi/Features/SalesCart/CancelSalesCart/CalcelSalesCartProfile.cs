using Ambev.DeveloperEvaluation.Application.SalesCart.CancelSalesCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CancelSalesCart
{
    public class CalcelSalesCartProfile : Profile
    {
        public CalcelSalesCartProfile()
        {
            CreateMap<CancelSalesCartRequest, CancelSalesCartCommand>();            
        }
    }
}
