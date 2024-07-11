namespace EmpressOfLight.Models.ViewModels
{
    public class OrderDetail
    {
        public Order Order = new Order();
        public List<ProductOrder> ProductOrders = new List<ProductOrder>();
    }
}
