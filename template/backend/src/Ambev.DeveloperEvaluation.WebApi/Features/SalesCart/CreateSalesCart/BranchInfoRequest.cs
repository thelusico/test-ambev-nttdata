namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart
{
    /// <summary>
    /// External Identity: Apenas ID de referência ao Branch domain
    /// Dados serão buscados do Branch domain no momento do save
    /// </summary>
    public class BranchInfoRequest
    {
        public Guid BranchId { get; set; }
    }
}
