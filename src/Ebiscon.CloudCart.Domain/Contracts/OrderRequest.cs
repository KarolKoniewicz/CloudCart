using Ebiscon.CloudCart.Domain.Entities;

namespace Ebiscon.CloudCart.Domain.Contracts;

public class OrderRequest
{
    public string UserId { get; set; }
    public List<Guid> ProductIds { get; set; }
}
