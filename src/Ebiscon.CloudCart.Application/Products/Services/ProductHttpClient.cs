using Microsoft.Extensions.Logging;
using Ebiscon.CloudCart.Application.HttpClient;
using Ebiscon.CloudCart.Application.Products.Contracts;
using Ebiscon.CloudCart.Application.Products.Configurations;

namespace Ebiscon.CloudCart.Application.Products.Services
{
    public class ProductHttpClient : BaseHttpClient<ProductConfiguration>
    {
        public ProductHttpClient(
            System.Net.Http.HttpClient httpClient,
            ProductConfiguration configuration,
            ILogger<BaseHttpClient<ProductConfiguration>> logger)
                : base(httpClient, configuration, logger)
        {


        }

        public async Task<List<ProductResponse>> GetProducts(CancellationToken cancellationToken)
            => await Send<object, List<ProductResponse>>((builder) => builder
                        .ToEndpoint($"{Configuration.Api})")
                        .Build());

    }
}
