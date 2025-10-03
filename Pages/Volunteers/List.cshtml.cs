using Microsoft.AspNetCore.Mvc.RazorPages;
using DisasterManagementApp.Data;
using DisasterManagementApp.Models;
using System.Linq;

namespace DisasterManagementApp.Pages.Volunteers
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ListModel(ApplicationDbContext db) => _db = db;

        public IQueryable<Volunteer> Volunteers { get; set; }

        public void OnGet()
        {
            Volunteers = _db.Volunteers.AsQueryable();
        }
    }
}
