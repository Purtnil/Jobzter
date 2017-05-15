using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoJZ;

namespace Jobzterdk.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MereOmApp()
        {
            return View();
        }
        public ActionResult MereOmVirk()
        {
            return View();
        }
        public ActionResult OpretVirk()
        {
            return View();
        }
    }
}