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

       /* public static List<Restaurant> lstRestaurant = new List<Restaurant>()
        {
            new Restaurant{
                RestCode = 1,
                RestName = "Wendys",
                RestFoodTypeCode ="AMERICAN",
                RestOverallRating = 3.5,
                RestTypeCode = "FAST",
                RestDateFriendly = false,
                RestAvgMealPrice = 8,
                RestCleanliness = 3,
                RestPhone ="(801) 377-8063",
                RestAddress = "122 E 1230 N St",
                RestCity = "Provo",
                RestState = "UT",
                RestZipCode = "84604"   },
            new Restaurant{
                RestCode = 2,
                RestName = "The Corner Restaurant",
                RestFoodTypeCode ="AMERICAN",
                RestOverallRating = 4.7,
                RestTypeCode = "SITDOWN",
                RestDateFriendly = true,
                RestAvgMealPrice = 13,
                RestCleanliness = 5,
                RestPhone ="(801) 377-8063",
                RestAddress = "195 W Main St, Midway",
                RestCity = "Provo",
                RestState = "UT",
                RestZipCode = "84604"   },
            new Restaurant{
                RestCode = 3,
                RestName = "Koko Lunchbox",
                RestFoodTypeCode ="Korean",
                RestOverallRating = 4.9,
                RestTypeCode = "ORDERATBAR",
                RestDateFriendly = true,
                RestAvgMealPrice = 11,
                RestCleanliness = 2,
                RestPhone ="(801) 850-4358",
                RestAddress = "3420, 1175 N Canyon Rd",
                RestCity = "Provo",
                RestState = "UT",
                RestZipCode = "84604"   }
        };*/
        // GET: Resturant
        public ActionResult Index()
        {
            // return View(lstRestaurant);
            return View(db.restaurants.ToList());
        }
        // GET: Resturant/Details/5
        public ActionResult Details(int iCode)
        {
            //Restaurant oRestaurant = lstRestaurant.Find(x => x.RestCode == iCode);
            //return View(oRestaurant);
            return View();
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