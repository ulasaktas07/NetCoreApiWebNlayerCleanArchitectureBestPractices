using App.Domain.Entities;

namespace App.Aplication.Contract.Persistence
{
	public interface ICategoryRepository:IGenericRepository<Category,int>
	{
		Task<Category?> GetCategoryWithProductsAsync(int id);
		Task<List<Category>> GetCategoryByProductsAsync();
	}
}
