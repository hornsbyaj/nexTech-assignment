using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using hacker_news_webApplication.Interfaces;

namespace hacker_news_webApplication.Services
{
    public class HackerNewsService : IHackerNewsInterface
    {
        private static HttpClient client = new HttpClient();

        public HackerNewsService()
        { }

        public async Task<HttpResponseMessage> GetStoryByIdAsync(int id)
        {
            return await client.GetAsync(string.Format("https://hacker-news.firebaseio.com/v0/item/{0}.json?print=pretty", id));
        }

        public async Task<HttpResponseMessage> LatestStoriesAsync()
        {
            return await client.GetAsync("https://hacker-news.firebaseio.com/v0/beststories.json?print=pretty");
        }
    }
}
