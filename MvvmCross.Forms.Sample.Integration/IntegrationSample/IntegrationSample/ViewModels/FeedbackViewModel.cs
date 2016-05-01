using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core.Attribute;

namespace IntegrationSample.ViewModels
{
    [MvxAssociatedViewType(MvxViewType.Classic)]
    public class FeedbackViewModel : MvxViewModel
    {
        public string Info => "I didn't have time to implement this native view.";
    }
}
