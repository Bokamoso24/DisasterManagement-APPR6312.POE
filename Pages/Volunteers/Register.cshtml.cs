using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using DisasterManagementApp.Data;
using DisasterManagementApp.Models;
using System.Security.Claims;
using System.Linq;

namespace DisasterManagementApp.Pages.Volunteers
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public RegisterModel(ApplicationDbContext db) => _db = db;

        [BindProperty] public Volunteer Volunteer { get; set; }

        public IActionResult OnGet() => Page();

        public IActionResult OnPost()
        {
            var uidClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(uidClaim, out int uid))
                return RedirectToPage("/Account/Login");

            Volunteer.VolunteerID = uid;

            // Check if this user is already a volunteer
            var existingVolunteer = _db.Volunteers.FirstOrDefault(v => v.VolunteerID == uid);

            if (existingVolunteer != null)
            {
                // Option 1: Update their existing profile
                existingVolunteer.PhoneNumber = Volunteer.PhoneNumber;
                existingVolunteer.Skills = Volunteer.Skills;
                existingVolunteer.Availability = Volunteer.Availability;

                _db.Volunteers.Update(existingVolunteer);
            }
            else
            {
                // Option 2: Add as a new volunteer
                _db.Volunteers.Add(Volunteer);
            }

            _db.SaveChanges();
            return RedirectToPage("/Volunteers/List");
        }
    }
}
