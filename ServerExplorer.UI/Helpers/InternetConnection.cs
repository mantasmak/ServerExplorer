using Ninject.Extensions.Logging;
using System.Net;

namespace ServerExplorer.UI.Helpers
{
    static class InternetConnection
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
