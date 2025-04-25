using AMA.WarehouseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMA.WarehouseManagement.Application.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<CapacityProduct> GetCapacityProducts(Expression<Func<CapacityProduct, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductRange(int offset, int limit)
        {
            return SeedData();// This should done by the injected repository. But for this sample we won't implement any repository.
        }

        public IEnumerable<QuantityProduct> GetQuantityProducts(Expression<Func<QuantityProduct, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void SetProductCapacity(int productId, int capacity)
        {
            throw new NotImplementedException();
        }

        public void SetProductQuantity(int productId, int expectedQty)
        {
            throw new NotImplementedException();
        }

        private List<Product> SeedData()
        {
            var products = new List<Product>
                {
                    new Product { ProductId = 1, ProductName = "Wireless Mouse", ProductDescription = "Ergonomic wireless mouse with USB receiver", ProductCategory = "Electronics", Price = 29.99 },
                    new Product { ProductId = 2, ProductName = "Bluetooth Headphones", ProductDescription = "Noise-cancelling headphones with Bluetooth 5.0", ProductCategory = "Electronics", Price = 89.99 },
                    new Product { ProductId = 3, ProductName = "Gaming Keyboard", ProductDescription = "Mechanical RGB gaming keyboard", ProductCategory = "Electronics", Price = 69.99 },
                    new Product { ProductId = 4, ProductName = "LED Monitor", ProductDescription = "24-inch 1080p LED monitor", ProductCategory = "Electronics", Price = 149.99 },
                    new Product { ProductId = 5, ProductName = "USB-C Charger", ProductDescription = "Fast charging 30W USB-C charger", ProductCategory = "Electronics", Price = 19.99 },
                    new Product { ProductId = 6, ProductName = "Notebook A5", ProductDescription = "120-page lined notebook", ProductCategory = "Stationery", Price = 4.50 },
                    new Product { ProductId = 7, ProductName = "Ballpoint Pens", ProductDescription = "Pack of 10 smooth-writing pens", ProductCategory = "Stationery", Price = 3.99 },
                    new Product { ProductId = 8, ProductName = "Desk Organizer", ProductDescription = "Multi-compartment desk organizer", ProductCategory = "Stationery", Price = 12.99 },
                    new Product { ProductId = 9, ProductName = "Sticky Notes", ProductDescription = "Colorful sticky notes pack", ProductCategory = "Stationery", Price = 2.50 },
                    new Product { ProductId = 10, ProductName = "Fountain Pen", ProductDescription = "Metal body fountain pen with refill", ProductCategory = "Stationery", Price = 14.99 },
                    new Product { ProductId = 11, ProductName = "Ceramic Mug", ProductDescription = "350ml matte finish mug", ProductCategory = "Kitchen", Price = 9.99 },
                    new Product { ProductId = 12, ProductName = "Stainless Steel Knife Set", ProductDescription = "5-piece kitchen knife set", ProductCategory = "Kitchen", Price = 39.99 },
                    new Product { ProductId = 13, ProductName = "Cutting Board", ProductDescription = "Large bamboo cutting board", ProductCategory = "Kitchen", Price = 15.99 },
                    new Product { ProductId = 14, ProductName = "Non-Stick Frying Pan", ProductDescription = "30cm non-stick frying pan", ProductCategory = "Kitchen", Price = 27.99 },
                    new Product { ProductId = 15, ProductName = "Measuring Cups", ProductDescription = "Stainless steel measuring cups set", ProductCategory = "Kitchen", Price = 11.99 },
                    new Product { ProductId = 16, ProductName = "Yoga Mat", ProductDescription = "Non-slip 6mm yoga mat", ProductCategory = "Fitness", Price = 24.99 },
                    new Product { ProductId = 17, ProductName = "Dumbbell Set", ProductDescription = "Adjustable dumbbells (2x10kg)", ProductCategory = "Fitness", Price = 59.99 },
                    new Product { ProductId = 18, ProductName = "Jump Rope", ProductDescription = "Adjustable speed rope", ProductCategory = "Fitness", Price = 7.99 },
                    new Product { ProductId = 19, ProductName = "Resistance Bands", ProductDescription = "Set of 5 resistance bands", ProductCategory = "Fitness", Price = 14.50 },
                    new Product { ProductId = 20, ProductName = "Fitness Tracker", ProductDescription = "Waterproof fitness band with heart rate monitor", ProductCategory = "Fitness", Price = 49.99 },
                    new Product { ProductId = 21, ProductName = "Bluetooth Speaker", ProductDescription = "Portable Bluetooth speaker", ProductCategory = "Electronics", Price = 39.99 },
                    new Product { ProductId = 22, ProductName = "Portable Power Bank", ProductDescription = "10000mAh USB power bank", ProductCategory = "Electronics", Price = 25.99 },
                    new Product { ProductId = 23, ProductName = "Smart LED Bulb", ProductDescription = "Wi-Fi enabled multicolor smart bulb", ProductCategory = "Electronics", Price = 13.99 },
                    new Product { ProductId = 24, ProductName = "Laptop Stand", ProductDescription = "Adjustable aluminum laptop stand", ProductCategory = "Electronics", Price = 22.99 },
                    new Product { ProductId = 25, ProductName = "Wireless Charger", ProductDescription = "Qi-certified fast wireless charger", ProductCategory = "Electronics", Price = 18.99 },
                    new Product { ProductId = 26, ProductName = "Spiral Notebook", ProductDescription = "200-page college-ruled notebook", ProductCategory = "Stationery", Price = 5.99 },
                    new Product { ProductId = 27, ProductName = "Erasable Highlighters", ProductDescription = "6-pack erasable pastel highlighters", ProductCategory = "Stationery", Price = 6.49 },
                    new Product { ProductId = 28, ProductName = "Laptop Backpack", ProductDescription = "Water-resistant backpack with USB port", ProductCategory = "Accessories", Price = 42.00 },
                    new Product { ProductId = 29, ProductName = "Sports Water Bottle", ProductDescription = "BPA-free leakproof bottle (750ml)", ProductCategory = "Fitness", Price = 12.95 },
                    new Product { ProductId = 30, ProductName = "Phone Tripod", ProductDescription = "Flexible mini tripod with phone mount", ProductCategory = "Photography", Price = 16.75 },
                };

            return products;
        }
       
    }
}
