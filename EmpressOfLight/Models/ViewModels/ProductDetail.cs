namespace EmpressOfLight.Models.ViewModels
{
    public class ProductDetail
    {
        public Product Product = new Product();
        public bool AddToCart = false;
        public List<Size> Sizes = new List<Size>();
        public Size SelectedSize = new Size();
        public bool SelectSize = false;
        public string CategoryName;
    }
}
