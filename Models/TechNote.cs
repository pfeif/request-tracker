// All comments not specific to the TechNote Model are located in ServiceRequest Model file.

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestTracker.Models
{
    public class TechNote
    {
        // A technician's note must have a primary key id, an associated service request ID, an
        //  associated technician ID, a date/time, and of course, a note.
        public int ID { get; set; }

        [Required]
        [Display(Name = "Service Request")]
        public int ServiceRequestID { get; set; }
        public ServiceRequest ServiceRequest { get; set; }

        [Required]
        [Display(Name = "Technician")]
        public int TechnicianID { get; set; }
        public Technician Technician { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
    }
}
