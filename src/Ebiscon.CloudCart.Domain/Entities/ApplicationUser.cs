using Microsoft.AspNetCore.Identity;
using Ebiscon.CloudCart.Domain.Abstractions;

namespace Ebiscon.CloudCart.Domain.Entities;

public class ApplicationUser : IdentityUser<string>, IDomainEntity<string>
{
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }

    public ICollection<Order> Orders { get; set; }
    public ICollection<Payment> Payments { get; set; }
}

