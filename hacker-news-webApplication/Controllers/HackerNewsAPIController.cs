using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using hacker_news_webApplication.Services;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace hacker_news_webApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackerNewsAPIController : ControllerBase
    {
        private IMemoryCache _memCache;

        private readonly HackerNewsService _newsService;

        private HackerNewsAPIController(IMemoryCache cache, HackerNewsService newsService)
        {
            this._memCache = cache;
            this._newsService = newsService;
        }

        private async Task<HackerNewsStory> GetStoriesAsync(int id)
        {
            return await _memCache.GetOrCreateAsync(id, async memCacheEntry =>
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
                    || h.Author.ToLowerInvariant().IndexOf(word) > -1).ToList();
                }

            }

            return latestHackerNews;
        }

        //// GET: api/HackerNewsAPI
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/HackerNewsAPI/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/HackerNewsAPI
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/HackerNewsAPI/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
