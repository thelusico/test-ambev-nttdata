
namespace Ambev.DeveloperEvaluation.Application.SalesCart.ModifySalesCart
{
    public class ModifySalesCartCommand
    {
        public Guid SalesCartId { get; set; }
        public Guid Customer { get; set; }
        public Guid Branch { get; set; }
        public List<ModifySalesCartItemCommand> Items { get; set; }
    }
}
