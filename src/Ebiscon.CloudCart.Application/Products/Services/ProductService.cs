using Ebiscon.CloudCart.Domain.Entities;
using Ebiscon.CloudCart.Application.Abstractions.Services;

namespace Ebiscon.CloudCart.Application.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductHttpClient productHttpClient;

        public ProductService(ProductHttpClient productHttpClient)
        {
            this.productHttpClient = productHttpClient;
        }

        public Task AddProduct(Product product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(Guid productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProducts(CancellationToken cancellationToken)
         => (await productHttpClient.GetProducts(cancellationToken))
             .Select(x => new Product()
             {
                 //mappings
             }).ToList();
    }
}
