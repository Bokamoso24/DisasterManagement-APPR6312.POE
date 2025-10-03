using Microsoft.AspNetCore.Mvc.RazorPages;
using DisasterManagementApp.Data;
using DisasterManagementApp.Models;
using System.Linq;

namespace DisasterManagementApp.Pages.Donations
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ListModel(ApplicationDbContext db) => _db = db;

        public IQueryable<Donation> Donations { get; set; }

        public void OnGet()
        {
            Donations = _db.Donations.AsQueryable();
        }
    }
}
