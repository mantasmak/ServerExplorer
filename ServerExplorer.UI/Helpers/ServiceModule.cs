using Ninject.Modules;
using ServerExplorer.Infrastructure.ExternalAPIs;
using ServerExplorer.Infrastructure.Interfaces;
using ServerExplorer.Infrastructure.Persistence;
using ServerExplorer.Infrastructure.Persistence.Repositories;
using ServerExplorer.Services.Interfaces;
using ServerExplorer.Services.Services;
using System.Net.Http;

namespace ServerExplorer.UI.Helpers
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IServerService>().To<ServerService>();
            Bind<IServerAPI>().To<ServerAPI>();
            Bind<HttpClient>().ToSelf().InSingletonScope();
            Bind<IServerRepository>().To<ServerRepository>();
            Bind<ServerExplorerContext>().ToSelf().InTransientScope();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>)); 
        }
    }
}
