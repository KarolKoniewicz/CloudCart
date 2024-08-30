using Ebiscon.CloudCart.Domain.Abstractions;
using Ebiscon.CloudCart.Domain.Entities;

namespace Ebiscon.CloudCart.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
