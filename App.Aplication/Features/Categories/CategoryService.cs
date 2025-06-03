using App.Aplication.Contract.Persistence;
using App.Aplication.Features.Categories.Create;
using App.Aplication.Features.Categories.Dto;
using App.Aplication.Features.Categories.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Aplication.Features.Categories
{
	public class CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
	{
		public async Task<ServiceResult<CategoryWithProductsDto>> GetCategoryWithProductsAsync(int id)
		{
			var category = await categoryRepository.GetCategoryWithProductsAsync(id);
			if (category is null)
			{
				return ServiceResult<CategoryWithProductsDto>.Fail("Kategori bulunamadı.", HttpStatusCode.NotFound);
			}
			var categoryWithProductsDto = mapper.Map<CategoryWithProductsDto>(category);
			return ServiceResult<CategoryWithProductsDto>.Success(categoryWithProductsDto);
		}

		public async Task<ServiceResult<List<CategoryWithProductsDto>>> GetAllCategoriesWithProductsAsync()
		{
			var categories = await categoryRepository.GetCategoryByProductsAsync();
			var categoriesWithProductsDto = mapper.Map<List<CategoryWithProductsDto>>(categories);
			return ServiceResult<List<CategoryWithProductsDto>>.Success(categoriesWithProductsDto);
		}

		public async Task<ServiceResult<List<CategoryDto>>> GetAllListAsync()
		{
			var categories = await categoryRepository.GetAllAsync();
			var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);
			return ServiceResult<List<CategoryDto>>.Success(categoriesAsDto);
		}

		public async Task<ServiceResult<CategoryDto>> GetByIdAsync(int id)
		{
			var category = await categoryRepository.GetByIdAsync(id);
			if (category is null)
			{
				return ServiceResult<CategoryDto>.Fail("Kategori bulunamadı.", HttpStatusCode.NotFound);
			}
			var categoryDto = mapper.Map<CategoryDto>(category);
			return ServiceResult<CategoryDto>.Success(categoryDto);
		}


		public async Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request)
		{
			var anyCategory = await categoryRepository.AnyAsync(x => x.Name == request.Name);
			if (anyCategory)
			{
				return ServiceResult<int>.Fail("Kategori ismi daha önce kullanılmıştır. Lütfen farklı bir isim giriniz.");
			}


			var category = mapper.Map<Category>(request);

			await categoryRepository.AddAsync(category);
			await unitOfWork.SaveChangesAsync();
			return ServiceResult<int>.SuccessAsCreated(category.Id, $"api/categories/{category.Id}");

		}

		public async Task<ServiceResult> UpdateAsync(int id,UpdateCategoryRequest request)
		{

			var anyCategory = await categoryRepository.AnyAsync(x => x.Name == request.Name && x.Id !=id);
			if (anyCategory)
			{
				return ServiceResult.Fail("Kategori ismi daha önce kullanılmıştır. Lütfen farklı bir isim giriniz.");
			}
			var category = mapper.Map<Category>(request);
			category.Id = id;
			categoryRepository.Update(category!);
			await unitOfWork.SaveChangesAsync();
			return ServiceResult.Success(HttpStatusCode.NoContent);
		}

		public async Task<ServiceResult> DeleteAsync(int id)
		{
			var category = await categoryRepository.GetByIdAsync(id);

			categoryRepository.Delete(category!);
			await unitOfWork.SaveChangesAsync();
			return ServiceResult.Success(HttpStatusCode.NoContent);
		}
	}
}
