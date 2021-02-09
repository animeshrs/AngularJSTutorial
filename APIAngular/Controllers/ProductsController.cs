using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _iProductRepository;

        public ProductsController(IProductRepository iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _iProductRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _iProductRepository.GetProductsByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _iProductRepository.GetProductBrandsAsync();
            return Ok(productBrands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            var productTypes = await _iProductRepository.GetProductTypesAsync();
            return Ok(productTypes);
        }

    }
}
