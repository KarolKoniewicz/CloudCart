namespace Ebiscon.CloudCart.Domain.Enums
{
    public enum PaymentType
    {
        None = 0,
        Credit = 1,
    }

    public enum PaymentStatus
    {
        None = 0,
        Unpaid = 1,
        Refunded = 2,
        Paid = 3
    }
}
