using System;

namespace DisasterManagement.Models
{
    public class Report
    {
        public int ReportID { get; set; }
        public string ReportType { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string ExportFormat { get; set; }
    }
}