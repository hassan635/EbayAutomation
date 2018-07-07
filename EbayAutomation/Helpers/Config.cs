using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EbayAutomation.Helpers
{
    public static class Config
    {
        public static string baseUrl => ConfigurationManager.AppSettings["BaseUrl"].ToString();
        public static string Username => ConfigurationManager.AppSettings["Username"].ToString();
        public static string Password => ConfigurationManager.AppSettings["Password"].ToString();
    }
}
