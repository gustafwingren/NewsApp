using NewsApp.Services.Dialog;
using NewsApp.Services.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewsApp.ViewModels.Base
{
    public abstract class ViewModelBase : BindableObject
    {
        private bool _isBusy;

        protected readonly IDialogService dialogService;
        protected readonly INavigationService navigationService;

        public ViewModelBase()
        {
            dialogService = Locator.Instance.Resolve<IDialogService>();
            navigationService = Locator.Instance.Resolve<INavigationService>();
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
