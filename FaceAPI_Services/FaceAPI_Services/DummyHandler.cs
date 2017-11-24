using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceAPI_Services
{
    public class DummyHandler
    {
        public static int testc = 0;
        public DummyHandler()
        {

        }

        public void HeyArmin(object o)
        {
            string test = (string)o;
        }

        public string SupArmin()
        {
            return "Beer time!";
        }
    }
}