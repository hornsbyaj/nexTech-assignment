using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hacker_news_webApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackerNewsAPIController : ControllerBase
    {
        // GET: api/HackerNewsAPI
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HackerNewsAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HackerNewsAPI
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/HackerNewsAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
