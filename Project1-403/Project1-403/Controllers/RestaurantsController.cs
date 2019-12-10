using Project1_403.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1_403.DAL;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Project1_403.Controllers
{
    public class RestaurantsController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Resturant
        public ActionResult Index()
        {
            //sql queries to update the database with up-to-date averages for overall ratings
            foreach (Restaurant item in db.restaurants.ToList())
            {
                item.RestOverallRating = db.Database.SqlQuery<decimal>("Select Cast(Avg(ReviewOverallRating) AS Decimal(4,2)) From Review Where RestCode = @iCode", new SqlParameter("@iCode", item.RestCode)).FirstOrDefault();
                item.RestCleanliness = db.Database.SqlQuery<decimal>("Select Cast(Avg(ReviewCleanliness) AS Decimal(4,2)) From Review Where RestCode = @iCode", new SqlParameter("@iCode", item.RestCode)).FirstOrDefault();
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }

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


        //this search function works with exact user entry only
        [HttpPost]
        public ActionResult Search(string userEntry)
        {
            List<Restaurant> lstRests = db.restaurants.ToList();
            //variable to change the default text in search bar if couldn't find restaurant. Sets it to false here to initialize it
            bool isError = false;

            if (userEntry != "")
            {
                //if there is user entry, try to find the restaurant
                Restaurant oRestaurant = lstRests.Find(x => x.RestName == userEntry);

                if (oRestaurant != null)
                {
                    //if found, send it to that restaurants page
                    return RedirectToAction("ShowReviews", "Reviews", new { iCode = oRestaurant.RestCode });
                }
                else
                {
                    //if not found, change isError, pass it back to the home page. will change default text to "Could not find. please try again."
                    isError = true;
                    return RedirectToAction("Index", "Home", new { Error = isError});
                }
            }
            else
            {
                //if know user entry, just refresh page pretty much
                ViewBag.Search = "Search for a Restaurant";
                return RedirectToAction("Index", "Home");
            }

            
        }
    }
}