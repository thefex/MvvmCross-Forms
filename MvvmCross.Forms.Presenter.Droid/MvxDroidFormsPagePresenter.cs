using System;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Newtonsoft.Json;

namespace MvvmCross.Forms.Presenter.Droid
{
    public class MvxDroidFormsPagePresenter : MvxFormsPagePresenter, IMvxAndroidViewPresenter
    {
        private readonly Type _formsAppCompatActivityType;
        public static readonly string FirstNavigationRequestPackageExtraKey = "FirstNavigationRequestPackageKey";


        public MvxDroidFormsPagePresenter(Type formsAppCompatActivityType) : base()
        {
            _formsAppCompatActivityType = formsAppCompatActivityType;

            if (!typeof(MvxFormsAppCompatActivity).IsAssignableFrom(_formsAppCompatActivityType))
                throw new InvalidOperationException($"Passed type should inherit from {nameof(MvxFormsAppCompatActivity)}");
        }

        public MvxDroidFormsPagePresenter(Type formsAppCompatActivityType, Xamarin.Forms.Application mvxFormsApp) : base(mvxFormsApp)
        {
            _formsAppCompatActivityType = formsAppCompatActivityType;

            if (!typeof(MvxFormsAppCompatActivity).IsAssignableFrom(_formsAppCompatActivityType))
                throw new InvalidOperationException($"Passed type should inherit from {nameof(MvxFormsAppCompatActivity)}");
        }

        protected override bool IsNativeFormPageActive()
        {
            Type baseDroidFormPage = typeof(MvxFormsAppCompatActivity);
            Type currentActivityType = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity.GetType();

            return baseDroidFormPage.IsAssignableFrom(currentActivityType);
        }

        protected override void NavigateToNativeFormPage(MvxViewModelRequest withViewModelRequest)
        {
            var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            var requestText = JsonConvert.SerializeObject(withViewModelRequest);
            var intent = new Intent(currentActivity, _formsAppCompatActivityType);
            intent.PutExtra(FirstNavigationRequestPackageExtraKey, requestText);

            currentActivity.StartActivity(intent);
        }


         
    }
}