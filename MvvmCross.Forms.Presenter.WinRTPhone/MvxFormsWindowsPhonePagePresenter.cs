using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.WindowsCommon.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MvvmCross.Forms.Presenter.WinRTPhone
{
    public class MvxFormsWindowsPhonePagePresenter
        : MvxFormsPagePresenter
            , IMvxWindowsViewPresenter
    {
        private readonly Type _mvxFormsPageType;
        private readonly IMvxWindowsFrame _rootFrame;

        public MvxFormsWindowsPhonePagePresenter(Type mvxFormsPageType, IMvxWindowsFrame rootFrame,
            Application mvxFormsApp)
            : base(mvxFormsApp)
        {
            _mvxFormsPageType = mvxFormsPageType;
            _rootFrame = rootFrame;
        }

        protected override bool IsNativeFormPageActive()
            => _rootFrame.Content is MvxWindowsPhoneFormsPage;

        protected override void NavigateToNativeFormPage(MvxViewModelRequest withViewModelRequest)
            => _rootFrame.Navigate(_mvxFormsPageType, JsonConvert.SerializeObject(withViewModelRequest));
    }
}