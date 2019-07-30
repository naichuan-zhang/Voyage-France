using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication6.DAL;
using WebApplication6.Models;

namespace WebApplication6.ViewModels
{
    public class CityScenicSpotViewModel
    {
        public IEnumerable<City> City { get; set; }
        public IEnumerable<ScenicSpot> ScenicSpot { get; set; }
        public IEnumerable<Review> Review { get; set; }

        public CityScenicSpotViewModel()
        {
            VoyageContext db = new VoyageContext();
            this.City = db.Cities.ToList();
            this.ScenicSpot = db.ScenicSpots.ToList();
            this.Review = db.Reviews.ToList();
        }
    }
}