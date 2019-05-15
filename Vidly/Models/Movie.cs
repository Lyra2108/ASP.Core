using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }
    }
}
