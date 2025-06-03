using App.Aplication.Features.Categories;
using App.Aplication.Features.Categories.Create;
using App.Aplication.Features.Categories.Update;
using App.Domain.Entities;
using CleanApp.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CleanApp.API.Controllers
{
	public class CategoriesController(ICategoryService categoryService) : CustomBaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()=> CreateActionResult(await categoryService.GetAllListAsync());

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById(int id)=> CreateActionResult(await categoryService.GetByIdAsync(id));

		[HttpGet("{id:int}/products")]
		public async Task<IActionResult> GetCategoryWithProducts(int id) => CreateActionResult(await categoryService.GetCategoryWithProductsAsync(id));

		[HttpGet("products")]
		public async Task<IActionResult> GetAllCategoriesWithProducts() => CreateActionResult(await categoryService.GetAllCategoriesWithProductsAsync());

		[HttpPost]
		public async Task<IActionResult> Create(CreateCategoryRequest request) => CreateActionResult(await categoryService.CreateAsync(request));

		[ServiceFilter(typeof(NotFoundFilter<Category, int>))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update(int id, UpdateCategoryRequest request) => CreateActionResult(await categoryService.UpdateAsync(id,request));

		[ServiceFilter(typeof(NotFoundFilter<Category, int>))]
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id) => CreateActionResult(await categoryService.DeleteAsync(id));


	}
}
