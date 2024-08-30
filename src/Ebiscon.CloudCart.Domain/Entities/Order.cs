using Ebiscon.CloudCart.Domain.Abstractions;

namespace Ebiscon.CloudCart.Domain.Entities
{
    public class Order : IDomainEntity<Guid>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ApplicationUser User { get; set; }

        public Order Create(ApplicationUser user)
            => new()
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTimeOffset.UtcNow,
                ModifiedOn = DateTimeOffset.UtcNow,
                User = user,
                UserId = user.Id,
            };
    }

}
