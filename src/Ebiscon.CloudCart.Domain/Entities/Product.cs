using Ebiscon.CloudCart.Domain.Abstractions;

namespace Ebiscon.CloudCart.Domain.Entities;

public class Product : IDomainEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }
}
