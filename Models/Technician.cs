// All comments not specific to the Technician Model are located in ServiceRequest Model file.

using System.ComponentModel.DataAnnotations;

namespace RequestTracker.Models
{
    public class Technician
    {
        // A technician is simple. He or she has a primary key ID, first name, last name, composite
        //  name that returns "FirstName LastName", and a contact phone number.
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

}
