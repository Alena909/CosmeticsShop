using CosmeticsShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticsShop.Controllers
{
    public class CartController : Controller

    {
        private ProductContext context;
        public CartController(ProductContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            decimal total = 0;
            foreach (var product in Cart.Products)
            {
                total += product.Price;
            }
            ViewBag.Total = total;
            return View(Cart.Products);
        }

        public IActionResult Add(int id)
        {
            Product product = context.Products.Find(id);
            Cart.Products.Add(product);
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product=context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            var deleteProduct = Cart.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (deleteProduct != null)
            {
                Cart.Products.Remove(deleteProduct);
            }

            return RedirectToAction("Index", "Cart");
        }
    }
}
