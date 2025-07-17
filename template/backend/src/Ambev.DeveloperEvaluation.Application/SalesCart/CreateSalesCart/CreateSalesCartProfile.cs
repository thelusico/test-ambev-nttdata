using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart
{
    public class CreateSalesCartProfile : Profile
    {
        public CreateSalesCartProfile()
        {
            CreateMap<Domain.Entities.SalesCart, CreateSalesCartResult>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.UserId))
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.BranchId));

            CreateMap<SalesCartItem, CreateSalesCartItemResult>();
        }
    }
}
