using CRN_Assesment.Dtos;
using CRN_Assesment.Domain;

namespace CRN_Assesment
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ApplicationDbContext _context;

        public ProductService(
            IProductRepository repository,
            ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<int> CreateAsync(
            CreateProductDto dto)
        {
            Product product = new()
            {
                ProductName = dto.ProductName,
                CreatedBy = "Admin",
                CreatedOn = DateTime.UtcNow
            };

            await _repository.AddAsync(product);

            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            _repository.Delete(product);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName
            });
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName
            };
        }

        public async Task UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                throw new Exception("Product not found");

            product.ProductName = dto.ProductName;
            product.ModifiedOn = DateTime.UtcNow;
            product.ModifiedBy = "Admin";

            _repository.Update(product);

            await _context.SaveChangesAsync();
        }
    }
}

