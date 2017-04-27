using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoJZ;
using System.Web.Helpers;

namespace Jobzterdk.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BrugerFac bf = new BrugerFac();
        public ActionResult Index()
        {
            return View();
        }

    }
}