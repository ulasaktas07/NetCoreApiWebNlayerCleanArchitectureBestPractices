using App.Aplication.Features.Categories.Create;
using App.Aplication.Features.Categories.Dto;
using App.Aplication.Features.Categories.Update;
using App.Domain.Entities;
using AutoMapper;
namespace App.Aplication.Features.Categories
{
	public class CategoryMappingProfile:Profile
	{
		public CategoryMappingProfile()
		{
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Category, CategoryWithProductsDto>().ReverseMap();
			CreateMap<CreateCategoryRequest, Category>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
			CreateMap<UpdateCategoryRequest, Category>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
		}
	}
}
