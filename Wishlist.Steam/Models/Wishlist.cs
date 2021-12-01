using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WishlistSteam.Models
{
    public class Wishlist
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "The field must be between 2 or 60 characters.")]
        public string Name { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Date in incorrect format.")]
        [Required(ErrorMessage = "The date field is required.")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "The price field is required.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The description field is required.")]
        public string Description { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00c0-\u00FF""'\w-]*$")]
        [Required(ErrorMessage = "The genre field is required.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "The producer field is required.")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "The review field is required.")]
        [RegularExpression(@"^[0-10]*$", ErrorMessage = "Somente números.")]
        public int Review { get; set; }

       
    }
}
