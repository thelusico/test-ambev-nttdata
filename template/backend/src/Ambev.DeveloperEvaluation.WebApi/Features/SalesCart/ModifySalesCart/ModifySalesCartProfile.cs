using Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.ModifySalesCart
{
    public class ModifySalesCartProfile : Profile
    {
        public ModifySalesCartProfile()
        {
            CreateMap<ModifySalesCartRequest, ModifySalesCartCommand>();
            CreateMap<ModifySalesCartItemRequest, ModifySalesCartItemCommand>();
        }
    }
}
