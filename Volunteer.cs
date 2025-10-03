using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterManagementApp.Models
{
    public class Volunteer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VolunteerID { get; set; } // auto-incremented
        public string PhoneNumber { get; set; }
        public string Skills { get; set; }
        public string Availability { get; set; }
    }
}
