using System.Linq;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Core.Attribute;
using MvvmCross.Platform;

namespace MvvmCross.Forms.Presenter.Core
{
    public class MvxFormsPresenterProxy : MvxViewPresenter
    {
        public readonly IMvxViewPresenter ClassicMvxViewPresenter;
        public readonly MvxFormsPagePresenter FormsViewPresenter;

        public MvxFormsPresenterProxy(IMvxViewPresenter classicMvxViewPresenter, MvxFormsPagePresenter formsViewPresenter)
        {
            ClassicMvxViewPresenter = classicMvxViewPresenter;
            FormsViewPresenter = formsViewPresenter;
        }

        public override void Show(MvxViewModelRequest request)
        {
            var mvxViewType = GetViewType(request);
            switch (mvxViewType)
            {
                case MvxViewType.Forms:
                    FormsViewPresenter.Show(request);
                    break;
                case MvxViewType.Classic:
                    ClassicMvxViewPresenter.Show(request);
                    break;
            }
        }


        public override void ChangePresentation(MvxPresentationHint hint)
        {
            // TODO: At this moment only Classic ViewModels support change presentation
            ClassicMvxViewPresenter.ChangePresentation(hint);
        }

        protected virtual MvxViewType GetViewType(MvxViewModelRequest fromViewModelRequest)
        {
            var mvxAssociatedViewTypeAttribute =
                fromViewModelRequest.ViewModelType.GetCustomAttributes(typeof(MvxAssociatedViewTypeAttribute), false)
                    .Cast<MvxAssociatedViewTypeAttribute>()
                    .SingleOrDefault();

            return mvxAssociatedViewTypeAttribute?.ViewType ?? MvxViewType.Forms;
        }
        
    }
}
