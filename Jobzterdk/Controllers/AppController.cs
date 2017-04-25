using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Security;
using RepoJZ;

namespace Jobzterdk.Controllers
{
    public class AppController : ApiController
    {
        BrugerFac bf = new BrugerFac();

        [Route("api/App/Login/{email}/{adgangskode}")]
        [HttpGet]
        public Bruger Login(string email, string adgangskode)
        {
            Bruger b = bf.Login(email, adgangskode);

            return b;
        }
    }
}
