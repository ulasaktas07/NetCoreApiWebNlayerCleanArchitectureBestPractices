using App.Repositories.Products;
using AutoMapper;

namespace App.Services.Mapping
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<Product,ProductDto>().ReverseMap();
		}
	}
}
