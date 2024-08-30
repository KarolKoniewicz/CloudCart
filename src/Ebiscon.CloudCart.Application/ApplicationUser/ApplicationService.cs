using Ebiscon.CloudCart.Application.Abstractions.Services;
using Ebiscon.CloudCart.Domain.Abstractions;

namespace Ebiscon.CloudCart.Application.ApplicationUser
{
    public class ApplicationService : IApplicationUserService
    {
        private readonly IApplicationUserRepository applicationUserRepository;

        public ApplicationService(IApplicationUserRepository applicationUserRepository)
        {
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task<Domain.Entities.ApplicationUser> GetApplicationUserById(string userId, CancellationToken cancellationToken)
            => await applicationUserRepository.GetApplicationUserById(userId, cancellationToken);
    }
}
