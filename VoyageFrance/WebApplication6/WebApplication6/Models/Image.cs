using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Image
    {
        [Key]
        [DataType(DataType.ImageUrl)]
        public string ImageFilename { get; set; }
        public int ScenicSpotId { get; set; }

        public virtual ScenicSpot ScenicSpot { get; set; }
    }
}