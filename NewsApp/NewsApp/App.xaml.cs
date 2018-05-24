using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace NewsApp
{
	public partial class App : Application
	{
        static App()
        {

        }

		public App ()
		{
			InitializeComponent();

            AppCenter.Start("ios=e91522fa-c254-411c-84c5-78260662b33a;" +
                "android=a4eb9485-041c-40f5-9bda-2aa6f6f0654b", 
                typeof(Analytics), typeof(Crashes));

			MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
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
