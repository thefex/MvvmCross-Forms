using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Forms.Presenter.Droid;
using MvvmCross.Platform;

namespace IntegrationSample.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
            => new IntegrationSampleMvxApp();
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var baseAndroidPresenter = base.CreateViewPresenter();

            var presenter = new MvxDroidFormsPresenterProxy(baseAndroidPresenter, new MvxDroidFormsPagePresenter(typeof(MainActivity)));
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }
    }
}