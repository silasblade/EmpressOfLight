using EmpressOfLight.Data;
using EmpressOfLight.Models;
using EmpressOfLight.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpressOfLight.Controllers
{
    [Authorize]

    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public OrderController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {

            _context = context;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            List<Order> o = new List<Order>();
            o = _context.Orders.Where(c=>c.Id == userId).ToList();
            return View(o);
        }

        public IActionResult Detail(int OrderId)
        {
            OrderDetail detail = new OrderDetail();
            detail.Order = _context.Orders.FirstOrDefault(c => c.OrderId == OrderId);
            detail.ProductOrders = _context.ProductOrders.Include(c=>c.Product).Where(c=>c.OrderId == OrderId).ToList();
            return View(detail);
        }


        [HttpPost]
        public IActionResult CashOrder(string FirstName, string LastName, string Phone, string Address, string PayMethod, string? Note)
        {
            var userId = _userManager.GetUserId(User);
            Order order = new Order();
            order.FirstName = FirstName;
            order.LastName = LastName;
            order.Phone = Phone;
            order.Address = Address;
            order.Payment = PayMethod;
            order.Note = Note ?? "";
            order.DateTime = DateTime.Now;
            order.Total = 50000;
            _context.Orders.Add(order);
            _context.SaveChanges();
            foreach (var c in _context.Carts.Include(c => c.Size).Where(p=>p.Id == userId))
            {
                ProductOrder productOrder = new ProductOrder();
                productOrder.ProductOrderId = order.OrderId + "0" + c.Size.ProductId;
                productOrder.OrderId = order.OrderId;
                productOrder.ProductId = c.Size.ProductId;
                productOrder.Quantity = c.Size.Quantity;
                productOrder.Price = c.Size.Price;
                _context.ProductOrders.Add(productOrder);
                order.Total += productOrder.Price * productOrder.Quantity;
            }
            _context.SaveChanges();
            return View();
        }
    }
}
