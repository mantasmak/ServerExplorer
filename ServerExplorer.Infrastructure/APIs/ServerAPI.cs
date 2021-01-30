using ServerExplorer.Domain.Entities;
using ServerExplorer.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServerExplorer.Infrastructure.ExternalAPIs
{
    class ServerAPI : IServerAPI
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<IEnumerable<Server>> GetServers(string username, string password)
        {
            var token = await GetAuthorizationToken(username, password);
            Console.WriteLine(token);
            return null;
        }

        private async Task<string> GetAuthorizationToken(string username, string password)
        {
            var credentails = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            var content = new FormUrlEncodedContent(credentails);

            var response = await client.PostAsync("https://playground.tesonet.lt/v1/tokens", content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
