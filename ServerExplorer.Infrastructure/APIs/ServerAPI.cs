using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerExplorer.Domain.Entities;
using ServerExplorer.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ServerExplorer.Infrastructure.ExternalAPIs
{
    public class ServerAPI : IServerAPI
    {
        private HttpClient _httpClient;

        public ServerAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Server>> GetServersAsync(string username, string password)
        {
            var token = await GetAuthorizationTokenAsync(username, password);
            if (token == null)
                return null;
            
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://playground.tesonet.lt/v1/servers");

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Server>>(json);
        }

        private async Task<string> GetAuthorizationTokenAsync(string username, string password)
        {
            var credentails = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            var content = new FormUrlEncodedContent(credentails);

            var response = await _httpClient.PostAsync("https://playground.tesonet.lt/v1/tokens", content);

            var json = await response.Content.ReadAsStringAsync();

            return (string) JsonConvert.DeserializeObject<JToken>(json)["token"];
        }
    }
}
