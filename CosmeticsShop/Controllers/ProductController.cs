using CosmeticsShop.Models;
using CosmeticsShop.Services;
using CosmeticsShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticsShop.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext context;

        public ProductController(ProductContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(string id = "All")
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryId)
                .ToList();

            var selectedCategory = categories.FirstOrDefault(c => c.Name == id);

            var image = "";
            if (selectedCategory != null)
            {
                ImageHelper.CategoryImages.TryGetValue(selectedCategory.CategoryId, out image);
            }
            else
            {
                ImageHelper.CategoryImages.TryGetValue(0, out image);
            }

            var vm = new ProductListViewModel();
            vm.Products = new List<Product>();
            if (id == "All")
            {
                vm.Products = context.Products
                     .OrderBy(p => p.ProductId)
                     .ToList();

            }
            else
            {
                vm.Products = context.Products
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.ProductId)
                    .ToList();

            }
            vm.Categories = categories;
            vm.SelectedCategoryName = id;
            vm.ImageCategory = image;
            return View(vm);

        }

        public IActionResult Details(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }

     
    }
}
