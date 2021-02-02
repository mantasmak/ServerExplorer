using ServerExplorer.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerExplorer.Infrastructure.Interfaces
{
    public interface IServerWebService
    {
        Task<IEnumerable<Server>> GetServersAsync(string username, string password);
    }
}
