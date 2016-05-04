using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Platform;
using MvvmCross.WindowsCommon.Views;
using Newtonsoft.Json;
using Xamarin.Forms.Platform.WinRT;
using NavigationEventArgs = Windows.UI.Xaml.Navigation.NavigationEventArgs;

namespace MvvmCross.Forms.Presenter.WinRTPhone
{
    public abstract class MvxWindowsPhoneFormsPage : WindowsPhonePage
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var presenter = Mvx.Resolve<IMvxWindowsViewPresenter>() as MvxFormsPresenterProxy;
            if (presenter == null)
                throw new InvalidOperationException($"Your presenter has to be/inherit from {nameof(MvxFormsPresenterProxy)}");

            var formsPresenter = presenter.FormsViewPresenter;
            LoadApplication(formsPresenter.MvxFormsApp);

            var serializedViewModelRequest = e.Parameter as string;
            if (!string.IsNullOrEmpty(serializedViewModelRequest))
            {
                var viewModelRequest = JsonConvert.DeserializeObject<MvxViewModelRequest>(serializedViewModelRequest);
                presenter.Show(viewModelRequest);
            }
        }
    }
}
