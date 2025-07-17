using Ambev.DeveloperEvaluation.Application.SalesCart.GetSalesCart.Results;
using Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.GetSalesCart
{
    public class GetSalesCartProfile : Profile
    {
        public GetSalesCartProfile()
        {
            CreateMap<Domain.Entities.SalesCart, GetSalesCartResult>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.UserId))
            .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.BranchId))
            .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.Name))
            .ForMember(dest => dest.BranchLocation, opt => opt.MapFrom(src => src.Branch.Location));            

            CreateMap<SalesCartItem, GetSalesCartItemResult>();
        }
    }
}
