using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core.Attribute;

namespace IntegrationSample.ViewModels
{
    [MvxAssociatedViewType(MvxViewType.Forms)]
    public class MainViewModel : MvxViewModel
    {
        private string _yourNickname = string.Empty;

        public string YourNickname
        {
            get { return _yourNickname; }
            set
            {
                if (SetProperty(ref _yourNickname, value))
                    RaisePropertyChanged(() => Hello);
            }
        }

        public string Hello => "Hello " + YourNickname;


        public ICommand ShowAboutPageCommand => new MvxCommand(() => ShowViewModel<AboutViewModel>());
    }
}