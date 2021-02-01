using ServerExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerExplorer.Infrastructure.Persistence
{
    public class ServerExplorerContext : DbContext
    {
        public DbSet<Server> Servers { get; set; }
    }
}
