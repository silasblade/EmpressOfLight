using Microsoft.AspNetCore.Mvc;

namespace EmpressOfLight.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
