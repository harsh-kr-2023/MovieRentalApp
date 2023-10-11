using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalAppBE.Models
{
    public class RentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        public string? Name { get; set; }

        [Required]
        public Guid MovieId { get; set; }
        public string? Title { get; set; }

        //[Required]
        public DateTime? OrderDate { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}