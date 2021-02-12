using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAngular.Dtos;
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
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductWithTypeAndBrandSpecification();
            var products = await _iProductRepository.ListAsync(spec);
            var productDtos = products
                .Select(p => new ProductToReturnDto
                {
                    ProductType = p.ProductType.Name,
                    ProductBrand = p.ProductBrand.Name,
                    Description = p.Description,
                    Id = p.Id,
                    Name = p.Name,
                    PictureUrl = p.PictureUrl,
                    Price = p.Price
                }).ToList();
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypeAndBrandSpecification(id);
            var product = await _iProductRepository.GetEntityWithSpec(spec);
            var productDto = new ProductToReturnDto
            {
                ProductType = product.ProductType.Name,
                ProductBrand = product.ProductBrand.Name,
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
                PictureUrl = product.PictureUrl,
                Price = product.Price
            };
            return Ok(productDto);
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
