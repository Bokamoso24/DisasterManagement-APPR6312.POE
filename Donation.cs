using System;

namespace DisasterManagementApp.Models
{
    public class Donation
    {
        public int DonationID { get; set; }
        public int DonorID { get; set; }
        public string DonationType { get; set; } // e.g. 'Monetary', 'Resource'
        public decimal? Amount { get; set; }
        public DateTime DonationDate { get; set; }

        // Navigation property for resources
        public List<Resource> Resources { get; set; } = new List<Resource>();
    }
}
