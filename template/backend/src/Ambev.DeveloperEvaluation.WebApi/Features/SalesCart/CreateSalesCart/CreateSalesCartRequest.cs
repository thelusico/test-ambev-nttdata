namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart
{
    public class CreateSalesCartRequest
    {
        public Guid Customer { get; set; } = new();
        public Guid Branch { get; set; } = new();
        public List<CreateSalesCartItemRequest> Items { get; set; } = new();
    }
}
