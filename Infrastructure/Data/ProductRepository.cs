using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(x=>x.ProductBrand)
                .Include(x=>x.ProductType)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(x=>x.ProductType)
                .Include(x=>x.ProductBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBand>> GetProductsBrandsAsync()
        {
            return await _context.ProductBands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}