using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using IntegrationSample.ViewModels;
using MvvmCross.Droid.Views;

namespace IntegrationSample.Droid
{
    [Activity(Label = "Feedback", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class FeedbackActivity : MvxActivity<FeedbackViewModel>
    {
        public FeedbackActivity()
        {
                
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.FeedbackLayout);
        }
    }
}