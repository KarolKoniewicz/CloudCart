using Hangfire;
using Ebiscon.CloudCart.Workers.Base;
using Ebiscon.CloudCart.Workers.Workers.Interfaces;

namespace Ebiscon.CloudCart.Workers.Workers.Base;

public abstract class BaseWorker<TConfiguration> : IBaseWorker
    where TConfiguration : IConfigurationOption
{
    private readonly IBackgroundJobClient backgroundJobClient;
    protected readonly IConfigurationOption configurationOption;

    protected BaseWorker(
        IBackgroundJobClient backgroundJobClient,
        IConfigurationOption configurationOption)
    {
        this.backgroundJobClient = backgroundJobClient;
        this.configurationOption = configurationOption;
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        try
        {
            if (configurationOption.Enabled)
                await Execute(cancellationToken);

        }
        catch (Exception)
        {
            throw;
        }
    }

    protected abstract Task Execute(CancellationToken cancellationToken);
}
