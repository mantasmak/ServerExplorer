using Ninject;
using ServerExplorer.UI.ViewModels;

namespace ServerExplorer.UI.Helpers
{
    public class ServiceLocator
    {
        private readonly IKernel kernel;

        public MainWindowViewModel MainWindowViewModel
        {
            get { return kernel.Get<MainWindowViewModel>(); }
        }

        public ServiceLocator()
        {
            kernel = new StandardKernel(new ServiceModule());
        }
    }
}
