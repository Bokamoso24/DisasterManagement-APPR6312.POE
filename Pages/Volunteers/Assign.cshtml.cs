using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using DisasterManagementApp.Data;
using DisasterManagementApp.Models;
using System.Linq;
using System;

namespace DisasterManagementApp.Pages.Volunteers
{
    public class AssignModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public AssignModel(ApplicationDbContext db) => _db = db;

        public IQueryable<Project> Projects => _db.Projects.AsQueryable();
        public IQueryable<Volunteer> Volunteers => _db.Volunteers.AsQueryable();

        [BindProperty] public int SelectedVolunteer { get; set; }
        [BindProperty] public int SelectedProject { get; set; }
        public void OnGet() { }

        public IActionResult OnPost()
        {
            var va = new VolunteerAssignment
            {
                VolunteerID = SelectedVolunteer,
                ProjectID = SelectedProject,
                AssignedDate = DateTime.UtcNow
            };
            _db.VolunteerAssignments.Add(va);
            _db.SaveChanges();
            return RedirectToPage("/Volunteers/ListAssignments");
        }
    }
}
