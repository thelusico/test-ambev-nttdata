using Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart
{
    public class ModifySalesCartCommandHandler : IRequestHandler<ModifySalesCartCommand, ModifySalesCartResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalesCartRepository _salesCartRepository;       
        private readonly IBranchService _branchService;
        private readonly IPricingService _pricingService;

        private readonly IMapper _mapper;

        public ModifySalesCartCommandHandler(
            IProductRepository productRepository,
            IUserRepository userRepository,
            ISalesCartRepository salesCartRepository,            
            IBranchService branchService,
            IPricingService pricingService,
            IMapper mapper)
        {           
            _productRepository = productRepository;
            _userRepository = userRepository;
            _salesCartRepository = salesCartRepository;
            _branchService = branchService;
            _pricingService = pricingService;    
            _mapper = mapper;
        }

        public async Task<ModifySalesCartResult> Handle(ModifySalesCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var salesCartToModify = await _salesCartRepository.GetByIdAsync(request.SalesCartId);

                if (salesCartToModify == null)
                    throw new KeyNotFoundException($"Sales Cart with Id {request.SalesCartId} was not found!");                

                if(salesCartToModify.Customer.UserId != request.Customer)
                {
                    var newCustomer = await _userRepository.GetByIdAsync(request.Customer, cancellationToken);

                    if (newCustomer == null)
                        throw new ArgumentException($"User with ID {request.Customer} not found");

                    salesCartToModify.Customer = new CustomerInfo(newCustomer.Id, newCustomer.Username, newCustomer.Email);                   
                }              

                if(salesCartToModify.Branch.BranchId != request.Branch)
                {
                    var newBranch = await _branchService.GetByIdAsync(request.Branch);

                    if (newBranch == null)
                        throw new ArgumentException($"Branch with ID {request.Branch} not found");

                    salesCartToModify.Branch = new BranchInfo(newBranch.BranchId, newBranch.Name, newBranch.Name);
                }

                var items = new List<SalesCartItem>();

                foreach (var itemDto in request.Items)
                {
                    var product = await _productRepository.GetByIdAsync(itemDto.ProductId);

                    if (product == null)
                        throw new ArgumentException($"Product with ID {itemDto.ProductId} not found");

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

                var fullCartAmmount = _pricingService.ValidateQuantityAndApplyDiscounts(items);

                salesCartToModify.Items = items;
                salesCartToModify.UpdatedAt = DateTime.Now;
                salesCartToModify.TotalAmount = fullCartAmmount;

                await _salesCartRepository.UpdateAsync(salesCartToModify);

                return _mapper.Map<ModifySalesCartResult>(salesCartToModify);
            }
            catch
            {
                throw;
            }
        }
    }
}
