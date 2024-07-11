namespace EmpressOfLight.Models.ViewModels
{
    public class ShopFilter
    {
        public List<Product> products = new List<Product>();
        public int Page = 0;
        public int TotalPage = 0;
        public string Name = "";
        public float PriceMax = 0;
        public float PriceMin = 0;
        public int CategoryId = 0;
        //1 = A->Z, 2=Z->A, 3=High->Low, 4=Low->High
        public int Sort = 0;
        public List<Category> categories = new List<Category>();
    }
}
