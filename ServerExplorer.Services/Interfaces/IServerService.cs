using ServerExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerExplorer.Services.Interfaces
{
    interface IServerService
    {
        IEnumerable<Server> GetServerList();
    }
}
