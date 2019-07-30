using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class PaymentRecord
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("User")]
        public string Username { get; set; }
        public int ScenicSpotId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Money { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime PurchaseDate { get; set; }

        public virtual User User { get; set; }
    }
}