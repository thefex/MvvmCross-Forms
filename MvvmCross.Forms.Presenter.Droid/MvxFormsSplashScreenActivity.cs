using Android.OS;
using MvvmCross.Droid.Views;

namespace MvvmCross.Forms.Presenter.Droid
{
    public abstract class MvxFormsSplashScreenActivity : MvxSplashScreenActivity
    {
        protected MvxFormsSplashScreenActivity(int resourceId = 0) : base(resourceId)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            Xamarin.Forms.Forms.Init(this, bundle);
            // Leverage controls' StyleId attrib. to Xamarin.UITest
            Xamarin.Forms.Forms.ViewInitialized += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.View.StyleId))
                {
                    e.NativeView.ContentDescription = e.View.StyleId;
                }
            };

            base.OnCreate(bundle);
        }
    }
}