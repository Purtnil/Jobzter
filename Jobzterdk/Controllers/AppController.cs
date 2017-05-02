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
        BrugerFac brF = new BrugerFac();
        ErfaringtypeFac ertF = new ErfaringtypeFac();
        ErfaringKatFac erkF = new ErfaringKatFac();
        UdtypeFac udF = new UdtypeFac();

        Mail m = new Mail("smtp.gmail.com", "webitsven1106@gmail.com", "webitsven1106", "tw5mc7z8vc", 587); //ændre til Jobzter Email

        [Route("api/App/Login/{email}/{adgangskode}")]
        [HttpGet]
        public Bruger Login(string email, string adgangskode)
        {
            Bruger b = brF.Login(email, adgangskode);

            return b;
        }

        [Route("api/App/GlemtAdg/{email}")]
        [HttpPost]
        public string GlemtAdg(string email)
        {
            if (brF.UserExist(email))
            {
                Uploader uploader = new Uploader();
                string nyAdgangskode = uploader.GenRnd(8);

                brF.UpdateAdgangskode(email, Crypto.Hash(nyAdgangskode)); //Crypto.Hash()

                m.Send("Ny adgangskode", nyAdgangskode, email);

                return "Du vil om kort tid modtage en mail med en ny adgangskode!";

            }
            else
            {
               return "Brugeren findes ikke";
            }
        }

        [Route("api/App/GetUdtype")]
        [HttpGet]
        public IEnumerable<Udtype> GetUdtype()
        {
            return udF.GetAll();
        }

        [Route("api/App/GetErfKat")]
        [HttpGet]
        public IEnumerable<ErfaringKat> GetErfKat()
        {
            return erkF.GetAll();
        }

        [Route("api/App/GetErfType/{id}")]
        [HttpGet]
        public IEnumerable<Erfaringtype> GetErfType(int id)
        {

            return ertF.GetBy("ErKatID", id);
        }

    }
}
