namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.ModifySalesCart
{
    public class ModifySalesCartItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
