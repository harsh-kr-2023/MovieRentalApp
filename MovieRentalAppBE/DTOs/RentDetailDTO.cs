using System.ComponentModel.DataAnnotations;

namespace MovieRentalAppBE.DTOs
{
    public class RentDetailDTO
    {
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public Guid MovieId { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
