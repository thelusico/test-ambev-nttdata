namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart
{
    /// <summary>
    /// External Identity: Apenas ID de referência ao User domain
    /// Dados serão buscados do User domain no momento do save
    /// </summary>
    public class CustomerInfoRequest
    {
        public Guid UserId { get; set; }
    }
}
