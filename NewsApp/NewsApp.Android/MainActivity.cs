
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Views;
using FFImageLoading.Forms.Platform;
using NewsApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace NewsApp.Droid
{
    [Activity(
        Label = "NewsApp",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = false,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            UserDialogs.Init(this);
            CachedImageRenderer.Init(enableFastRenderer: true);

            InitMessageCenterSubscriptions();
            RegisterPlatformDependencies();
            LoadApplication(new App());

            MakeStatusBarTranslucent(false);
        }

        private void InitMessageCenterSubscriptions()
        {
            MessagingCenter.Instance.Subscribe<StatusBarHelper, bool>(this, StatusBarHelper.TranslucentStatusChangeMessage, OnTranslucentStatusRequest);
        }

        private void OnTranslucentStatusRequest(StatusBarHelper helper, bool makeTranslucent)
        {
            MakeStatusBarTranslucent(makeTranslucent);
        }

        private void MakeStatusBarTranslucent(bool makeTranslucent)
        {
            if (makeTranslucent)
            {
                SetStatusBarColor(Android.Graphics.Color.Transparent);

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.LayoutFullscreen | SystemUiFlags.LayoutStable);
                }
            }
            else
            {
                using (var value = new TypedValue())
                {
                    if (Theme.ResolveAttribute(Resource.Attribute.colorPrimaryDark, value, true))
                    {
                        var color = new Android.Graphics.Color(value.Data);
                        SetStatusBarColor(color);
                    }
                }

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                }
            }
        }

        private static void RegisterPlatformDependencies()
        {

        }
    }
}

