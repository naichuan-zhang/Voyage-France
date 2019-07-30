using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class ScenicSpot
    {

        [Key]
        public int ScenicSpotId { get; set; }
        [StringLength(50)]
        public string ScenicSpotName { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(5000)]
        public string ScenicSpotDetails { get; set; }
        [DataType(DataType.Currency)]
        public decimal TicketPrice { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString="{0:t}")]
        public DateTime OpeningHour { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime ClosingHour { get; set; }
        public int CityId { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<StarRating> StarRatings { get; set; }
        public virtual City City { get; set; }
    }
}