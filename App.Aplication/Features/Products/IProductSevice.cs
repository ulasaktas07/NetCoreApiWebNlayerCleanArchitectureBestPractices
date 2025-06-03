using App.Aplication.Features.Products.Create;
using App.Aplication.Features.Products.Dto;
using App.Aplication.Features.Products.Update;
using App.Aplication.Features.Products.UpdateStock;

namespace App.Aplication.Features.Products
{
	public interface IProductSevice
	{
		Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count);
		Task<ServiceResult<ProductDto?>> GetByIdAsync(int id);
		Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
		Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request);
		Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request);
		Task<ServiceResult> UpdateStockAsync(UpdateProductStockRequest request);
		Task<ServiceResult> DeleteAsync(int id);
		Task<ServiceResult<List<ProductDto>>> GetAllListAsync();
	}
}
