using System.ComponentModel.DataAnnotations;

namespace MovieRentalAppBE.DTOs
{
    public class RentDetailPutDTO
    {
        public Guid OrderId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public Guid MovieId { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
