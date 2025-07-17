namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart
{
    /// <summary>
    /// External Identity: ID do produto + quantidade desejada
    /// UnitPrice será obtido do Product domain no momento da venda
    /// ProductTitle e ProductCategory serão denormalizados do Product domain
    /// Discount será 0 por padrão (pode ser aplicado posteriormente)
    /// </summary>
    public class CreateSalesCartItemRequest
    {
        public Guid ProductId { get; set; }    
        public int Quantity { get; set; }
    }
}
