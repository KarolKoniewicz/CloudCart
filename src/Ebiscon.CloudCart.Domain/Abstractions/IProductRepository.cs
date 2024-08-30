using Ebiscon.CloudCart.Domain.Entities;

namespace Ebiscon.CloudCart.Domain.Abstractions
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(Guid productId, CancellationToken cancellationToken);
        Task InsertProduct(Product product, CancellationToken cancellationToken);
    }

}
