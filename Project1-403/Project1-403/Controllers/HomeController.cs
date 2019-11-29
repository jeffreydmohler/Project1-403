using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project1_403.DAL;
using Project1_403.Models;

namespace Project1_403.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

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

        // GET: Home
        public ActionResult Login()
        {
            ViewBag.Login = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();
            Users oUser = db.users.Find(email);

            if (oUser != null)
            {
                if (oUser.UserPassword == password)
                {
                    ViewBag.Login = "";
                    FormsAuthentication.SetAuthCookie(email, rememberMe);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Login = "<p style='color: red'>The username or password is incorrect";
                    return View();
                }
            }
            else
            {
                ViewBag.Login = "The username or password is incorrect";
                return View();
            }
        }

        public ActionResult CreateUser()
        {
            return View("Login");
        }
    }
}