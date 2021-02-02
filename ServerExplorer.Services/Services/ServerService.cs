using ServerExplorer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServerExplorer.Domain.Entities;
using ServerExplorer.Infrastructure.Interfaces;
using System.Linq;
using Ninject.Extensions.Logging;

namespace ServerExplorer.Services.Services
{
    public class ServerService : IServerService
    {
        private readonly IServerWebService _serverWebService;
        private readonly IServerRepository _serverRepository;
        private readonly ILogger _logger;

        public ServerService(IServerWebService serverWebService, IServerRepository serverRepository, ILogger logger)
        {
            _serverWebService = serverWebService;
            _serverRepository = serverRepository;
            _logger = logger;
        }

        public async Task<bool> UpdateDatabaseAsync(string username, string password)
        {
            var servers = await _serverWebService.GetServersAsync(username, password);
            if (servers == null || !servers.Any())
                return false;

            foreach (var server in servers)
                _serverRepository.Insert(server);

            return true;
        }

        public IEnumerable<Server> GetServers()
        {
            var servers = _serverRepository.GetAllOrderedByDescendingDistance();
            if (servers == null || !servers.Any())
            {
                _logger.Warn("Attempt to get data from empty database table");
                return null;
            }

            return servers;
        }
    }
}
