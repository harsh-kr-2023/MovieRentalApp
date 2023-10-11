using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalAppBE.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? Address { get; set; }
    }
}
