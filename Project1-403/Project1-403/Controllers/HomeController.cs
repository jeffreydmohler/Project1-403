using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1_403.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(bool? Error)
        {
            if (Error == true)
            {
                ViewBag.Search = "";
                ViewBag.Error = "Could not find restaurant. Please try again.";
            }
            else
            {
                ViewBag.Error = "";
                ViewBag.Search = "Search for a Restaurant";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}