using ServerExplorer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServerExplorer.Domain.Entities;
using ServerExplorer.Infrastructure.Interfaces;
using System.Linq;

namespace ServerExplorer.Services.Services
{
    public class ServerService : IServerService
    {
        IServerAPI _serverAPI;
        IServerRepository _serverRepository;

        public ServerService(IServerAPI serverAPI, IServerRepository serverRepository)
        {
            _serverAPI = serverAPI;
            _serverRepository = serverRepository;
        }

        public async Task<bool> UpdateDatabase(string username, string password)
        {
            var servers = await _serverAPI.GetServersAsync(username, password);
            if (servers == null || !servers.Any())
                return false;

            foreach (var server in servers)
                _serverRepository.Insert(server);

            return true;
        }

        public IEnumerable<Server> GetServers()
        {
            var servers = _serverRepository.GetAllOrderedByDescendingDistance();
            if (servers == null)
                return null;

            return servers;
        }
    }
}
