using NewsApp.Models;
using NewsApp.Services.Authentication;
using NewsApp.Services.OpenUri;
using NewsApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class MenuViewModel: ViewModelBase, IHandleViewAppearing, IHandleViewDisappearing
    {

        private ObservableCollection<Models.MenuItem> _menuItems;

        private readonly IAuthenticationService _authenticationService;
        private readonly IOpenUriService _openUrlService;

        public MenuViewModel(IAuthenticationService authenticationService, IOpenUriService openUrlService)
        {
            _authenticationService = authenticationService;
            _openUrlService = openUrlService;

            MenuItems = new ObservableCollection<Models.MenuItem>();

            InitMenuItems();
        }

        public string UserName => AppSettings.User?.Name;

        public string UserAvatar => AppSettings.User?.AvatarUrl;

        public ObservableCollection<Models.MenuItem> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand MenuItemSelectedCommand => new Command<Models.MenuItem>(OnSelectMenuItem);

        public Task OnViewAppearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }

        public Task OnViewDisappearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }

        private void InitMenuItems()
        {
            MenuItems.Add(new Models.MenuItem
            {
                Title = "Home",
                MenuItemType = MenuItemType.Home,
                ViewModelType = typeof(MainViewModel),
                IsEnabled = true
            });

            MenuItems.Add(new Models.MenuItem
            {
                Title = "Logout",
                MenuItemType = MenuItemType.Logout,
                ViewModelType = typeof(LoginViewModel),
                IsEnabled = true,
                AfterNavigationAction = RemoveUserCredentials
            });
        }

        private async void OnSelectMenuItem(Models.MenuItem item)
        {
            item.AfterNavigationAction?.Invoke();
            await navigationService.NavigateToAsync(item.ViewModelType, item);
        }

        private Task RemoveUserCredentials()
        {
            return _authenticationService.LogoutAsync();
        }

        private void SetMenuItemStatus(MenuItemType type, bool enabled)
        {
            Models.MenuItem menuItem = MenuItems.FirstOrDefault(m => m.MenuItemType == type);

            if (menuItem != null)
            {
                menuItem.IsEnabled = enabled;
            }
        }
    }
}
