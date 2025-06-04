using App.Aplication.Contract.Caching;
using App.Aplication.Contract.Persistence;
using App.Aplication.Features.Products.Create;
using App.Aplication.Features.Products.Dto;
using App.Aplication.Features.Products.Update;
using App.Aplication.Features.Products.UpdateStock;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Aplication.Features.Products
{
	public class ProductService(IProductRepository productRepository,IUnitOfWork unitOfWork,IMapper mapper,ICacheService cacheService) : IProductSevice
	{
		private const string ProductListCacheKey = "ProductListCacheKey";
		public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count)
		{
			var products = await productRepository.GetTopPriceProductsAsync(count);

			//var productsDto = products.Select(p => new ProductDto(p.Id,p.Name,p.Price,p.Stock)).ToList();
			var productsDto = mapper.Map<List<ProductDto>>(products);

			return ServiceResult<List<ProductDto>>.Success(productsDto);
		}


		public async Task<ServiceResult<ProductDto?>> GetByIdAsync(int id)
		{
			var product = await productRepository.GetByIdAsync(id);
			if (product is null)
			{
				return ServiceResult<ProductDto?>.Fail("Product not found", HttpStatusCode.NotFound);
			}
			//var productDto = new ProductDto(product!.Id, product.Name, product.Price, product.Stock);
			var productDto = mapper.Map<ProductDto>(product);
			return ServiceResult<ProductDto>.Success(productDto)!;
		}


		public async Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
		{
			var products = await productRepository.GetAllPagedAsync(pageNumber, pageSize);
			//var productsDto = products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).ToList();
			var productsDto = mapper.Map<List<ProductDto>>(products);
			return ServiceResult<List<ProductDto>>.Success(productsDto);
		}

		public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request)
		{
			// async manuel service bussiness check 
			var anyProduct =await productRepository.AnyAsync(x => x.Name == request.Name);
			if (anyProduct)
			{
				return ServiceResult<CreateProductResponse>.Fail("Ürün ismi daha önce kullanılmıştır. Lütfen farklı bir isim giriniz.");
			}


			var product = mapper.Map<Product>(request); 

			await productRepository.AddAsync(product);
			await unitOfWork.SaveChangesAsync();
			return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.Id),$"api/products/{product.Id}");
		}


		public async Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request)
		{
			var product = await productRepository.GetByIdAsync(id);

			var anyProduct = await productRepository.AnyAsync(x => x.Name == request.Name && x.Id!=id);
			if (anyProduct)
			{
				return ServiceResult.Fail("Ürün ismi daha önce kullanılmıştır. Lütfen farklı bir isim giriniz.");
			}


			product = mapper.Map(request, product);

			 productRepository.Update(product!);
			await unitOfWork.SaveChangesAsync();
			return ServiceResult.Success(HttpStatusCode.NoContent);
		}


		public async Task<ServiceResult> UpdateStockAsync(UpdateProductStockRequest request)
		{
			var product = await productRepository.GetByIdAsync(request.ProductId);
			if (product is null)
			{
				return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
			}

			product.Stock = request.Quantity;
			productRepository.Update(product);
			await unitOfWork.SaveChangesAsync();
			return ServiceResult.Success(HttpStatusCode.NoContent);	
		}

		public async Task<ServiceResult> DeleteAsync(int id)
		{
			var product = await productRepository.GetByIdAsync(id);

			productRepository.Delete(product!);
			await unitOfWork.SaveChangesAsync();
			return ServiceResult.Success(HttpStatusCode.NoContent);
		}

		public async Task<ServiceResult<List<ProductDto>>> GetAllListAsync()
		{
			var productListAsCached = await cacheService.GetAsync<List<ProductDto>>(ProductListCacheKey);
			if (productListAsCached is not null) return ServiceResult<List<ProductDto>>.Success(productListAsCached);



			var products = await productRepository.GetAllAsync();
			//var productsDto = products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).ToList();
			var productsDto = mapper.Map<List<ProductDto>>(products);

			await cacheService.AddAsync(ProductListCacheKey, productsDto, TimeSpan.FromMinutes(5));

			return ServiceResult<List<ProductDto>>.Success(productsDto);
		}

	}
}
