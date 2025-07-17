namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart
{
    public class CreateSalesCartRequest
    {
        public CustomerInfoRequest Customer { get; set; } = new();
        public BranchInfoRequest Branch { get; set; } = new();
        public List<SalesCartItemRequest> Items { get; set; } = new();
    }
}
