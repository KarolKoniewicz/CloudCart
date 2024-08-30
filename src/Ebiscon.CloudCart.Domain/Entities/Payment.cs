using Ebiscon.CloudCart.Domain.Abstractions;

namespace Ebiscon.CloudCart.Domain.Entities
{
    public class Payment : IDomainEntity<long>
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public ApplicationUser User { get; set; }


        public Payment Create(ApplicationUser user)
         => new()
         {
             Id = GenerateRandomLong(new Random()),
             User = user,
             UserId = user.Id,
             CreatedOn = DateTimeOffset.Now,
             ModifiedOn = DateTimeOffset.Now,
         };

        private long GenerateRandomLong(Random random)
        {
            var buffer = new byte[8];
            random.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
