using Ninject;
using ServerExplorer.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
