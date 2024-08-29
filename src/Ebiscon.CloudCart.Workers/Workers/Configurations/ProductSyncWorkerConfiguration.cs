using Ebiscon.CloudCart.Domain.Constants;
using Ebiscon.CloudCart.Workers.Workers.Interfaces;

namespace Ebiscon.CloudCart.Workers.Workers.Configurations;

public class ProductSyncWorkerConfiguration : IConfigurationOption
{
    public string CronExpression { get; } = "0 0 * * *";
    public bool Enabled { get; set; } = true;
    public string JobId { get; set; } = WorkerConstants.ProductSyncWorkerId;
}
