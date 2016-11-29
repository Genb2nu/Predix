using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;

namespace redis.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        

        [HttpGet("getRedisItem")]
        public string getRedisItem()
        {
            var manager = new RedisManagerPool("10.72.6.42:60121");
            string item = "";
            using (var client = manager.GetClient())
            {
                client.Set("foo", "bar");
                //Console.WriteLine("foo={0}", client.Get<string>("foo"));
                item = $"foo = {client.Get<string>("foo")}";
            }
            return item;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
