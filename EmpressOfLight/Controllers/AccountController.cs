using Microsoft.AspNetCore.Mvc;
using EmpressOfLight.Services;
using System.Threading.Tasks;

namespace EmpressOfLight.Controllers
{
    public class AccountController : Controller
    {
        private readonly TwilioService _twilioService;

        public AccountController(TwilioService twilioService)
        {
            _twilioService = twilioService;
        }

        [HttpPost]
        public async Task<IActionResult> ContactForm(string name, string email, string message)
        {
            string phoneNumber = "+84******"; // Số điện thoại nhận tin nhắn
            string smsMessage = $"Name: {name}\nEmail: {email}\nMessage: {message}";

            _twilioService.SendSms(phoneNumber, smsMessage);

            return RedirectToAction("ContactConfirmation");
        }

        public IActionResult ContactConfirmation()
        {
            return View();
        }
    }
}
