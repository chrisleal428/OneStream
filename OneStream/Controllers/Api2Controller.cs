using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OneStream.Controllers
{
    public class Api2Controller : ApiController
    {
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("GET response from API2");
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Post()
        {
            System.Threading.Thread.Sleep(3000);
            return Ok("POST response from API2");
        }
    }

}
