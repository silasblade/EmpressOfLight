using EmpressOfLight.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpressOfLight.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CheckoutController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {

            _context = context;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            var UserId = _userManager.GetUserId(User);
            var Carts = _context.Carts.Include(c => c.Size).ThenInclude(m => m.Product).ToList();
            return View(Carts);
        }

        public IActionResult OrderDetail()
        {
            var UserId = _userManager.GetUserId(User);
            var Carts = _context.Carts.Include(c => c.Size).ThenInclude(m => m.Product).ToList();
            return View(Carts);
        }
    }
}
