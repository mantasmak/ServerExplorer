using ServerExplorer.Domain.Entities;
using ServerExplorer.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
