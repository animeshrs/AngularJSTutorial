using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productSpecParams)
         : base(x =>
                 (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
                 && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId)
                 && (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)))
        {

        }
    }
}