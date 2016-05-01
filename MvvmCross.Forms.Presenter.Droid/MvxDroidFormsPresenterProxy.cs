// MvxDroidFormsPresenterProxy.cs
// 2015 (c) Copyright Cheesebaron. http://ostebaronen.dk
// MvvmCross.Forms.Presenter is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Tomasz Cielecki, @cheesebaron, mvxplugins@ostebaronen.dk
// Contributor - Marcos Cobeña Morián, @CobenaMarcos, marcoscm@me.com

using MvvmCross.Core.Views;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Presenter.Core;

namespace MvvmCross.Forms.Presenter.Droid
{
    public class MvxDroidFormsPresenterProxy
        : MvxFormsPresenterProxy
        , IMvxAndroidViewPresenter
    {
        public MvxDroidFormsPresenterProxy(IMvxViewPresenter classicMvxViewPresenter, MvxFormsPagePresenter formsViewPresenter) : base(classicMvxViewPresenter, formsViewPresenter)
        {
        }
    }

  
}
