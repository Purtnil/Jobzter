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



        [Route("api/App/PostTest")]
        [HttpPost]
        public string PostTest(string email)
        {
                return "string";

        }







        [Route("api/App/GlemtAdg/{email}")]
        [HttpPost]
        public string GlemtAdg(string email)
        {
            Mail m = new Mail("smtp.gmail.com", "webitsven1106@gmail.com", "webitsven1106", "tw5mc7z8vc", 587);
            if (bf.UserExist(email))
            {
                Uploader uploader = new Uploader();
                string nyAdgangskode = uploader.GenRnd(8);

                bf.UpdateAdgangskode(email, Crypto.Hash(nyAdgangskode));

                m.Send("Ny adgangskode", nyAdgangskode, email);

                return "Du vil om kort tid modtage en mail med en ny adgangskode!";

            }
            else
            {
               return "Brugeren findes ikke";
            }
        }






























        //[Route("api/App/GlemtAdg/{email}")]
        //[HttpPost]
        //public string GlemtAdg(string email)
        //{
        //    List<Bruger> b = bf.GetBy("Email", email);
        //    if (b.Count > 0) //GetBy(Feltet, Værdi) Count tæller hvor mange rækker der er i listen.
        //    {
        //        Uploader uploader = new Uploader();
        //        Mail m = new Mail("smtp.gmail.com", "webitsven1106@gmail.com", "webitsven1106", "tw5mc7z8vc", 587); //ÆNdre til jobzters egen mail informationer
        //        string nyAdgangskode = uploader.GenRnd(8);

        //        bf.UpdateAdgangskode(email, Crypto.Hash(nyAdgangskode));

        //        m.Send("Ny adgangskode", nyAdgangskode, email);
        //        return "Vi har sendt et nyt password til din email";
        //    }
        //    else
        //    {
        //        return "Brugeren findes ikke!";
        //    }
        //}
    }
}
