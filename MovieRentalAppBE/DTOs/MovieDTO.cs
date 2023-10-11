using System.ComponentModel.DataAnnotations;

namespace MovieRentalAppBE.DTOs
{
    public class MovieDTO
    {
        [Required]
        public string Title { get; set; }

        public DateTime? ReleaseYear { get; set; }

        public string? Genre { get; set; }

        public string? Rating { get; set; }

        [Required]
        public decimal RentalPrice { get; set; }
    }
}