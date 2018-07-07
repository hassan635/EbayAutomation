using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EbayAutomation.Helpers
{
    public static class HttpRequestDispatcher
    {
        public static HttpWebResponse Perform(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;

                request.ContentType = "application/json";
                request.Method = "GET";
                return request.GetResponse() as HttpWebResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
