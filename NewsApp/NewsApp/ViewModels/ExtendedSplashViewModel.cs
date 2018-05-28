using NewsApp.ViewModels.Base;
using System.Threading.Tasks;

namespace NewsApp.ViewModels
{
    public class ExtendedSplashViewModel : ViewModelBase
    {
        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            await navigationService.InitializeAsync();

            IsBusy = false;
        }
    }
}
