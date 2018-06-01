using NewsApp.Services.Authentication;
using NewsApp.ViewModels.Base;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class HomeViewModel : ViewModelBase, IHandleViewAppearing, IHandleViewDisappearing
    {
        private readonly IAuthenticationService authenticationService;
        public HomeViewModel(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public Task OnViewAppearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }

        public Task OnViewDisappearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }
    }
}
