using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ninject.Extensions.Logging;
using ServerExplorer.Domain.Entities;
using ServerExplorer.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ServerExplorer.Infrastructure.WebServices
{
    public class ServerWebService : IServerWebService
    {
        private readonly string _authTokenLink = "https://playground.tesonet.lt/v1/tokens";
        private readonly string _serverListLink = "https://playground.tesonet.lt/v1/servers";
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public ServerWebService(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<Server>> GetServersAsync(string username, string password)
        {
            var token = await GetAuthorizationTokenAsync(username, password);
            if (token == null)
            {
                _logger.Warn("Authentification failed");
                return null;
            }

            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, _serverListLink);

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.SendAsync(requestMessage);

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<Server>>(json);
            }
            catch (HttpRequestException e)
            {
                _logger.Error(e, "GET request failed");
                throw;
            }
        }

        private async Task<string> GetAuthorizationTokenAsync(string username, string password)
        {
            try
            {
                var credentails = new Dictionary<string, string>
                {
                    { "username", username },
                    { "password", password }
                };

                var content = new FormUrlEncodedContent(credentails);

                var response = await _httpClient.PostAsync(_authTokenLink, content);

                var json = await response.Content.ReadAsStringAsync();

                return (string) JsonConvert.DeserializeObject<JToken>(json)["token"];
            }
            catch (HttpRequestException e)
            {
                _logger.Error(e, "POST request failed");
                throw;
            }
        }
    }
}
