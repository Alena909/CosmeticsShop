using System.ComponentModel.DataAnnotations;
using CosmeticsShop.Services;

namespace CosmeticsShop.Models
{
    public class Category

    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please select category.")]
        public string Name { get; set; }

        public string ImageUrl  => ImageHelper.CategoryImages[CategoryId];

    }
}
