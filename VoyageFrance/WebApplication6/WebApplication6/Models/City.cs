using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [StringLength(30)]
        public string CityName { get; set; }

        public virtual ICollection<ScenicSpot> ScenicSpot { get; set; }
    }
}