using ProductAPI.Domain.DTOs;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<ProductDTO> AddProductAsync(CreateProductDTO newProductDto);
        Task<bool> DeleteProductAsync(int id);
    }
}