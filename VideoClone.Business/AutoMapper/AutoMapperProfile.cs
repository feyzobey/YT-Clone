using AutoMapper;
using VideoClone.Core.Entities.Concrete;
using VideoClone.Entities.Concrete;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryCreateUpdateDto, Category>();

        CreateMap<User, CurrentUserDto>();
    }
}