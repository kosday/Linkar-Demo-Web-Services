using LinkarServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LinkarDemoRESTAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values?text=hello&seconds=5
        public string Get(string text, int seconds)
        {
            //Call common project
            return Functions.SubDemoLinkar(text, seconds);
        }
    }
}
