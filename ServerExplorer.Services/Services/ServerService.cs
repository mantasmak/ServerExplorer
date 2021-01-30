using ServerExplorer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerExplorer.Domain.Entities;
using ServerExplorer.Infrastructure.Interfaces;

namespace ServerExplorer.Services.Services
{
    public class ServerService : IServerService
    {
        IServerAPI _serverAPI;

        public ServerService(IServerAPI serverAPI)
        {
            _serverAPI = serverAPI;
        }

        public IEnumerable<Server> GetServerList()
        {
            _serverAPI.GetServers("", "");

            return null;
        }
    }
}
