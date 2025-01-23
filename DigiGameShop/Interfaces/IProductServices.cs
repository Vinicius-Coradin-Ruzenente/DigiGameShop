using DigiGameShop.Models;

namespace DigiGameShop.Interfaces
{
    public interface IProductServices
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product?> AddProductAsync(AddUpdateProduct newProduct); 
        Task<Product?> UpdateProductAsync(int id, AddUpdateProduct updatedProduct);
        Task<bool> DeleteProductAsync(int id);

    }
}
