using NewsApp.Models;
using System.Threading.Tasks;

namespace NewsApp.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IBrowserCookiesService _browserCookiesService;
        private readonly IAvatarUrlProvider _avatarProvider;

        public AuthenticationService(
            IBrowserCookiesService browserCookiesService,
            IAvatarUrlProvider avatarProvider)
        {
            _browserCookiesService = browserCookiesService;
            _avatarProvider = avatarProvider;
        }

        public bool IsAuthenticated => AppSettings.User != null;

        public User AuthenticatedUser => AppSettings.User;

        public async Task<bool> UserIsAuthenticatedAndValidAsync()
        {
            if (!IsAuthenticated)
            {
                return false;
            }
            else
            {
                bool refreshSucceded = false;

                return refreshSucceded;
            }
        }

        public async Task LogoutAsync()
        {
            AppSettings.RemoveUserData();
            await _browserCookiesService.ClearCookiesAsync();
        }
    }
}
