using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class StarRating
    {
        [Key]
        public int Id { get; set; }
        public int ScenicSpotId { get; set; }
        [ForeignKey("User")]
        public string Username { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString="{0:F}")]
        public DateTime RatingDate { get; set; }
        [Range(0, 5)]
        public int Star { get; set; }

        public virtual User User { get; set; }
        public virtual ScenicSpot ScenicSpot { get; set; }
    }
}