using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DisasterManagementApp.Data;
using DisasterManagementApp.Models;
using System.Security.Claims;
using System;

namespace DisasterManagementApp.Pages.Donations
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db) => _db = db;

        [BindProperty] public Donation Donation { get; set; }
        [BindProperty] public Resource Resource { get; set; }
        [BindProperty] public bool IsResource { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int uid)) uid = 0;
            Donation.DonorID = uid;
            Donation.DonationDate = DateTime.UtcNow;
            _db.Donations.Add(Donation);
            _db.SaveChanges();

            if (IsResource && Resource != null)
            {
                Resource.DonationID = Donation.DonationID;
                _db.Resources.Add(Resource);
                _db.SaveChanges();
            }
            return RedirectToPage("/Donations/List");
        }
    }
}
