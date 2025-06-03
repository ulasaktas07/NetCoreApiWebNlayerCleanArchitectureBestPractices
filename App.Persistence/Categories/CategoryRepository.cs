
using App.Aplication.Contract.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Categories
{
	public class CategoryRepository(AppDbContext context) : GenericRepository<Category,int>(context), ICategoryRepository
	{
		public IQueryable<Category> GetCategoryByProducts()
		{
			return context.Categories.Include(x => x.Products).AsQueryable();
		}

		public Task<List<Category>> GetCategoryByProductsAsync()
		{
			return context.Categories.Include(x => x.Products).ToListAsync();
		}

		public Task<Category?> GetCategoryWithProductsAsync(int id)
		{
		return context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
