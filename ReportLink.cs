using System;
using DisasterManagement.Models;

public class ReportLink
{
    public int ReportLinkID { get; set; }
    public int ReportID { get; set; }
    public int? ProjectID { get; set; }
    public int? DonationID { get; set; }
    public int? VolunteerID { get; set; }

    // Navigation property
    public Report Report { get; set; }
}