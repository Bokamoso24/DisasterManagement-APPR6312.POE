using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DisasterManagementApp.Data;
using DisasterManagementApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

namespace DisasterManagementApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IPasswordHasher<User> _hasher;

        public RegisterModel(ApplicationDbContext db, IPasswordHasher<User> hasher)
        {
            _db = db;
            _hasher = hasher;
        }

        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get; set; }
        [BindProperty] public string RoleName { get; set; } = "Volunteer"; // default

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (_db.Users.Any(u => u.Email == Email))
            {
                ModelState.AddModelError("", "Email already in use.");
                return Page();
            }

            var role = _db.Roles.FirstOrDefault(r => r.RoleName == RoleName) ?? _db.Roles.First();
            var user = new User { Name = Name, Email = Email, RoleID = role.RoleID };
            user.PasswordHash = _hasher.HashPassword(user, Password);

            _db.Users.Add(user);
            _db.SaveChanges();

            return RedirectToPage("/Account/Login");
        }
    }
}
