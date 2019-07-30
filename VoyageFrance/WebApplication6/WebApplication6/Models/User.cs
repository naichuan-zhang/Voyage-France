using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        [Required]
        [StringLength(30, ErrorMessage="The password cannot exceed 30 characters!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<StarRating> StarRatings { get; set; }
        public virtual ICollection<PaymentRecord> PaymentRecord { get; set; }
    }
}