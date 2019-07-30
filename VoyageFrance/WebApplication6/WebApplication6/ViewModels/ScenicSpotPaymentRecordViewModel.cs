using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication6.DAL;
using WebApplication6.Models;

namespace WebApplication6.ViewModels
{
    public class ScenicSpotPaymentRecordViewModel
    {
        public IEnumerable<PaymentRecord> PaymentRecord { get; set; }
        public IEnumerable<ScenicSpot> ScenicSpot { get; set; }

        public ScenicSpotPaymentRecordViewModel()
        {
            VoyageContext db = new VoyageContext();
            this.PaymentRecord = db.PaymentRecords.ToList();
            this.ScenicSpot = db.ScenicSpots.ToList();
        } 
    }
}