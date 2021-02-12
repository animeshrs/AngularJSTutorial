using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAngular.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;


        public ProductsController(IGenericRepository<Product> iProductRepository,
            IGenericRepository<ProductType> iProductTypeRepository,
            IGenericRepository<ProductBrand> iProductBrandRepository,
            IMapper mapper)
        {
            _iProductRepository = iProductRepository;
            _iProductTypeRepository = iProductTypeRepository;
            _iProductBrandRepository = iProductBrandRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductWithTypeAndBrandSpecification();
            var products = await _iProductRepository.ListAsync(spec);
            var productDtos = products.Select(_mapper.Map<Product, ProductToReturnDto>).ToList();
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypeAndBrandSpecification(id);
            var product = await _iProductRepository.GetEntityWithSpec(spec);
            var productDto = _mapper.Map<Product, ProductToReturnDto>(product);
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
