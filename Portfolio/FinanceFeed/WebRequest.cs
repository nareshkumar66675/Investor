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
    public class WebRequest
    {
        public NewsItem GetNewsByTicker(string ticker)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Constant.FeedURL);
            string urlParameter = string.Format(Constant.FeedParameter, ticker);

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameter).Result;  
            if (response.IsSuccessStatusCode)
            {

                var xmlFeed  = response.Content.ReadAsStringAsync().Result;

                var newsItem = GetLatestNewsItem(xmlFeed);

                return newsItem;
            }

            return null;
        }

        private NewsItem GetLatestNewsItem(string xmlFeed)
        {
            NewsItem newsItem = new NewsItem();

            XDocument xDocument = XDocument.Parse(xmlFeed);

            var latestItem = xDocument.Descendants("item").First();

            newsItem.PubDate = DateTime.Parse(latestItem.Descendants("pubDate").First().Value);
            newsItem.Link = latestItem.Descendants("link").First().Value;
            newsItem.Description = latestItem.Descendants("description").First().Value;
            newsItem.Title = latestItem.Descendants("title").First().Value;

            return newsItem;
        }
    }
}
