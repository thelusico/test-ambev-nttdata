using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart
{
    public class CreateSalesCartProfile : Profile
    {
        public CreateSalesCartProfile()
        {
            CreateMap<CreateSalesCartRequest, CreateSalesCartCommand>();
            CreateMap<CreateSalesCartItemRequest, CreateSalesCartItemCommand>();
        }

       
    }
}
