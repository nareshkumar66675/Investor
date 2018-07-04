using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFeed
{
    public class WebRequest
    {
        public string GetNewsByTicker(string ticker)
        {
            string result = string.Empty;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://feeds.finance.yahoo.com/rss/2.0/headline");
            string urlParameters = $"?s=a";

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                //var dataObjects = response.Content.ReadAsAsync<RSS>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll

                //result  = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return result;
        }
    }
}
