using Core.Entities;

namespace Core.Specification
{
    public class ProductWithTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductWithTypeAndBrandSpecification(ProductSpecParams productSpecParams)
            : base(x =>
                 (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
                 && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId)
                 && (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)))
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging((productSpecParams.PageSize * (productSpecParams.PageIndex - 1)),
                productSpecParams.PageSize);

            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDessc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductWithTypeAndBrandSpecification(int id)
            : base(p => p.Id == id)
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
        }
    }
}
