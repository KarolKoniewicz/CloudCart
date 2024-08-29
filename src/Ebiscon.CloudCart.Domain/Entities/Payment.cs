using Ebiscon.CloudCart.Domain.Abstractions;

namespace Ebiscon.CloudCart.Domain.Entities
{
    public class Payment : IDomainEntity<long>
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public ApplicationUser User { get; set; }
    }

}
