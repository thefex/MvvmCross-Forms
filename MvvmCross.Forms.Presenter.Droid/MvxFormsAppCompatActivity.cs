using System;
using Android.App;
using Android.Content;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Views;
using Newtonsoft.Json;
using Xamarin.Forms.Platform.Android;

namespace MvvmCross.Forms.Presenter.Droid
{
    public abstract class MvxFormsAppCompatActivity : FormsAppCompatActivity
    {
        // thefex notes in comments

        // TODO: LOGIC EXCEPT OnCreate should be refactored into something like Native MvxEventSource..Activity
        // MvxForms..Activity should be a bridge between Forms and Classic Xamarin world
        protected MvxFormsAppCompatActivity()
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            // TODO ENSURE SETUP OF MVVMCROSS DONE
            OnLifeTimeEvent((listener, activity) => listener.OnCreate(activity));

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

           
            if (Intent?.Extras != null && Intent.Extras.ContainsKey(MvxDroidFormsPagePresenter.FirstNavigationRequestPackageExtraKey))
            {
                var jsonViewModelRequest = Intent.Extras.GetString(MvxDroidFormsPagePresenter.FirstNavigationRequestPackageExtraKey) as string;
                var viewModelRequest = JsonConvert.DeserializeObject<MvxViewModelRequest>(jsonViewModelRequest);
                formsPresenter.Show(viewModelRequest);
            }
        }


        // TODO: REFACTOR IMVXANDROIDVIEW INTO FEW INTERFACES
        // TODO: SO LIFE TIME EVENTS CAN BE USED Like in EventSource activities

        protected override void OnDestroy()
        {
            OnLifeTimeEvent((listener, activity) => listener.OnDestroy(activity));
            base.OnDestroy();
        }

 

        protected override void OnResume()
        {
            base.OnResume();
            OnLifeTimeEvent((listener, activity) => listener.OnResume(activity));
        }

        protected override void OnPause()
        {
            OnLifeTimeEvent((listener, activity) => listener.OnPause(activity));
            base.OnPause();
        }

        protected override void OnStart()
        {
            base.OnStart();
            OnLifeTimeEvent((listener, activity) => listener.OnStart(activity));
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            OnLifeTimeEvent((listener, activity) => listener.OnRestart(activity)); 
        }

        protected override void OnStop()
        {
            OnLifeTimeEvent((listener, activity) => listener.OnStop(activity));
            base.OnStop();
        }

        private void OnLifeTimeEvent(Action<IMvxAndroidActivityLifetimeListener, Activity> report)
        {
            var activityTracker = Mvx.Resolve<IMvxAndroidActivityLifetimeListener>();
            report(activityTracker, this);
        }
    }
}