using App.Repositories.Products;
using App.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
	public class ProductsController(IProductSevice productSevice) : CustomBaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetAll() => CreateActionResult(await productSevice.GetAllListAsync());

		[HttpGet("{pageNumber}/{pageSize}")]
		public async Task<IActionResult> GetPagedAll(int pageNumber,int pageSize) => CreateActionResult(await productSevice
			.GetPagedAllListAsync(pageNumber,pageSize));


		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id) => CreateActionResult(await productSevice.GetByIdAsync(id));

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductRequest request) => CreateActionResult(await productSevice.CreateAsync(request));

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateProductRequest request) => CreateActionResult(await productSevice.UpdateAsync(id, request));
		
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id) => CreateActionResult(await productSevice.DeleteAsync(id));



	}


}
