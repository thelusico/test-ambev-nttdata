using Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart
{
    public class ModifySalesCartProfile : Profile
    {
        public ModifySalesCartProfile()
        {

            CreateMap<Domain.Entities.SalesCart, ModifySalesCartResult>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.UserId))
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.BranchId));

            CreateMap<SalesCartItem, ModifySalesCartItemResult>();
        }
    }
}
