using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Contexts
{
    public class RestaurantDeliveryContext : DbContext
    {
        public RestaurantDeliveryContext(DbContextOptions<RestaurantDeliveryContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Resturant> Restaurants { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
