﻿using APIAngular.Dtos;
using AutoMapper;
using Core.Entities;

namespace APIAngular.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dest => dest.ProductType,
                    opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.ProductBrand,
                    opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>())
                ;
        }
    }
}
