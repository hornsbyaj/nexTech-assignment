using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using hacker_news_webApplication.Interfaces;

namespace hacker_news_webApplication.Controllers
{
    [Route("api/[controller]")]
    public class HackerNewsAPIController : Controller
    {
        private IHackerNewsService _newsService;
        private IMemoryCache _memCache;

        public HackerNewsAPIController(IMemoryCache memCache, IHackerNewsService newsService)
        {
            _newsService = newsService;
            _memCache = memCache;
        }

        private async Task<HackerNewsStory> GetStoriesAsync(int id)
        {
            return await _memCache.GetOrCreateAsync<HackerNewsStory>(id, async memCacheEntry =>
            {
                HackerNewsStory hackerNewsStory = new HackerNewsStory();

                var response = await _newsService.GetStoryByIdAsync(id);
                if (response.IsSuccessStatusCode)
                {
                    var storyResponse = response.Content.ReadAsStringAsync().Result;
                    hackerNewsStory = JsonConvert.DeserializeObject<HackerNewsStory>(storyResponse);
                }
                return hackerNewsStory;
            });
        }

        // GET: api/HackerNewsAPI
        [HttpGet("[action]")]
        public async Task<List<HackerNewsStory>> NewsFeed(string wordSearched)
        {
            List<HackerNewsStory> latestHackerNews = new List<HackerNewsStory>();

            var response = await _newsService.TopStoriesAsync();
            if (response.IsSuccessStatusCode)
            {
                var storyResponse = response.Content.ReadAsStringAsync().Result;
                var topIds = JsonConvert.DeserializeObject<List<int>>(storyResponse);
                var tasks = topIds.Select(GetStoriesAsync);
                latestHackerNews = (await Task.WhenAll(tasks)).ToList();

                if (!String.IsNullOrEmpty(wordSearched))
                {
                    var word = wordSearched.ToLowerInvariant();
                    latestHackerNews = latestHackerNews.Where(h => h.Title.ToLowerInvariant().IndexOf(word) > -1
                    || h.By.ToLowerInvariant().IndexOf(word) > -1).ToList();
                }
            }
            return latestHackerNews;
        }
    }
}
