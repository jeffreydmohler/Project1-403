using Project1_403.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1_403.Controllers
{
    public class ReviewsController : Controller
    {
        public static List<Review> lstReviews = new List<Review>()
        {
            new Review { ReviewCode = 1, RestCode = 1, ReviewOverallRating = 3, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
            new Review { ReviewCode = 2, RestCode = 2, ReviewOverallRating = 2, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
            new Review { ReviewCode = 3, RestCode = 3, ReviewOverallRating = 5, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
            new Review { ReviewCode = 4, RestCode = 1, ReviewOverallRating = 4, ReviewDateFriendly = false, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
            new Review { ReviewCode = 5, RestCode = 2, ReviewOverallRating = 3, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
            new Review { ReviewCode = 6, RestCode = 3, ReviewOverallRating = 4, ReviewDateFriendly = false, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
            new Review { ReviewCode = 7, RestCode = 1, ReviewOverallRating = 2, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
            new Review { ReviewCode = 8, RestCode = 2, ReviewOverallRating = 1, ReviewDateFriendly = false, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
            new Review { ReviewCode = 9, RestCode = 3, ReviewOverallRating = 4, ReviewDateFriendly = true, ReviewCleanliness = 4, ReviewDate = "10/18/18", ReviewDesc = "This is an awesome restaurant"},
        };


        // GET: Reviews
        public ActionResult ShowReviews(int iCode)
        {
            Restaurant oRestaurant = RestaurantsController.lstRestaurant.Find(x => x.RestCode == iCode);
          
            var model = Tuple.Create<Restaurant, IEnumerable<Review>>(oRestaurant, lstReviews);

            return View(model);
        }

        public ActionResult AddReview(int iCode)
        {

            ViewBag.ListRests = RestaurantsController.lstRestaurant;

            return View();
        }

        [HttpPost]
        public ActionResult AddReview(Review newReview)
        {
            newReview.ReviewCode = (lstReviews.Count() + 1);

            if (ModelState.IsValid)
            {
                lstReviews.Add(newReview);
                return RedirectToAction("ShowReviews", new { iCode = newReview.RestCode });
            }
            else
            {
                ViewBag.ListRests = RestaurantsController.lstRestaurant;

                return View(newReview);
            }
        }

        public ActionResult EditReview(int iCode)
        {
            ViewBag.ListRests = RestaurantsController.lstRestaurant;

            Review oReview = lstReviews.Find(x => x.ReviewCode == iCode);

            return View(oReview);
        }

        [HttpPost]
        public ActionResult EditReview(Review myReview)
        {
            var obj = lstReviews.FirstOrDefault(x => x.ReviewCode == myReview.ReviewCode);

            if (obj != null)
            {
                obj.ReviewCleanliness = myReview.ReviewCleanliness;
                obj.RestCode = myReview.RestCode;
                obj.ReviewDate = myReview.ReviewDate;
                obj.ReviewDateFriendly = myReview.ReviewDateFriendly;
                obj.ReviewOverallRating = myReview.ReviewOverallRating;
                obj.ReviewDesc = myReview.ReviewDesc;
            }
            return RedirectToAction("ShowReviews", new { iCode = myReview.RestCode });
        }
    }
}