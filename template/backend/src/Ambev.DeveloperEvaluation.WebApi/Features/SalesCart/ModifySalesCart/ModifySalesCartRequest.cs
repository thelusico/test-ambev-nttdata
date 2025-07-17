using Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.ModifySalesCart
{
    public class ModifySalesCartRequest
    {
        public Guid SalesCartId { get; set; } = new();
        public Guid Customer { get; set; } = new();
        public Guid Branch { get; set; } = new();
        public List<ModifySalesCartItemRequest> Items { get; set; } = new();
    }
}
