using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentalContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CarColor> CarColors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3EVB481;Database=CarRental;Trusted_Connection=true");
        }
    }
}
