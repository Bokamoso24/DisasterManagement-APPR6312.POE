using System;

namespace DisasterManagementApp.Models
{
    public class VolunteerAssignment
    {
        public int AssignmentID { get; set; }
        public int VolunteerID { get; set; }
        public int ProjectID { get; set; }
        public DateTime? AssignedDate { get; set; }
    }
}
