using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;


namespace hacker_news_webApplication.Interfaces
{
    interface IHackerNewsRepository
    {
        Task<HackerNewsStory> GetStoriesAsync(int id);
    }
}
