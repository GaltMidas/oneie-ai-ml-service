using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using MongoDB.Driver;
using oneie_ai_ml_service.Models;
using oneie_ai_ml_service.Services;

namespace oneie_ai_ml_service.Controllers
{
    [Route("api/[controller]")]
    public class LeadScoringController : Controller
    {
        [Route("perform/{salesRepName}/{leadSourceName}")]
        public async Task<IEnumerable<string>> Perform(string salesRepName, string leadSourceName)
        {
            // pull data from cosmos db, mongo
            var x = await XService.RunMe();
            string dbData = "db Data here";

            // calls python azure function
            string functinoData = await XService.RunMe2();

            Console.WriteLine(dbData, functinoData);

            string pct = "percent goes here";

            return new string[] {salesRepName, leadSourceName, dbData, pct};
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

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
