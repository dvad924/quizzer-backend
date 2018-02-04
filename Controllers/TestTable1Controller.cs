using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using quizzer_backend.Models;
using quizzer_backend.Repository;
using Newtonsoft.Json;

namespace quizzer_backend.Controllers
{
    [Route("api/[controller]")]
    public class TestTable1Controller : Controller
    {
        private readonly TestTable1Repository suRepository;
        public TestTable1Controller(IConfiguration configuration)
        {
            suRepository = new TestTable1Repository(configuration);
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            IEnumerable<TestTable1> users = suRepository.FindAll();
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                               ts.Hours, ts.Minutes, ts.Seconds,
                               ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            List<string> jsonObjs = new List<string>();

            foreach (TestTable1 u in users)
            {
                jsonObjs.Add(JsonConvert.SerializeObject(u));
            }
            return jsonObjs;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id.ToString();
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
