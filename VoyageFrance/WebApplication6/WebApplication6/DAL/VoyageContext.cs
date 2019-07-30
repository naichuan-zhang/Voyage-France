using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication6.Models;

namespace WebApplication6.DAL
{
    public class VoyageContext : DbContext
    {
        public VoyageContext()
            : base("DefaultConnection")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ScenicSpot> ScenicSpots { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<StarRating> StarRatings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ReviewText> ReviewTexts { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; }
    }
}