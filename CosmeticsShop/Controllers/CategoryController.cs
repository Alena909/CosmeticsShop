using CosmeticsShop.Models;
using CosmeticsShop.Services;
using CosmeticsShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticsShop.Controllers
{
    public class CategoryController : Controller

    {
        private ProductContext context;

        public CategoryController (ProductContext ctx)
        {
            context = ctx;
        }


        public IActionResult Index()
        {
            return RedirectToAction("List", "Category");
        }

        public IActionResult List(string id = "All")
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

            var vm = new CategoryListViewModel();
            
            vm.Categories = categories;
           vm.ImageCategory = image;
            return View(vm);

        }
    }
}
