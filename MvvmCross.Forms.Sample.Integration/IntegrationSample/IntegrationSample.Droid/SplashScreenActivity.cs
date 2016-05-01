using Android.App;
using Android.Content.PM;
using MvvmCross.Forms.Presenter.Droid;

namespace IntegrationSample.Droid
{
    [Activity(
       Label = "Example.Droid"
       , MainLauncher = true
       , Icon = "@drawable/icon"
       , NoHistory = true
       , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : MvxFormsSplashScreenActivity
    {
        public SplashScreenActivity() : base(Resource.Layout.SplashScreen)
        {
        }
    }
}