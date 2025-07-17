using Ambev.DeveloperEvaluation.Application.Services.Pricing;
using Ambev.DeveloperEvaluation.Application.Services.SalesCart;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        builder.Services.AddScoped<ISalesNumberGeneratorService, SaleNumberGeneratorService>();
        builder.Services.AddScoped<IBranchService, BranchService>();
        builder.Services.AddScoped<IPricingService, PricingService>();
    }
}