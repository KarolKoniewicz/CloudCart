using Ebiscon.CloudCart.Domain.Abstractions;

namespace Ebiscon.CloudCart.Domain.Entities;

public class OrderProduct : IDomainEntity<Guid>
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }
}
