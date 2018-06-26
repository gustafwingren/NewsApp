using NewsApp.Services.Analytic;
using NewsApp.Services.Authentication;
using NewsApp.Utils;
using NewsApp.Validations;
using NewsApp.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private readonly IAnalyticService analyticService;
        private readonly IAuthenticationService authenticationService;

        private ValidatableObject<string> userName;
        private ValidatableObject<string> password;

        public LoginViewModel(
            IAnalyticService analyticService,
            IAuthenticationService authenticationService)
        {
            this.analyticService = analyticService;
            this.authenticationService = authenticationService;

            userName = new ValidatableObject<string>();
            password = new ValidatableObject<string>();

            AddValidations();
        }

        public ValidatableObject<string> UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<string> Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignInCommand => new Command(async () => await SignInAsync());

        public ICommand FacebookSignInCommand => new Command(async () => await FacebookSignInAsync());

        public async Task SignInAsync()
        {
            IsBusy = true;

            bool isValid = Validate();

            if (isValid)
            {
                await Task.Delay(1000);
                bool isAuth = false;

                if (isAuth)
                {
                    IsBusy = false;

                    analyticService.TrackEvent("SignIn");
                    await navigationService.NavigateToAsync<MainViewModel>();
                }
            }

            IsBusy = false;
        }

        public async Task FacebookSignInAsync()
        {
            try
            {
                IsBusy = true;

                await Task.Delay(1000);
                bool succeeded = false;

                if (succeeded)
                {
                    analyticService.TrackEvent("FacebookSignIn");
                    await navigationService.NavigateToAsync<MainViewModel>();
                }
            }
            catch(Exception)
            {
                await dialogService.ShowAlertAsync("An error occurred, try again", "Error", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void AddValidations()
        {
            userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Username should not be empty" });
            userName.Validations.Add(new EmailRule());
            password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password should not be empty" });
        }

        private bool Validate()
        {
            bool isValidUser = userName.Validate();
            bool isValidPassword = password.Validate();

            return isValidUser && isValidPassword;
        }
    }
}
