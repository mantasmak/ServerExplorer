using ServerExplorer.Domain.Entities;
using ServerExplorer.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ServerExplorer.Infrastructure.Persistence.Repositories
{
    public class ServerRepository : Repository<Server>, IServerRepository
    {
        public ServerRepository(ServerExplorerContext context) : base(context) { }

        public IEnumerable<Server> GetAllOrderedByDescendingDistance()
        {
            return GetAll().OrderByDescending(server => server.Distance);
        }
    }
}
