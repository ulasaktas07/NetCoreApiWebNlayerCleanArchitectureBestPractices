using App.Repositories.Products;

namespace App.Services.Categories.Update
{
	public record CategoryWithProductsDto(int Id,string Name,List<ProductDto> Products);
}
