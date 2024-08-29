using Hangfire;
using Ebiscon.CloudCart.Workers.Workers.Base;
using Ebiscon.CloudCart.Workers.Workers.Interfaces;
using Ebiscon.CloudCart.Workers.Workers.Configurations;

namespace STI.Workers;

public class ProductSyncWorker : BaseWorker<ProductSyncWorkerConfiguration>
{
    public ProductSyncWorker(
        IBackgroundJobClient backgroundJobClient,
        [FromKeyedServices(nameof(ProductSyncWorkerConfiguration))] IConfigurationOption configurationOption)
                : base(backgroundJobClient, configurationOption)
    {
       
    }

    protected override async Task Execute(CancellationToken cancellationToken)
    {

    }
}
