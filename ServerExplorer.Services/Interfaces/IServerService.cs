using ServerExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerExplorer.Services.Interfaces
{
    public interface IServerService
    {
        Task<bool> UpdateDatabase(string username, string password);
        IEnumerable<Server> GetServers();
    }
}
