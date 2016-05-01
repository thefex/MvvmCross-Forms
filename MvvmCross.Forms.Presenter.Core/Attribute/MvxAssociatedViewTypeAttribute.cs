namespace MvvmCross.Forms.Presenter.Core.Attribute
{
    public class MvxAssociatedViewTypeAttribute : System.Attribute
    {
        public MvxViewType ViewType { get; }

        public MvxAssociatedViewTypeAttribute(MvxViewType viewType)
        {
            ViewType = viewType;
        }
    }
}
