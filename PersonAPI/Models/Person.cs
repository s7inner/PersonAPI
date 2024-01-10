using System.ComponentModel.DataAnnotations;

namespace PersonAPI.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "FirstName length must be between 2 and 15")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "LastName length must be between 2 and 15")]
        public string LastName { get; set; }
    }
}
