using CRN_Assesment.Dtos;

namespace CRN_Assesment
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<ProductDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateProductDto dto);

        Task UpdateAsync(int id, UpdateProductDto dto);

        Task DeleteAsync(int id);
    }
}
