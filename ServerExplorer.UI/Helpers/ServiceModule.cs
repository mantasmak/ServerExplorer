using Ninject.Modules;
using Serilog;
using ServerExplorer.Infrastructure.WebServices;
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
            Bind<IServerWebService>().To<ServerWebService>();
            Bind<HttpClient>().ToSelf().InSingletonScope();
            Bind<IServerRepository>().To<ServerRepository>();
            Bind<ServerExplorerContext>().ToSelf().InTransientScope();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt")
                .CreateLogger();
        }
    }
}
