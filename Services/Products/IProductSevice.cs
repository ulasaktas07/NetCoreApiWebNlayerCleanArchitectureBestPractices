using App.Repositories.Products;

namespace App.Services.Products
{
	public interface IProductSevice
	{
		Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count);
	}
}
