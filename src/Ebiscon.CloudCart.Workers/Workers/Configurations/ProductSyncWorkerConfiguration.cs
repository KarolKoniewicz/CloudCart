using STI.Workers.Constants;
using Ebiscon.CloudCart.Workers.Workers.Interfaces;
using Ebiscon.CloudCart.Domain.Constants;

namespace Ebiscon.CloudCart.Workers.Workers.Configurations;

public class ProductSyncWorkerConfiguration : IConfigurationOption
{
    public string CronExpression { get; } = "0 0 * * *";
    public bool Enabled { get; set; } = true;
    public string JobId { get; set; } = WorkerConstants.ProductSyncWorkerId;
}
