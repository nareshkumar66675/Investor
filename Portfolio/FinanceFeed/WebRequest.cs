using Portfolio.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Portfolio.FinanceFeed
{
    /// <summary>
    /// Used To send a Web Request for News Feed
    /// </summary>
    public class WebRequest
    {
        /// <summary>
        /// Get Latest News by Ticker
        /// </summary>
        /// <param name="ticker">Ticker</param>
        /// <returns>Latest New Item</returns>
        public NewsItem GetNewsByTicker(string ticker)
        {

            HttpClient client = new HttpClient();

            // Set the URL of webservice
            client.BaseAddress = new Uri(Constant.FeedURL);
            string urlParameter = string.Format(Constant.FeedParameter, ticker);


            // Send the Request
            HttpResponseMessage response = client.GetAsync(urlParameter).Result;  
            if (response.IsSuccessStatusCode)
            {
                // Result XML Data
                var xmlFeed  = response.Content.ReadAsStringAsync().Result;

                // Parse XML and get the latest news
                var newsItem = GetLatestNewsItem(xmlFeed);

                return newsItem;
            }

            return null;
        }

        /// <summary>
        /// Parses XML and returns latest news item
        /// </summary>
        /// <param name="xmlFeed">Full XML Document</param>
        /// <returns>Latest News Item</returns>
        private NewsItem GetLatestNewsItem(string xmlFeed)
        {
            NewsItem newsItem = new NewsItem();

            // Convert XML String to Object
            XDocument xDocument = XDocument.Parse(xmlFeed);

            // Find the first Element with name 'item'
            var latestItem = xDocument.Descendants("item").First();

            //From 'item' - retrieve all necessary informations
            newsItem.PubDate = DateTime.Parse(latestItem.Descendants("pubDate").First().Value);
            newsItem.Link = latestItem.Descendants("link").First().Value;
            newsItem.Description = latestItem.Descendants("description").First().Value;
            newsItem.Title = latestItem.Descendants("title").First().Value;

            return newsItem;
        }
    }
}
