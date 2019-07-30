using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        //[ForeignKey("User")]
        //public string Username { get; set; }
        public int ScenicSpotId { get; set; }
        public string ReviewDetails { get; set; }
        public string QualityRating { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }

        //public virtual User User { get; set; }
        public virtual ScenicSpot ScenicSpot { get; set; }
        public virtual ICollection<ReviewText> ReviewTexts { get; set; }
    }
}