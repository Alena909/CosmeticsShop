using CosmeticsShop.Models;


namespace CosmeticsShop.ViewModels
{
    public class ProductListViewModel
    
    {
        public List<Category> Categories { get; set; }
        public string SelectedCategoryName { get; set; }
        public string ImageCategory { get; set; }   

        public List<Product> Products { get; set; }

    }
}
