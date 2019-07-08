using AutoMapper;
using System.Collections.Generic;
using Store.Dtos.Concrete;
using Store.Entities.Concrete;

namespace Store.Business.Mappings.AutoMapper.Profiles
{
    public class BusinesProfile : Profile
    {
        public BusinesProfile()
        {
            CreateMap<Product, Product>();
            CreateMap<List<Product>, List<Product>>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>().ForMember(dest => dest.CategoryName, o => o.MapFrom(s => s.Category.CategoryName));
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
