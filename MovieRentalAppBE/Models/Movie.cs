using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalAppBE.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime? ReleaseYear { get; set; }

        public string? Genre { get; set; }

        public string? Rating { get; set; }

        [Required]
        public decimal RentalPrice { get; set; }
    }
}
