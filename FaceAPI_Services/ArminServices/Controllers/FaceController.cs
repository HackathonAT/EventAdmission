using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArminServices.Controllers
{
    public class FaceController : ApiController
    {
        // GET: api/Face
        public IEnumerable<string> Get()
        {
            return new string[] { "njo", "nja" };
        }

        // GET: api/Face/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Face
        [HttpPost]
        public string Post([FromBody]IEnumerable<string> value)
        {
           

            return "jebem ti Boga";
        }

        // PUT: api/Face/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Face/5
        public void Delete(int id)
        {
        }
    }
}
