using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterAPI.Models; // Provides us access to our models within this namespace.

namespace RestaurantRaterAPI
{
    public class RestaurantDbContext : DbContext // DbContext is pulled from EF Core. This is the C# representation of the DB
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }
        // pulling in the DBContextOptions object and bringing in the base properties of the DbContext.

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}