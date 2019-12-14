using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project1_403.Models;

namespace Project1_403.DAL
{
    public class RestaurantDBContext : DbContext
    {
        public RestaurantDBContext() : base("RestaurantDBContext")
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
    }
}