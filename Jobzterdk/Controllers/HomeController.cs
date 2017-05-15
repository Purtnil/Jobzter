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
        BrugerFac brF = new BrugerFac();
        ErhvervtypeFac ertF = new ErhvervtypeFac();
        ErhvervKatFac erkF = new ErhvervKatFac();
        UdtypeFac udtF = new UdtypeFac();
        UdkatFac udkF = new UdkatFac();



        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GetUdkat()
        {

            List<UdtypeVM> list = new List<UdtypeVM>();
            foreach (var t in udkF.GetAll())
            {
                UdtypeVM udVM = new UdtypeVM();
                udVM.Udkat = udkF.Get(t.ID);
                udVM.Udtype = udtF.GetBy("UdkatID", t.ID);
                udVM.Count = udtF.Countid(t.ID);
                list.Add(udVM);
            }

            return View(list);
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