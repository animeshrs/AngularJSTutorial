using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Specification;

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
            var spec = new ProductWithTypeAndBrandSpecification();
            var products = await _iProductRepository.ListAsync(spec);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductWithTypeAndBrandSpecification(id);
            var product = await _iProductRepository.GetEntityWithSpec(spec);
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
