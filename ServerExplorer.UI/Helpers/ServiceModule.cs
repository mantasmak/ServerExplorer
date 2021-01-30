using Ninject.Modules;
using ServerExplorer.Infrastructure.ExternalAPIs;
using ServerExplorer.Infrastructure.Interfaces;
using ServerExplorer.Services.Interfaces;
using ServerExplorer.Services.Services;

namespace ServerExplorer.UI.Helpers
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IServerService>().To<ServerService>();
            Bind<IServerAPI>().To<ServerAPI>();
        }
    }
}
