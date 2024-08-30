using Ebiscon.CloudCart.Database;
using Microsoft.EntityFrameworkCore;
using Ebiscon.CloudCart.Domain.Entities;
using Ebiscon.CloudCart.Domain.Abstractions;

namespace Ebiscon.CloudCart.Infrastructure.Repositories;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly ApplicationDbContext context;

    public ApplicationUserRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<ApplicationUser> GetApplicationUserById(string userId, CancellationToken cancellationToken)
        => await context.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
}