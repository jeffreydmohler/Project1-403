using Project1_403.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1_403.DAL;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;

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
                if (db.Database.SqlQuery<Review>("Select * from Review Where RestCode = @iCode", new SqlParameter("@iCode", item.RestCode)).FirstOrDefault() != null)
                    {
                    //overall rating
                    item.RestOverallRating = db.Database.SqlQuery<decimal>("Select Cast(Avg(ReviewOverallRating) AS Decimal(4,2)) From Review Where RestCode = @iCode", new SqlParameter("@iCode", item.RestCode)).FirstOrDefault();
                    //cleanliness rating
                    item.RestCleanliness = db.Database.SqlQuery<decimal>("Select Cast(Avg(ReviewCleanliness) AS Decimal(4,2)) From Review Where RestCode = @iCode", new SqlParameter("@iCode", item.RestCode)).FirstOrDefault();
                    
                    //Date friendly
                    int sum = db.Database.SqlQuery<int>("Select Count(ReviewDateFriendly) From Review Where RestCode =  @iCode AND ReviewDateFriendly = 1", new SqlParameter("@iCode", item.RestCode)).FirstOrDefault();
                    int count = db.Database.SqlQuery<int>("Select Count(ReviewDateFriendly) From Review Where RestCode =  @iCode", new SqlParameter("@iCode", item.RestCode)).FirstOrDefault();
                    double avg = (double)sum/count;

                    if (avg > 0.5)
                    {
                        item.RestDateFriendly = true;
                    }
                    else
                    {
                        item.RestDateFriendly = false;
                    }

                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                    }
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
                //int restcode = db.Database.SqlQuery<int>("SELECT RestCode FROM Restaurant WHERE RestName LIKE '%@userEntry%'", new SqlParameter("@userEntry", userEntry)).FirstOrDefault();
                //Restaurant oRestaurant = lstRests.Find(x => x.RestCode == restcode);

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

        [Authorize(Roles = "Admin")]
        // GET: Restaurants1/Create
        public ActionResult Create()
        {
            ViewBag.RestFoodTypeCode = new SelectList(db.foodTypes, "RestFoodTypeCode", "FoodTypeDesc");
            ViewBag.RestTypeCode = new SelectList(db.restaurantTypes, "RestTypeCode", "RestTypeDesc");
            return View();
        }

        // POST: Restaurants1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "RestCode,RestName,RestOverallRating,RestDateFriendly,RestCleanliness,RestTypeCode,RestFoodTypeCode,RestAvgMealPrice,RestPhone,RestAddress,RestCity,RestState,RestZipCode")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Admin", "Home");
            }

            ViewBag.RestFoodTypeCode = new SelectList(db.foodTypes, "RestFoodTypeCode", "FoodTypeDesc", restaurant.RestFoodTypeCode);
            ViewBag.RestTypeCode = new SelectList(db.restaurantTypes, "RestTypeCode", "RestTypeDesc", restaurant.RestTypeCode);
            return View(restaurant);
        }

        // GET: Restaurants1/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestFoodTypeCode = new SelectList(db.foodTypes, "RestFoodTypeCode", "FoodTypeDesc", restaurant.RestFoodTypeCode);
            ViewBag.RestTypeCode = new SelectList(db.restaurantTypes, "RestTypeCode", "RestTypeDesc", restaurant.RestTypeCode);
            return View(restaurant);
        }

        // POST: Restaurants1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "RestCode,RestName,RestOverallRating,RestDateFriendly,RestCleanliness,RestTypeCode,RestFoodTypeCode,RestAvgMealPrice,RestPhone,RestAddress,RestCity,RestState,RestZipCode")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin", "Home");
            }
            ViewBag.RestFoodTypeCode = new SelectList(db.foodTypes, "RestFoodTypeCode", "FoodTypeDesc", restaurant.RestFoodTypeCode);
            ViewBag.RestTypeCode = new SelectList(db.restaurantTypes, "RestTypeCode", "RestTypeDesc", restaurant.RestTypeCode);
            return View(restaurant);
        }

        // GET: Restaurants1/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.restaurants.Find(id);
            db.restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Admin", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}