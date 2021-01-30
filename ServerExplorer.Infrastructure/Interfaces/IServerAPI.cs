using ServerExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerExplorer.Infrastructure.Interfaces
{
    public interface IServerAPI
    {
        Task<IEnumerable<Server>> GetServers(string username, string password);
    }
}
