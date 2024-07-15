using EmpressOfLight.Data;
using EmpressOfLight.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EmpressOfLight.Controllers
{
    public class EmailSubController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmailSubController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe(string Email)
        {
            if (!string.IsNullOrEmpty(Email))
            {
                var subscription = new EmailSub { Email = Email };

                _context.EmailSub.Add(subscription);
                _context.SaveChanges();

                return Json(new { success = true, message = "Thank you for subscribing!" });
            }
            else
            {
                return Json(new { success = false, message = "Please enter a valid email address." });
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ExportEmails()
        {
            var emails = _context.EmailSub.Select(e => e.Email).ToList();

            var csvContent = new StringBuilder();
            csvContent.AppendLine("Email");

            foreach (var email in emails)
            {
                var normalizedEmail = NormalizeEmail(email);
                csvContent.AppendLine($"{normalizedEmail}");
            }

            byte[] fileContents = Encoding.UTF8.GetBytes(csvContent.ToString());
            return File(fileContents, "text/csv", "emails.csv");
        }

        private string NormalizeEmail(string email)
        {
            return email.Trim().ToLower();
        }

    }
}
