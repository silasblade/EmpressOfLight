using EmpressOfLight.Data;
using EmpressOfLight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpressOfLight.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {

            _context = context;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {

            var UserId = _userManager.GetUserId(User);
            var Carts = _context.Carts.Include(c=>c.Size).ThenInclude(m=>m.Product).Where(n=>n.Id==UserId).ToList();
            
            //Carts = Carts.Where(c=>c.Id == UserId).ToList();
            return View(Carts);
        }

        public bool CheckCartExist(string CartId)
        {
            foreach (var cart in _context.Carts)
            {
                if(cart.CartId == CartId) return true;
            }
            return false;
        }

        public IActionResult ChangeQuantity(int Number, string CartId)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.CartId == CartId);
            if(Number <= 0) _context.Carts.Remove(cart);
            cart.Quantity = Number;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult AddToCart(string SizeId)
        {
            var UserId = _userManager.GetUserId(User);
            var CartId = UserId + SizeId;
            if(!CheckCartExist(CartId))
            {
                Cart cart = new Cart();
                cart.SizeId = SizeId;
                cart.Id = UserId;
                cart.CartId = CartId;
                cart.Quantity = 1;
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            else
            {
                Cart cart = _context.Carts.FirstOrDefault(c => c.CartId == CartId);
                cart.Quantity++;
                _context.SaveChanges();
            }    
            return RedirectToAction("Index");
        }
        
        
    }
}
