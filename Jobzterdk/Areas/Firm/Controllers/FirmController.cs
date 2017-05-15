using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobzterdk.Areas.Firm.Controllers
{
    public class FirmController : Controller
    {
        // GET: Firm/Firm
        public ActionResult MineAnnoncer()
        {
            return View();
        }
        public ActionResult OpretAnnonce()
        {
            return View();
        }
    }
}