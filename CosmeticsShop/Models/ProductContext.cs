using Microsoft.EntityFrameworkCore;

namespace CosmeticsShop.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var decimalProps = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1, Name = "Mascara"
                }
                , new Category
                {
                    CategoryId = 2, Name = "Lipstick"
                }
                , new Category
                {
                    CategoryId = 3, Name = "Eye Shadows"
                }
                , new Category
                {
                    CategoryId = 4, Name = "Blush"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Lancome Defincials High Definition",
                    Price = (decimal)35.5
                    }, new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    Name = "Maybeline Great Lash",
                    Price = (decimal)7.99
                    }, new Product
                {
                    ProductId = 3,
                    CategoryId =1 ,
                    Name = "Chanel Inimitable",
                    Price = (decimal)22
                    }, new Product
                {
                    ProductId = 4,
                    CategoryId = 1,
                    Name = "Giorgio Armani Eyes to Kill",
                    Price = (decimal)29
                    }, new Product
                {
                    ProductId = 5,
                    CategoryId = 1,
                    Name = "L’Oreal Voluminous",
                    Price = (decimal)9.99
                    }, new Product
                {
                    ProductId = 6,
                    CategoryId = 1,
                    Name = "Dior Diorshow",
                    Price = (decimal)29.5
                    }, new Product
                {
                    ProductId = 7,
                    CategoryId = 1,
                    Name = "Guerlain Noir G",
                    Price = (decimal)33
                    }, new Product
                {
                    ProductId = 8,
                    CategoryId = 2,
                    Name = "Dior Addict Lip Tint In Natural Rosewood",
                    Price = (decimal)35
                    }, new Product
                {
                    ProductId = 9,
                    CategoryId = 2,
                    Name = "YSL Beauty Water Stain In Ruby Wave",
                    Price = (decimal)39
                    }, new Product
                {
                    ProductId = 10,
                    CategoryId = 2,
                    Name = "Charlotte Tilbury Matte Revolution",
                    Price = (decimal)34
                    }, new Product
                {
                    ProductId = 11,
                    CategoryId = 2,
                    Name = "Armani Beauty Lip Power Long Lasting Satin",
                    Price = (decimal)33
                    }, new Product
                {
                    ProductId = 12,
                    CategoryId = 3,
                    Name = "MAC Eyeshadow",
                    Price = (decimal)18
                    },
                new Product
                {
                    ProductId = 13,
                    CategoryId = 3,
                    Name = "Urban Decay Naked3 Palette",
                    Price = (decimal)54
                },
                new Product
                {
                    ProductId = 14,
                    CategoryId = 3,
                    Name = "Urban Decay Naked3 Palette",
                    Price = (decimal)54
                }
                ,
                new Product
                {
                    ProductId = 15,
                    CategoryId = 3,
                    Name = "NYX Professional Makeup Ultimate Shadow Palette",
                    Price = (decimal)14.99
                },
                new Product
                {
                    ProductId = 16,
                    CategoryId = 3,
                    Name = "Make Up For Ever Artist Color Eye Shadow",
                    Price = (decimal)17
                },
                new Product
                {
                    ProductId = 17,
                    CategoryId = 3,
                    Name = "e.l.f. Cosmetics Bite Size Eyeshadow Palette",
                    Price = (decimal)3
                },
                new Product
                {
                    ProductId = 18,
                    CategoryId = 4,
                    Name = "Milani Cheek Kiss Blush",
                    Price = (decimal)10
                },
                new Product
                {
                    ProductId = 19,
                    CategoryId = 4,
                    Name = "Victoria Beckham Beauty Cheeky Posh Cream",
                    Price = (decimal)42
                },
                new Product
                {
                    ProductId = 20,
                    CategoryId = 4,
                    Name = "Anastasia Beverly Hills Stick",
                    Price = (decimal)32
                }
            );
        }

       
    }
}
