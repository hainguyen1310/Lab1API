using AutoMapper;
using BusinessLogic.Models;
using ShopDTO;

namespace Lab1API.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Product, ProductDTO>().ForMember(d=> d.CategoryName, o => o.MapFrom(src => src.Category.CategoryName));
        }
    }
}
