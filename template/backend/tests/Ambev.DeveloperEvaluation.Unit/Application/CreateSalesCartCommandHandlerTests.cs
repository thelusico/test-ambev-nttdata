using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart;
using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateSalesCartCommandHandlerTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalesCartRepository _salesCartRepository;
        private readonly ISalesNumberGeneratorService _salesNumberGenerator;
        private readonly IBranchService _branchService;
        private readonly IPricingService _pricingService;
        private readonly ILogger<CreateSalesCartCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly CreateSalesCartCommandHandler _handler;

        public CreateSalesCartCommandHandlerTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _salesCartRepository = Substitute.For<ISalesCartRepository>();
            _salesNumberGenerator = Substitute.For<ISalesNumberGeneratorService>();
            _branchService = Substitute.For<IBranchService>();
            _pricingService = Substitute.For<IPricingService>();
            _mapper = Substitute.For<IMapper>();

            _handler = new CreateSalesCartCommandHandler(
                _productRepository,
                _userRepository,
                _salesCartRepository,
                _salesNumberGenerator,
                _branchService,
                _pricingService,
                _mapper);
        }

        #region Helper Methods
        private void SetupValidScenario(User user, BranchInfo branch, Product product, SalesCart salesCart, CreateSalesCartResult result)
        {
            _userRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(user);
            _branchService.GetByIdAsync(Arg.Any<Guid>()).Returns(branch);
            _productRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(product);
            _pricingService.ValidateQuantityAndApplyDiscounts(Arg.Any<List<SalesCartItem>>()).Returns(200.00m);
            _salesNumberGenerator.GenerateUniqueSaleNumber().Returns(CreateSalesCartHandlerTestData.GenerateUniqueSaleNumber());
            _salesCartRepository.CreateAsync(Arg.Any<SalesCart>()).Returns(salesCart);
            _mapper.Map<CreateSalesCartResult>(salesCart).Returns(result);
        }
        #endregion

        [Fact(DisplayName = "Given valid sales cart data When creating sales cart Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CreateSalesCartHandlerTestData.GenerateValidCommand();
            var user = CreateSalesCartHandlerTestData.GenerateValidUser(command.Customer);
            var branch = CreateSalesCartHandlerTestData.GenerateValidBranch(command.Branch);
            var product = CreateSalesCartHandlerTestData.GenerateValidProduct(command.Items.First().ProductId);
            var createdSalesCart = CreateSalesCartHandlerTestData.GenerateValidSalesCart();
            var expectedResult = CreateSalesCartHandlerTestData.GenerateValidResult(createdSalesCart.Id);

            SetupValidScenario(user, branch, product, createdSalesCart, expectedResult);

            // When
            var result = await _handler.Handle(command, CancellationToken.None);

            // Then
            result.Should().NotBeNull();
            result.Id.Should().Be(createdSalesCart.Id);
        }

        [Fact(DisplayName = "Given non-existent user When creating sales cart Then throws ArgumentException")]
        public async Task Handle_UserNotFound_ThrowsArgumentException()
        {
            // Given
            var command = CreateSalesCartHandlerTestData.GenerateValidCommand();
            _userRepository.GetByIdAsync(command.Customer).Returns((User)null);

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"User with ID {command.Customer} not found");
        }

        [Fact(DisplayName = "Given non-existent branch When creating sales cart Then throws ArgumentException")]
        public async Task Handle_BranchNotFound_ThrowsArgumentException()
        {
            // Given
            var command = CreateSalesCartHandlerTestData.GenerateValidCommand();
            var user = CreateSalesCartHandlerTestData.GenerateValidUser(command.Customer);

            _userRepository.GetByIdAsync(command.Customer).Returns(user);
            _branchService.GetByIdAsync(command.Branch).Returns((BranchInfo)null);

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"Branch with ID {command.Branch} not found");
        }

        [Fact(DisplayName = "Given non-existent product When creating sales cart Then throws ArgumentException")]
        public async Task Handle_ProductNotFound_ThrowsArgumentException()
        {
            // Given
            var command = CreateSalesCartHandlerTestData.GenerateValidCommand();
            var user = CreateSalesCartHandlerTestData.GenerateValidUser(command.Customer);
            var branch = CreateSalesCartHandlerTestData.GenerateValidBranch(command.Branch);

            _userRepository.GetByIdAsync(command.Customer).Returns(user);
            _branchService.GetByIdAsync(command.Branch).Returns(branch);
            _productRepository.GetByIdAsync(command.Items.First().ProductId).Returns((Product)null);

            // When
            var act = () => _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"Product with ID {command.Items.First().ProductId} not found");
        }

        [Fact(DisplayName = "Given valid request When handling Then calls pricing service")]
        public async Task Handle_ValidRequest_CallsPricingService()
        {
            // Given
            var command = CreateSalesCartHandlerTestData.GenerateValidCommand();
            var user = CreateSalesCartHandlerTestData.GenerateValidUser(command.Customer);
            var branch = CreateSalesCartHandlerTestData.GenerateValidBranch(command.Branch);
            var product = CreateSalesCartHandlerTestData.GenerateValidProduct(command.Items.First().ProductId);
            var createdSalesCart = CreateSalesCartHandlerTestData.GenerateValidSalesCart();
            var expectedResult = CreateSalesCartHandlerTestData.GenerateValidResult(createdSalesCart.Id);

            SetupValidScenario(user, branch, product, createdSalesCart, expectedResult);

            // When
            await _handler.Handle(command, CancellationToken.None);

            // Then
            _pricingService.Received(1).ValidateQuantityAndApplyDiscounts(Arg.Any<List<SalesCartItem>>());
        }

        [Fact(DisplayName = "Given valid request When handling Then maps result")]
        public async Task Handle_ValidRequest_MapsResult()
        {
            // Given
            var command = CreateSalesCartHandlerTestData.GenerateValidCommand();
            var user = CreateSalesCartHandlerTestData.GenerateValidUser(command.Customer);
            var branch = CreateSalesCartHandlerTestData.GenerateValidBranch(command.Branch);
            var product = CreateSalesCartHandlerTestData.GenerateValidProduct(command.Items.First().ProductId);
            var createdSalesCart = CreateSalesCartHandlerTestData.GenerateValidSalesCart();
            var expectedResult = CreateSalesCartHandlerTestData.GenerateValidResult(createdSalesCart.Id);

            SetupValidScenario(user, branch, product, createdSalesCart, expectedResult);

            // When
            await _handler.Handle(command, CancellationToken.None);

            // Then
            _mapper.Received(1).Map<CreateSalesCartResult>(createdSalesCart);
        }
    }
}
