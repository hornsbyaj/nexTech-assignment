using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using hacker_news_webApplication.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;


namespace hacker_news_webApplication.Repository
{
    public class HackerNewsRepository : IHackerNewsRepository
    {
        private IMemoryCache _memCache;

        public async Task<HackerNewsStory> GetStoriesAsync(int id)
        {
            return await _memCache.GetOrCreateAsync<HackerNewsStory>(id, async memCacheEntry =>
            {
                HackerNewsStory hackerNewsStory = new HackerNewsStory();

                //var response = await _newsService.GetStoryByIdAsync(id);
                //if (response.IsSuccessStatusCode)
                //{
                //    var storyResponse = response.Content.ReadAsStringAsync().Result;
                //    hackerNewsStory = JsonConvert.DeserializeObject<HackerNewsStory>(storyResponse);
                //}
                return hackerNewsStory;
            });
        }

    }
}
