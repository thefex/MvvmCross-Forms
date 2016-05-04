using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.WindowsCommon.Views;

namespace MvvmCross.Forms.Presenter.WinRTPhone
{
    public class MvxWindowsFormsPresenterProxy : MvxFormsPresenterProxy
        , IMvxWindowsViewPresenter
    {
        public MvxWindowsFormsPresenterProxy(IMvxViewPresenter classicMvxViewPresenter, MvxFormsPagePresenter formsViewPresenter) : base(classicMvxViewPresenter, formsViewPresenter)
        {
        }
    }
}
