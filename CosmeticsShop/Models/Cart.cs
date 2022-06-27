namespace CosmeticsShop.Models
{
    public class Cart
    {
        public static List<Product> Products = new List<Product>();

        public static List<Product> GetProducts()
        {
            return Products;
        }

        public static void SetProducts(List<Product> products)
        {
            Cart.Products = products;
        }

        public static decimal TotalPrice()
        {
            decimal total = 0;
            for (int i = 0; i < Products.Count; ++i)
            {
                total += Products[i].DiscountPrice;
            }
            return total;
        }


    }
}
