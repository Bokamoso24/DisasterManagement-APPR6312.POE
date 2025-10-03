using System;

namespace DisasterManagementApp.Models
{
    public class Incident
    {
        public int IncidentID { get; set; }
        public int? ReporterID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IncidentType { get; set; }
        public string Location { get; set; }
        public DateTime ReportDate { get; set; }
        public string Status { get; set; }
    }
}
