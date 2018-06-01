using NewsApp.Models;
using System.Threading.Tasks;

namespace NewsApp.Services.Authentication
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }

        User AuthenticatedUser { get; }

        Task<bool> UserIsAuthenticatedAndValidAsync();

        Task LogoutAsync();
    }
}
