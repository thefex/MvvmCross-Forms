using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace MvvmCross.Forms.Presenter.iOS
{
    public class MvxIosFormsPresenterProxy : MvxFormsPresenterProxy, IMvxIosViewPresenter
    {
        public MvxIosFormsPresenterProxy(IMvxViewPresenter classicMvxViewPresenter, MvxFormsPagePresenter formsViewPresenter) : base(classicMvxViewPresenter, formsViewPresenter)
        {
        }

        public bool PresentModalViewController(UIViewController controller, bool animated)
            => false; // TODO handle by clasic presenter

        public void NativeModalViewControllerDisappearedOnItsOwn()
        {
            // todo handle by classic presenter
        }
    }
}
