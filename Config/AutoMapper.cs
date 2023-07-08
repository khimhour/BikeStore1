using AutoMapper;
using BikeStores1.Dto;
using BikeStores1.Models;

namespace BikeStores1.Config
{
    public class AutoMapper : Profile
    {

        public AutoMapper() 
        {
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap(); 
            
        } 

    }
}
