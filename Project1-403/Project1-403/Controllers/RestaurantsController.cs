using Project1_403.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1_403.DAL;

namespace Project1_403.Controllers
{
    public class RestaurantsController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Resturant
        public ActionResult Index()
        {
            return View(db.restaurants.ToList());
        }
        // GET: Resturant/Details/5
        public ActionResult Details(int iCode)
        {
            Restaurant oRestaurant = db.restaurants.Find(iCode);
            return View(oRestaurant);
        }

        public ActionResult Search()
        {
            ViewBag.Search = "Search for a Restaurant";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string userEntry)
        {
            List<Restaurant> lstRests = db.restaurants.ToList();

            if (userEntry != "")
            {
                Restaurant oRestaurant = lstRests.Find(x => x.RestName == userEntry);

                if (oRestaurant != null)
                {
                    return RedirectToAction("ShowReviews", "Reviews", new { iCode = oRestaurant.RestCode });
                }
                else
                {
                    bool isError = true;
                    return RedirectToAction("Index", "Home", new { Error = isError});
                }
            }
            else
            {
                ViewBag.Search = "Search for a Restaurant";
                return RedirectToAction("Index", "Home");
            }

            
        }
    }
}