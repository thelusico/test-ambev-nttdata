using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct()
        {
            var product = new Product("Teste Product", 10, "Descriptios", Domain.Enums.ProductCategory.Electronics, "image.png", new Domain.ValueObjects.Rating
            {
                Count = 1,
                Rate = 1,
            });

            return Ok(await _productRepository.CreateAsync(product));
        }
    }
}
