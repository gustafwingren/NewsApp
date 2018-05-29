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

        public Task<bool> LoginAsync(string email, string password)
        {
        }
        public async Task<bool> LoginWithFacebookAsync()
        {
        }

        public async Task<bool> UserIsAuthenticatedAndValidAsync()
        {
        }

        public async Task LogoutAsync()
        {
            AppSettings.RemoveUserData();
            await _browserCookiesService.ClearCookiesAsync();
        }

        private void SaveAuthenticationResult(AuthenticationResult result)
        {
            User user = AuthenticationResultHelper.GetUserFromResult(result);
            user.AvatarUrl = _avatarProvider.GetAvatarUrl(user.Email);
            AppSettings.User = user;
        }
    }
}
