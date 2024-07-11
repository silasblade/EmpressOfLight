using EmpressOfLight.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EmpressOfLight.Models;
using System.Diagnostics;
using EmpressOfLight.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace EmpressOfLight.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ShopController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {

            _context = context;
            this._userManager = userManager;
        }
        public IActionResult Pagination()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Index(int? page, string? name,int? Sort, int? categoryId , float? pricemin, float? pricemax)
        {
            var UserId = _userManager.GetUserId(User);
            var Carts = _context.Carts.Where(c => c.Id == UserId).ToList();
            ViewBag.ShopCount = Carts.Count;

            ShopFilter shopFilter = new ShopFilter();
            shopFilter.Page = page ?? 0;
            shopFilter.Name = name ?? "";
            shopFilter.PriceMax = pricemax ?? 0;
            shopFilter.PriceMin = pricemin ?? 0;
            shopFilter.Sort = Sort ?? 0;

            var categories = _context.Categories.ToList();
            var products = _context.Products.ToList();
            int listsize = products.Count;

            shopFilter.categories = categories;
            var tempShop = products;

            if (categoryId.HasValue && categoryId!=0)
            {
                shopFilter.CategoryId = categoryId.Value;
                tempShop = tempShop.Where(products => products.CategoryId == categoryId).ToList();
            }    
            if(!name.IsNullOrEmpty())
            {
                shopFilter.Name = name;
                tempShop = tempShop.Where(c => c.ProductName.Contains(name)).ToList();
            }    
            if(pricemin.HasValue)
            {
                shopFilter.PriceMin = pricemin.Value;
                tempShop = tempShop.Where(c => c.PricePreview >=  pricemin.Value).ToList();
            }    
            if(pricemax.HasValue && pricemax != 0)
            {
                shopFilter.PriceMax = pricemax.Value;
                tempShop = tempShop.Where(c => c.PricePreview <= pricemax.Value).ToList();
            }
            if (Sort.HasValue)
            {
                shopFilter.Sort = Sort.Value;
                switch (Sort.Value)
                {
                    case 0: break;
                    case 1: tempShop = tempShop.OrderBy(c => c.ProductName).ToList(); break;
                    case 2: tempShop = tempShop.OrderByDescending(c => c.ProductName).ToList(); break;
                    case 3: tempShop = tempShop.OrderBy(p => p.PricePreview).ToList(); break;
                    case 4: tempShop = tempShop.OrderByDescending(p => p.PricePreview).ToList(); break;
                    default: break;
                }
            }

            for (int i = shopFilter.Page*9; i< shopFilter.Page * 9+9; i++)
            {
                if(i<tempShop.Count) shopFilter.products.Add(tempShop[i]);
            }
            shopFilter.TotalPage = (int)Math.Ceiling((double)tempShop.Count / 9);
            if (shopFilter.TotalPage <= shopFilter.Page) shopFilter.Page = 0;
            return View(shopFilter);
        }

    }
}
