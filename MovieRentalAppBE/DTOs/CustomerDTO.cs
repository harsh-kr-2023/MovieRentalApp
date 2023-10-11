using System.ComponentModel.DataAnnotations;

namespace MovieRentalAppBE.DTOs
{
    public class CustomerDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? Address { get; set; }
    }
}