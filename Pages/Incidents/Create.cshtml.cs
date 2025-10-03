using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DisasterManagementApp.Data;
using DisasterManagementApp.Models;
using System;
using System.Security.Claims;

namespace DisasterManagementApp.Pages.Incidents
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db) => _db = db;

        [BindProperty] public Incident Incident { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            // set reporter if logged-in
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdClaim, out int uid)) Incident.ReporterID = uid;

            Incident.ReportDate = DateTime.UtcNow;
            _db.Incidents.Add(Incident);
            _db.SaveChanges();
            return RedirectToPage("/Incidents/List");
        }
    }
}
