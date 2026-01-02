using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
     public interface IProductRepository
    {
        Task<IReadOnlyList<ProductDTO>> GetProductsAsync(string? brand, string? type, string? sort);
        Task<ProductDTO?> GetProductByIdAsync(int id);
        void AddProduct(ProductDTO product);

        Task<IReadOnlyList<string>> GetBrandsAsync();
        Task<IReadOnlyList<string>> GetTypesAsync();
        void UpdateProduct(ProductDTO product);
        void DeleteProduct(ProductDTO product);
        bool ProductExists(int id);
        Task<bool> SaveChangesAsync();
    }
}
