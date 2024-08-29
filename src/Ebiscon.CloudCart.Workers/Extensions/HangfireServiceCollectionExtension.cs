using Hangfire;
using Ebiscon.CloudCart.Workers.Base;
using Ebiscon.CloudCart.Workers.Workers.Base;
using Ebiscon.CloudCart.Workers.Workers.Interfaces;
using Ebiscon.CloudCart.Workers.Workers.Configurations;
using STI.Workers;

namespace Ebiscon.CloudCart.Domain.Extensions
{
    public static class HangfireServiceCollectionExtension
    {
        public static IServiceCollection AddWorkerConfiguration(this IServiceCollection services)
            => services.AddKeyedSingleton<IConfigurationOption, ProductSyncWorkerConfiguration>(nameof(ProductSyncWorkerConfiguration));

        public static IServiceCollection AddWorkerService(this IServiceCollection services)
            => services.AddKeyedTransient<IBaseWorker, ProductSyncWorker>(nameof(ProductSyncWorker));

        public static void ScheduleRecurringJob<TWorker, TConfiguration>(this IServiceProvider serviceProvider)
               where TWorker : BaseWorker<TConfiguration>, IBaseWorker
               where TConfiguration : IConfigurationOption
        {
            var configuration = serviceProvider.GetRequiredKeyedService<IConfigurationOption>(typeof(TConfiguration).Name);
            var worker = serviceProvider.GetRequiredKeyedService<IBaseWorker>(typeof(TWorker).Name);

            RecurringJob.AddOrUpdate<TWorker>(
                configuration.JobId,
                worker => worker.Run(new CancellationToken()),
                configuration.CronExpression);
        }
    }
}
