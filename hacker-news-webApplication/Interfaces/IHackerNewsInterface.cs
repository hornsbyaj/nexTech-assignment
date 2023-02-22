using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace hacker_news_webApplication.Interfaces
{
    public interface IHackerNewsInterface
    {
        Task<HttpResponseMessage> GetStoryByIdAsync(int id);
        Task<HttpResponseMessage> LatestStoriesAsync();
    }
}
