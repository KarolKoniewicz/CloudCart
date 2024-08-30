using Ebiscon.CloudCart.Domain.Entities;

namespace Ebiscon.CloudCart.Application.Abstractions.Services;

public interface IProductService
{
    Task<List<Product>> GetProducts(CancellationToken cancellationToken);
    Task<Product> GetProductById(Guid productId, CancellationToken cancellationToken);
    Task AddProduct(Product product, CancellationToken cancellationToken);
}
