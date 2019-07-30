using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class ReviewText
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewTextDetails { get; set; }

        public virtual Review Review { get; set; }
    }
}