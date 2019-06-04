using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
