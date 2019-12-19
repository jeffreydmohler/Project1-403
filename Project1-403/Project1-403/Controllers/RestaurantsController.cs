using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project1_403.DAL;
using Project1_403.Models;

namespace Project1_403.Controllers
{
    public class RestaurantsController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();

        // GET: Restaurants
        public ActionResult Index()
        {
            var restaurants = db.Restaurants.Include(r => r.FoodType).Include(r => r.RestaurantType);
            return View(restaurants.ToList());
        }


        public ActionResult Search(string search)
        {
            var restaurants = db.Restaurants.Where(r => r.RestName.Contains(search));
            return View("Index", restaurants.ToList());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.RestFoodTypeCode = new SelectList(db.FoodTypes, "RestFoodTypeCode", "FoodTypeDesc");
            ViewBag.RestTypeCode = new SelectList(db.RestaurantTypes, "RestTypeCode", "RestTypeDesc");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestID,RestName,RestOverallRating,RestDateFriendly,RestCleanliness,RestTypeCode,RestFoodTypeCode,RestAvgMealPrice,RestPhone,RestAddress,RestCity,RestState,RestZipCode")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestFoodTypeCode = new SelectList(db.FoodTypes, "RestFoodTypeCode", "FoodTypeDesc", restaurant.RestFoodTypeCode);
            ViewBag.RestTypeCode = new SelectList(db.RestaurantTypes, "RestTypeCode", "RestTypeDesc", restaurant.RestTypeCode);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestFoodTypeCode = new SelectList(db.FoodTypes, "RestFoodTypeCode", "FoodTypeDesc", restaurant.RestFoodTypeCode);
            ViewBag.RestTypeCode = new SelectList(db.RestaurantTypes, "RestTypeCode", "RestTypeDesc", restaurant.RestTypeCode);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestID,RestName,RestOverallRating,RestDateFriendly,RestCleanliness,RestTypeCode,RestFoodTypeCode,RestAvgMealPrice,RestPhone,RestAddress,RestCity,RestState,RestZipCode")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestFoodTypeCode = new SelectList(db.FoodTypes, "RestFoodTypeCode", "FoodTypeDesc", restaurant.RestFoodTypeCode);
            ViewBag.RestTypeCode = new SelectList(db.RestaurantTypes, "RestTypeCode", "RestTypeDesc", restaurant.RestTypeCode);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
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
