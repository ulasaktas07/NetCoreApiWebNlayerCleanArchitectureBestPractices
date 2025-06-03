using App.Aplication.Features.Categories.Create;
using App.Aplication.Features.Categories.Dto;
using App.Aplication.Features.Categories.Update;

namespace App.Aplication.Features.Categories
{
	public interface ICategoryService
	{
		Task<ServiceResult<CategoryWithProductsDto>> GetCategoryWithProductsAsync(int id);
		Task<ServiceResult<List<CategoryWithProductsDto>>> GetAllCategoriesWithProductsAsync();
		Task<ServiceResult<List<CategoryDto>>> GetAllListAsync();
		Task<ServiceResult<CategoryDto>> GetByIdAsync(int id);
		Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request);
		Task<ServiceResult> UpdateAsync(int id,UpdateCategoryRequest request);
		Task<ServiceResult> DeleteAsync(int id);
	}
}