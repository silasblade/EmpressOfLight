using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using HtmlAgilityPack;
using EmpressOfLight.Models;

namespace EmpressOfLight.Services
{
    public class RSSFeedService
    {
        private readonly HttpClient _httpClient;

        public RSSFeedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RSSFeed>> GetRssFeedAsync(string rssUrl)
        {
            var response = await _httpClient.GetStringAsync(rssUrl);
            var xDocument = XDocument.Parse(response);

            return xDocument.Descendants("item").Select(item => new RSSFeed
            {
                Title = item.Element("title")?.Value,
                Link = item.Element("link")?.Value,
                PubDate = DateTime.Parse(item.Element("pubDate")?.Value ?? DateTime.MinValue.ToString()),
                Description = item.Element("description")?.Value,
                ImageUrl = GetImageUrlFromDescription(item.Element("description")?.Value)
            }).ToList();
        }

        private string GetImageUrlFromDescription(string description)
        {
            if (string.IsNullOrEmpty(description)) return null;

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(description);
            var imgNode = htmlDoc.DocumentNode.SelectSingleNode("//img");
            return imgNode?.GetAttributeValue("src", null);
        }
    }
}