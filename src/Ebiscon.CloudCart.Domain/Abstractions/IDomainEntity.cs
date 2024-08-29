namespace Ebiscon.CloudCart.Domain.Abstractions
{
    public interface IDomainEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }

}
