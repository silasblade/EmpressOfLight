using EmpressOfLight.Models.ViewModels;

namespace EmpressOfLight.Services
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(HttpContext context, VnPayRequestModel model);
        VnPaymentResponseModel PaymentExcecute(IQueryCollection collections);
    }
}