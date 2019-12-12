using Project1_403.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1_403.DAL;
using System.Net;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Project1_403.Controllers
{
    public class ReviewsController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        /*  public static List<Review> lstReviews = new List<Review>()
          {
              new Review { ReviewCode = 1, RestCode = 1, ReviewOverallRating = 3, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "We had a party of Five hungry adults and one hungry toddler. Three picky eaters too. We happened upon this place. We had intentions of going somewhere else. Decided to try this place and we were beyond thrilled we went. Top notch customer service. They catered to all the picky eaters. It was delicious and such friendly customer service. Loved it!  It's a new favorite."},
              new Review { ReviewCode = 2, RestCode = 2, ReviewOverallRating = 2, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
              new Review { ReviewCode = 3, RestCode = 3, ReviewOverallRating = 5, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
              new Review { ReviewCode = 4, RestCode = 1, ReviewOverallRating = 4, ReviewDateFriendly = false, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
              new Review { ReviewCode = 5, RestCode = 2, ReviewOverallRating = 3, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
              new Review { ReviewCode = 6, RestCode = 3, ReviewOverallRating = 4, ReviewDateFriendly = false, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
              new Review { ReviewCode = 7, RestCode = 1, ReviewOverallRating = 2, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
              new Review { ReviewCode = 8, RestCode = 2, ReviewOverallRating = 1, ReviewDateFriendly = false, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
              new Review { ReviewCode = 9, RestCode = 3, ReviewOverallRating = 4, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
          };*/


        // GET: Reviews
        public ActionResult ShowReviews(int iCode)
          {
            //find the restaurant object that they clicked on
             Restaurant oRestaurant = db.restaurants.ToList().Find(x => x.RestCode == iCode);

            //finds the current average overall if there are any reviews 
            if (db.Database.SqlQuery<Review>("Select * from Review Where RestCode = @iCode", new SqlParameter("@iCode", iCode)).FirstOrDefault() != null)
            {
                //overall
                decimal overall = db.Database.SqlQuery<decimal>("Select Cast(Avg(ReviewOverallRating) AS Decimal(4,2)) From Review Where RestCode = @iCode", new SqlParameter("@iCode", iCode)).FirstOrDefault();
                oRestaurant.RestOverallRating = overall;
                //cleanliness
                decimal cleanliness = db.Database.SqlQuery<decimal>("Select Cast(Avg(ReviewCleanliness) AS Decimal(4,2)) From Review Where RestCode = @iCode", new SqlParameter("@iCode", iCode)).FirstOrDefault();
                oRestaurant.RestCleanliness = cleanliness;

                //Date friendly
                int sum = db.Database.SqlQuery<int>("Select Count(ReviewDateFriendly) From Review Where RestCode =  @iCode AND ReviewDateFriendly = 1", new SqlParameter("@iCode", iCode)).FirstOrDefault();
                int count = db.Database.SqlQuery<int>("Select Count(ReviewDateFriendly) From Review Where RestCode =  @iCode", new SqlParameter("@iCode", iCode)).FirstOrDefault();
                double avg = (double)sum / count;

                if (avg > 0.5)
                {
                    oRestaurant.RestDateFriendly = true;
                }
                else
                {
                    oRestaurant.RestDateFriendly = false;
                }
                db.Entry(oRestaurant).State = EntityState.Modified;
                db.SaveChanges();
            }

            //list of all the reviews
            List<Review> lstReviews = db.reviews.ToList();

            //empty list that will contain all reviews for specific restaurants
            List<Review> specReviews = new List<Review>();

            for (var iCount = 0; iCount < lstReviews.Count; iCount++)
            {
                //if the review has same restaurant code as the restaurant clicked on, add that review to specific list
                if (lstReviews[iCount].RestCode == oRestaurant.RestCode)
                {
                    specReviews.Add(lstReviews[iCount]);
                }
            }

            //pass to models to view with tuple.  the restaurant object for summary info, and specific reviews for that restaurant
            var model = Tuple.Create<Restaurant, IEnumerable<Review>>(oRestaurant, specReviews);

              return View(model);
          }

        //the rest of this is simple scaffolded code, so not much need for comments

        [Authorize]
        public ActionResult AddReview(int? iCode)
        {

            ViewBag.ListRests = db.restaurants.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult AddReview(Review newReview)
        {
            newReview.ReviewCode = (db.reviews.ToList().Count() + 1);

            if (ModelState.IsValid)
            {
                db.reviews.Add(newReview);
                db.SaveChanges();

                return RedirectToAction("ShowReviews", new { iCode = newReview.RestCode });
            }
            else
            {
                ViewBag.ListRests = db.restaurants.ToList();

                return View(newReview);
            }
        }

        [Authorize]
        public ActionResult EditReview(int? iCode)
        {
            ViewBag.ListRests = db.restaurants.ToList();

            if (iCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review oReview = db.reviews.Find(iCode);
            if (oReview == null)
            {
                return HttpNotFound();
            }
            return View(oReview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReview([Bind(Include = "ReviewCode, RestCode, ReviewOverallRating, ReviewDateFriendly, ReviewCleanliness, ReviewDate, ReviewDesc")] Review oReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowReviews", new { iCode = oReview.RestCode });
            }

            ViewBag.ListRests = db.restaurants.ToList();
            return View(oReview);
        }


        // GET: Clients/Delete/5
        [Authorize]
        public ActionResult Delete(int? iCode)
        {
            if (iCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.reviews.Find(iCode);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int iCode)
        {
            Review review = db.reviews.Find(iCode);
            db.reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("ShowReviews", new { iCode = review.RestCode });
        }
    }
}