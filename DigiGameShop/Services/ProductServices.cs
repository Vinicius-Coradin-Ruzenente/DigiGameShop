using DigiGameShop.Models;
using DigiGameShop.Interfaces;
using DigiGameShop.Database;
using Microsoft.EntityFrameworkCore;

namespace DigiGameShop.Services
{
    public class ProductServices(DigiGameShopDbContext db) : IProductServices
    {
        public readonly DigiGameShopDbContext _db = db;

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(product => product.ProductId == id);
        }
        public async Task<Product?> AddProductAsync(AddUpdateProduct newProduct)
        {
            var product = new Product
            {
                ProductName = newProduct.ProductName,
                Price = newProduct.Price,
                Brand = newProduct.Brand,
                Description = newProduct.Description,
                ProductImagePath = newProduct.ProductImagePath,
                ProductStock = newProduct.ProductStock,
            };
            await _db.Products.AddAsync(product);
            var result = await _db.SaveChangesAsync();
            return result > 0 ? product : null;
        }
        public async Task<Product?> UpdateProductAsync(int id, AddUpdateProduct updatedProduct)
        {
            var product = await _db.Products.FirstOrDefaultAsync(product => product.ProductId == id);
            if (product != null)
            {
                product.ProductName = updatedProduct.ProductName;
                product.Price = updatedProduct.Price;
                product.Brand = updatedProduct.Brand;
                product.Description = updatedProduct.Description;
                product.ProductImagePath = updatedProduct.ProductImagePath;
                product.ProductStock = updatedProduct.ProductStock;

                var result = await _db.SaveChangesAsync();
                return result > 0 ? product : null;
            }
            return null;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(product => product.ProductId == id);
            if (product != null)
            {
                _db.Products.Remove(product);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
