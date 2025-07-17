using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart.Results;
using Ambev.DeveloperEvaluation.Application.Services.Pricing;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart
{
    public class CreateSalesCartCommandHandler : IRequestHandler<CreateSalesCartCommand, CreateSalesCartResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalesCartRepository _salesCartRepository;

        private readonly ISalesNumberGeneratorService _salesNumberGenerator;
        private readonly IBranchService _branchService;
        private readonly IPricingService _pricingService;

        private readonly IMapper _mapper;
        public CreateSalesCartCommandHandler(
            IProductRepository productRepository,
            IUserRepository userRepository,
            ISalesCartRepository salesCartRepository,
            ISalesNumberGeneratorService salesNumberGeneratorService,
            IBranchService branchService,
            IPricingService pricingService,
            ILogger<CreateSalesCartCommandHandler> logger,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _salesCartRepository = salesCartRepository;

            _salesNumberGenerator = salesNumberGeneratorService;
            _branchService = branchService;
            _pricingService = pricingService;

            _mapper = mapper;
        }

        public async Task<CreateSalesCartResult> Handle(CreateSalesCartCommand request, CancellationToken cancellationToken)
        {
            try
            {

                Log.Information($"[CreateSalesCartCommand].Handle => Handle Initialize, creating SalesCart for {request.Customer}");

                var user = await _userRepository.GetByIdAsync(request.Customer);
                if (user == null)
                {
                    Log.Error($"[CreateSalesCartCommand].Handle => User with ID {request.Customer} not found");
                    throw new ArgumentException($"User with ID {request.Customer} not found");
                }                  

                var customer = new CustomerInfo(user.Id, user.Username, user.Email);

                var branch = await _branchService.GetByIdAsync(request.Branch);

                if (branch == null)
                {
                    Log.Error($"[CreateSalesCartCommand].Handle => Branch with ID {request.Branch} not found");
                    throw new ArgumentException($"Branch with ID {request.Branch} not found");
                }
                   

                var branchInfo = new BranchInfo(branch.BranchId, branch.Name, branch.Location);

                var items = new List<SalesCartItem>();

                foreach (var itemDto in request.Items)
                {
                    var product = await _productRepository.GetByIdAsync(itemDto.ProductId);

                    if (product == null)
                    {
                        Log.Error($"[CreateSalesCartCommand].Handle => Product with ID {itemDto.ProductId} not found");
                        throw new ArgumentException($"Product with ID {itemDto.ProductId} not found");
                    }                   

                    // Criar item com dados denormalizados do produto
                    var item = new SalesCartItem(
                        product.Id,
                        product.Title,
                        product.Category.ToString(),
                        itemDto.Quantity,
                        product.Price,
                        0
                    );

                    items.Add(item);
                }

                Log.Information($"[CreateSalesCartCommand].Handle => Validate Item Quantity for customer: {request.Customer}");

                var fullCartAmmount = _pricingService.ValidateQuantityAndApplyDiscounts(items);

                var saleNumber = _salesNumberGenerator.GenerateUniqueSaleNumber();

                Log.Information($"[CreateSalesCartCommand].Handle => Sale Number: {saleNumber}");

                var salesCart = new Domain.Entities.SalesCart(saleNumber, customer, branchInfo, items);

                salesCart.TotalAmount = fullCartAmmount;

                var createdSalesCart = await _salesCartRepository.CreateAsync(salesCart);

                Log.Information($"[CreateSalesCartCommand].Handle => SaleCart Created: {createdSalesCart.Id}");

                return _mapper.Map<CreateSalesCartResult>(createdSalesCart);

            }
            catch
            {
                throw;
            }

        }
    }
}
