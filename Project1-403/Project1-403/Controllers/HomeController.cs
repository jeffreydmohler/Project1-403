using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

/********
    Project 2 - IS-403
    Eric Louis
    12/14/2019

    Designed to compile restaurants and reviews associated with the restaurants.
    Has Google OAuth enabled.
    Combined with DB functionality.



 ********/


namespace Project1_403.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is who we are.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "This is how to contact us.";

            return View();
        }
        
    }
}