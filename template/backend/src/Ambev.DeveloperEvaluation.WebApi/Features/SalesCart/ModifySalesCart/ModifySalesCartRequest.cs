using Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.ModifySalesCart
{
    public class ModifySalesCartRequest
    {
        public Guid SalesCartId { get; set; } = new();
        public Guid? Customer { get; set; }
        public Guid? Branch { get; set; }
        public List<ModifySalesCartItemRequest> Items { get; set; } = new();
    }
}
