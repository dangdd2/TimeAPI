using System.Configuration;

namespace TimeAPIClient.Helper
{
    public class RestSharpHelper
    {
        public static string ApiUrl
        {
            get { return ConfigurationManager.AppSettings["Url"]; }
        }

        public static string Client => "api/client/";
    }
}
