namespace Ebiscon.CloudCart.Workers.Base
{
    public interface IBaseWorker
    {
        Task Run(CancellationToken cancellationToken);
    }
}
