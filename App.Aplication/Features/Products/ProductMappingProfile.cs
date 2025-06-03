﻿using App.Aplication.Features.Products.Create;
using App.Aplication.Features.Products.Dto;
using App.Aplication.Features.Products.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Aplication.Features.Products
{
	public class ProductMappingProfile:Profile
	{
		public ProductMappingProfile()
		{
			CreateMap<Product,ProductDto>().ReverseMap();
			CreateMap<CreateProductRequest, Product>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
			CreateMap<UpdateProductRequest, Product>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
		}
	}
}
