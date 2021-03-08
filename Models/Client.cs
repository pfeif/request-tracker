// All comments not specific to the Client Model are located in ServiceRequest Model file.

using System.ComponentModel.DataAnnotations;

namespace RequestTracker.Models
{
    public class Client
    {
        // A client is simple. He or she has a primary key ID, first name, last name, composite name
        //  that returns "FirstName LastName", and a contact phone number.
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

        // [Phone] is a DataAnnotation derived from the DataTypeAttribute. It helps EF Core perform
        //  client-side validation of phone numbers. This validation could be better, but frankly,
        //  I don't have the time to learn about international phone number format specifications,
        //  and I'm trying to stay away from third-party libraries.
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

}
