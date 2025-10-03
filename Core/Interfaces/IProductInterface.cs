using Core.Entities;

namespace Core.Interfaces;

public interface IProductInterface
{
    void AddProduct(Product product);
    void DeleteProduct(Product product);
    Task<IReadOnlyCollection<string>> GetBrandsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetProductsAsync();
    Task<IReadOnlyCollection<string>> GetTypesAsync();
    bool ProductExists(int id);
    Task<bool> SaveChangesAsync();
    void UpdateProduct(Product product);
}
