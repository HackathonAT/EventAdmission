using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArminServices.Controllers
{
    public class ArminController : ApiController
    {
        // GET: api/Armin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Armin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Armin
        [HttpPost]
        public string Post(string value)
        {
            return value;
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("C:\\Test.txt");

            //Write a line of text
            sw.WriteLine(value);

            //Write a second line of text
            //sw.WriteLine("From the StreamWriter class");

            //Close the file
            sw.Close();
        }

        // PUT: api/Armin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Armin/5
        public void Delete(int id)
        {
        }
    }
}
