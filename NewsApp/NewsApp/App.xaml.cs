using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using NewsApp.Services.Navigation;
using NewsApp.ViewModels;
using NewsApp.ViewModels.Base;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NewsApp
{
    public partial class App : Application
	{

        static App()
        {
            BuildDependencies();
        }

		public App ()
		{
            InitializeComponent();

            InitNavigation();
		}

        public static void BuildDependencies()
        {
            Locator.Instance.Build();
        }

        private Task InitNavigation()
        {
            var navigationService = Locator.Instance.Resolve<INavigationService>();
            return navigationService.NavigateToAsync<ExtendedSplashViewModel>();
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            AppCenter.Start("ios=e91522fa-c254-411c-84c5-78260662b33a;" +
                "android=a4eb9485-041c-40f5-9bda-2aa6f6f0654b",
                typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
