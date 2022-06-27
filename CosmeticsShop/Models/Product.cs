using CosmeticsShop.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmeticsShop.Models
{
    public class Product

    {
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
       
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter a product name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter product price.")]

        [NotMapped]
        public string ImageUrl
        {
            get
            {
                if (ImageHelper.CategoryImages.TryGetValue(CategoryId, out string imageUrl) && !string.IsNullOrEmpty(imageUrl))
                {
                    return imageUrl;
                }
                return string.Empty;
            }
        }

        public decimal Price { get; set; }

        public decimal DiscountPercent => .20M; // A discount 20% is hard-coded for all products

        public decimal DiscountAmount => Price * DiscountPercent;

        public decimal DiscountPrice => Price  - DiscountAmount;

        public string Slug => Name != null ? Name.Replace(" ", "-") : "";

    }
}
