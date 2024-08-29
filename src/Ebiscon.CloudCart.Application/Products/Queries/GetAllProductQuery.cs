using Ebiscon.CloudCart.Application.Products.Contracts;
using Ebiscon.CloudCart.Application.Abstractions.Messaging;

namespace Ebiscon.CloudCart.Application.Products.Queries;

public sealed record GetAllProductQuery() : IQuery<ProductResponse>;
