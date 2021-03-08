using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestTracker.Models
{
    // ** Each service request has a status, and there are only four acceptable status values. **
    public enum Status { Created, Assigned, InProcess, Completed }

    public class ServiceRequest
    {
        // This page is littered with Data Annotations. Some supporting documentaion is here, though
        //  I'll mention each one on its first use.
        //  https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-3.1
        //  https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/data-annotations

        // ** Each request must start with an ID, client, open date, description and a status. **
        // EF Core automatically detects primary keys named ID.
        public int ID { get; set; }

        // [Required]: ClientID is a required property. EF Core does a pretty good job at inferring
        //  this, but explicit is better than implicit.
        // [Display(Name = "Client")] displays "Client" instead of "ClientID" on the Razor Page.
        // EF Core automatically detects foreign key constraints named <Model>ID.
        [Required]
        [Display(Name = "Client")]
        public int ClientID { get; set; }
        public Client Client { get; set; }

        // [DataType(DataType.DateTime)] specifies that we want both a date and a time.
        // [DisplayFormat(DataFormatString... sets the date format to use.
        //  https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings?view=netcore-3.1
        // ...ApplyFormatInEditMode = true)] displays it in that format to the user in editable text
        //  boxes.
        [Required]
        [Display(Name = "Open Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime OpenDate {get; set;}

        // [StringLength]: SQLite doesn't enforce string length constraints. However, EF Core uses
        //  StringLength for client-side validation. 5 characters might prevent those 4-letter
        //  words.
        // [DataType(DataType.MultilineText)] creates a <textarea> in on the Razor Page instead of
        //  an <input> to give the user a little more room to type.
        [Required]
        [StringLength(500, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public Status Status { get; set; }

        // ** By completion, each request should have a technician and a close date. **
        // Nullable types are being used for columns which might not have initial data.
        [Display(Name = "Technician")]
        public int? TechnicianID { get; set; }
        public Technician Technician { get; set; }

        [Display(Name = "Close Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? CloseDate { get; set; }

        // ** A request may or may not have technician's notes during its life-cycle. **
        //  This is a one-to-many relationship.
        public List<TechNote> TechNotes { get; set; }
    }
}
