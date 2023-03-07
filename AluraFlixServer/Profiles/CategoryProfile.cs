using AluraFlixServer.Dtos;
using AluraFlixServer.Models;
using AutoMapper;

namespace AluraFlixServer.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, ReadCategoryDTO>();
        CreateMap<CategoryDTO, Category>();
        CreateMap<Category, CategoryDTO>();
    }
}
