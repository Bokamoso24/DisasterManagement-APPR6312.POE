using DisasterManagementApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DisasterManagementApp.Services
{
    public class DonationService
    {
        public List<Donation> Donations { get; set; } = new List<Donation>();

        public void AddDonation(Donation donation)
        {
            Donations.Add(donation);
        }

        public decimal CalculateTotalMonetaryDonations()
        {
            return Donations
                .Where(d => d.DonationType == "Monetary" && d.Amount.HasValue)
                .Sum(d => d.Amount.Value);
        }
    }
}
