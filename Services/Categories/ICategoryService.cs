using App.Services.Categories.Create;
using App.Services.Categories.Update;

namespace App.Services.Categories
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