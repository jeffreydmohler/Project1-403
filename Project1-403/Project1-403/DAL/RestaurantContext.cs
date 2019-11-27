using Project1_403.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project1_403.DAL
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() : base("RestaurantContext")
        {

        }

        public DbSet<Company> company { get; set; }
        public DbSet<FoodType> foodTypes { get; set; }
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<RestaurantType> restaurantTypes { get; set; }
        public DbSet<Review> reviews { get; set; }
    }
}