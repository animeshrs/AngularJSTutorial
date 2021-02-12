using APIAngular.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace APIAngular.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _iConfiguration;

        public ProductUrlResolver(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source.PictureUrl))
                return _iConfiguration["ApiUrl"] + source.PictureUrl;

            return null;
        }
    }
}
