using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {          
            var produucts = await _repo.GetProductsAsync();
            return Ok(produucts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {          
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet ("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductsBrandsAsync());
        }

        [HttpGet ("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}