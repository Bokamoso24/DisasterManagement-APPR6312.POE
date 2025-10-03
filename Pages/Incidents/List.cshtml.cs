using Microsoft.AspNetCore.Mvc.RazorPages;
using DisasterManagementApp.Data;
using System.Collections.Generic;
using DisasterManagementApp.Models;
using System.Linq;

namespace DisasterManagementApp.Pages.Incidents
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Incident> Incidents { get; set; }
        public ListModel(ApplicationDbContext db) => _db = db;
        public void OnGet() => Incidents = _db.Incidents.OrderByDescending(i => i.ReportDate).ToList();
    }
}
