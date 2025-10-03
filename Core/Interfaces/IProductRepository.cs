namespace Core.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Entities.Product>> GetProductsAsync(string? brand, string? type, string? sort);
    Task<Entities.Product?> GetProductByIdAsync(int id);
    Task<IReadOnlyCollection<string>> GetBrandsAsync();
    Task<IReadOnlyCollection<string>> GetTypesAsync();
    void AddProduct(Entities.Product product);
    void UpdateProduct(Entities.Product product);
    void DeleteProduct(Entities.Product product);
    bool ProductExists(int id);
    Task<bool> SaveChangesAsync();
}
