using IntegrationSample.ViewModels;
using MvvmCross.Core.ViewModels;

namespace IntegrationSample
{
    public class IntegrationSampleMvxApp : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<MainViewModel>();
        }
    }
}
