using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OggettiCondivisi;

namespace DemoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private static List<ServerDataItem> db = new List<ServerDataItem> {
                new ServerDataItem()
        {
                    Id = 1,
                    Name = "PRIMO",
                    Description = "DESCRIZIONE PRIMO",
                    DataElemento = DateTime.Now,
                },
                new ServerDataItem()
        {
                    Id = 2,
                    Name = "SECONDO",
                    Description = "DESCRIZIONE SECONDO",
                    DataElemento = DateTime.Now.AddDays(1),
                }
        };

    // GET api/values
    [HttpGet]
        public ActionResult<IEnumerable<ServerDataItem>> Get()
        {
            return db.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ServerDataItem value)
        {
            var newId = db.Max(x => x.Id) + 1;
            value.Id = newId;

            db.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ServerDataItem value)
        {
            var itemToUpdate = db.FirstOrDefault(x => x.Id == id);
            db.Remove(itemToUpdate);

            db.Add(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var itemToUpdate = db.FirstOrDefault(x => x.Id == id);
            db.Remove(itemToUpdate);
        }
    }
}
