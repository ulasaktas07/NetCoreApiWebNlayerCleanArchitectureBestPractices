using App.Aplication.Features.Products.Dto;

namespace App.Aplication.Features.Categories.Dto
{
	public record CategoryWithProductsDto(int Id,string Name,List<ProductDto> Products);
}
