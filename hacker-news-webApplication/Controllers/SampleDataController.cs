using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hacker_news_webApplication.Services;
using Newtonsoft.Json;


namespace hacker_news_webApplication.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private HackerNewsService _newsService = new HackerNewsService();

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        private async Task<HackerNewsStory> GetStoriesAsync(int id)
        {
            HackerNewsStory hackerNewsStory = new HackerNewsStory();

            var response = await _newsService.GetStoryByIdAsync(id);
            if (response.IsSuccessStatusCode)
            {
                var storyResponse = response.Content.ReadAsStringAsync().Result;
                hackerNewsStory = JsonConvert.DeserializeObject<HackerNewsStory>(storyResponse);
            }
            return hackerNewsStory;
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


        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
