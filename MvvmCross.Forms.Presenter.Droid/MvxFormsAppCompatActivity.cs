using System;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using Xamarin.Forms.Platform.Android;

namespace MvvmCross.Forms.Presenter.Droid
{
    public abstract class MvxFormsAppCompatActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            var mvxFormsApp = new MvxFormsApp();
            LoadApplication(mvxFormsApp);

            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsPresenterProxy;
            if (presenter == null)
            {
                var errorMsg = $"To use MvvmCross with Forms you have to use {nameof(MvxFormsPresenterProxy)}";
                Mvx.Error(errorMsg);
                throw new InvalidOperationException(errorMsg);
            }

            var formsPresenter = presenter.FormsViewPresenter;
            if (formsPresenter == null)
            {
                var errorMsg =
                    $"To use MvvmCross with Android and Forms your {nameof(MvxFormsPresenterProxy)} have to use ${nameof(MvxFormsPagePresenter)} as Forms presenter.";
                Mvx.Error(errorMsg);
                throw new InvalidOperationException(errorMsg);
            }

            formsPresenter.MvxFormsApp = mvxFormsApp;

            // TODO: Forms specific MvxAppStart
            Mvx.Resolve<IMvxAppStart>().Start();
        }
    }
}