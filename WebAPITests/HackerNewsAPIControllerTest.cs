using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using hacker_news_webApplication;
using hacker_news_webApplication.Controllers;
using hacker_news_webApplication.Interfaces;
using hacker_news_webApplication.Services;
using Microsoft.Extensions.Caching.Memory;

namespace WebAPITests
{
    public class HackerNewsAPIControllerTest
    {
        private HackerNewsAPIController _controller;
        private MemoryCache _memCache;
        private HackerNewsService _service;

        public HackerNewsAPIControllerTest()
        {
            _memCache = new MemoryCache(new MemoryCacheOptions());
            _service = new HackerNewsService();
            _controller = new HackerNewsAPIController(_memCache, _service);
        }

        [Fact]
        public async void AssertTopStoriesReturned()
        {
            var response = await _controller.GetTopStories();
            Assert.True(response.Count > 0);
        }

        [Fact]
        public async void AssertIsHackerNewsStoryTest()
        {
            var response = await _controller.GetTopStories();
            Assert.IsType<HackerNewsStory>(response[0]);
        }
    }
}
