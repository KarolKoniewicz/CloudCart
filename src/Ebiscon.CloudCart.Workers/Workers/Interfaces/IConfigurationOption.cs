namespace Ebiscon.CloudCart.Workers.Workers.Interfaces;

public interface IConfigurationOption
{
    public string JobId { get; set; }
    public string CronExpression { get; }
    public bool Enabled { get; set; }
}
