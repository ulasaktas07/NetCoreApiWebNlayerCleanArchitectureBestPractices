using App.Repositories.Products;
using App.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
	public class ProductsController(IProductSevice productSevice) : CustomBaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetAll() => CreateActionResult(await productSevice.GetAllListAsync());


		[HttpGet("{pageNumber:int}/{pageSize:int}")]
		public async Task<IActionResult> GetPagedAll(int pageNumber,int pageSize) => CreateActionResult(await productSevice
			.GetPagedAllListAsync(pageNumber,pageSize));



		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById(int id) => CreateActionResult(await productSevice.GetByIdAsync(id));


		[HttpPost]
		public async Task<IActionResult> Create(CreateProductRequest request) => CreateActionResult(await productSevice.CreateAsync(request));


		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update(int id, UpdateProductRequest request) => CreateActionResult(await productSevice.UpdateAsync(id, request));



		[HttpPatch("stock")]
		public async Task<IActionResult> UpdateStock(UpdateProductStockRequest request) => CreateActionResult(await productSevice.UpdateStockAsync(request));


		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id) => CreateActionResult(await productSevice.DeleteAsync(id));




	}


}
