using EmpressOfLight.Data;
using EmpressOfLight.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EmpressOfLight.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ProductController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {

            _context = context;
            this._userManager = userManager;
        }

        public IActionResult Index(int productid, string? sizename, string id)
        {
            var UserId = _userManager.GetUserId(User);
            var Carts = _context.Carts.Where(c => c.Id == UserId).ToList();
            ViewBag.ShopCount = Carts.Count;


            var p = _context.Products.FirstOrDefault(c => c.ProductId == productid);
            var l = _context.Sizes.ToList();

            ProductDetail productDetail = new ProductDetail();
            productDetail.Product = p;
            productDetail.Sizes = l.Where(c => c.ProductId == p.ProductId).ToList();
            if(!sizename.IsNullOrEmpty())
            {
                productDetail.SelectedSize = productDetail.Sizes.FirstOrDefault(c => c.SizeName.Equals(sizename));
                Console.WriteLine(productDetail.SelectedSize.SizeId);
                if (productDetail.SelectedSize != null)
                {
                    productDetail.AddToCart = true;
                    productDetail.SelectSize = true;
                }
                else
                {
                    productDetail.SelectSize = false;

                }
            }
            productDetail.CategoryName = _context.Categories.FirstOrDefault(c => c.CategoryId == p.CategoryId).CategoryName;
            return View(productDetail);
        }
    }
}
