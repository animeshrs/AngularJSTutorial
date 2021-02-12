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
        private readonly IGenericRepository<Product> _iProductRepository;
        private readonly IGenericRepository<ProductType> _iProductTypeRepository;
        private readonly IGenericRepository<ProductBrand> _iProductBrandRepository;


        public ProductsController(IGenericRepository<Product> iProductRepository,
            IGenericRepository<ProductType> iProductTypeRepository,
            IGenericRepository<ProductBrand> iProductBrandRepository)
        {
            _iProductRepository = iProductRepository;
            _iProductTypeRepository = iProductTypeRepository;
            _iProductBrandRepository = iProductBrandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {

            var products = await _iProductRepository.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _iProductRepository.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _iProductBrandRepository.ListAllAsync();
            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            var productTypes = await _iProductTypeRepository.ListAllAsync();
            return Ok(productTypes);
        }

    }
}
