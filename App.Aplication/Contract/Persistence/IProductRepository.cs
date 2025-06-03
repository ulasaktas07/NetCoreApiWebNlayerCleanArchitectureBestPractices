using App.Domain.Entities;
namespace App.Aplication.Contract.Persistence
{
	public interface IProductRepository: IGenericRepository<Product,int>
	{
		public Task<List<Product>> GetTopPriceProductsAsync(int count);
	}
}
