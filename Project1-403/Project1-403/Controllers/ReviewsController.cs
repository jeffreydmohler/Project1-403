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
            Restaurant oRestaurant = ResturantController.lstRestaurant.Find(x => x.RestCode == iCode);
          
            var model = Tuple.Create<Restaurant, IEnumerable<Review>>(oRestaurant, lstReviews);

            return View(model);
        }

        public ActionResult AddReview()
        {
            ViewBag.ListRests = ResturantController.lstRestaurant;

            return View();
        }

        [HttpPost]
        public ActionResult AddReview(Review newReview)
        {
            if (ModelState.IsValid)
            {
                newReview.ReviewCode = (lstReviews.Count() + 1);
                lstReviews.Add(newReview);
                return RedirectToAction("ShowReviews");
            }
            else
            {
                ViewBag.ListRests = ResturantController.lstRestaurant;

                return View(newReview);
            }
        }
    }
}