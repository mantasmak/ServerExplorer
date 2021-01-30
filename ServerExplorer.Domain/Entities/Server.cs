using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerExplorer.Domain.Entities
{
    public class Server
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }
    }
}
