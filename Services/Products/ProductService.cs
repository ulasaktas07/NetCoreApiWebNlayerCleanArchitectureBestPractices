﻿using App.Repositories;
using App.Repositories.Products;
using App.Services.Products.Create;
using App.Services.Products.Update;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace App.Services.Products
{
	public class ProductService(IProductRepository productRepository,IUnitOfWork unitOfWork,IMapper mapper) : IProductSevice
	{
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
			var products = await productRepository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
			//var productsDto = products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).ToList();
			var productsDto = mapper.Map<List<ProductDto>>(products);
			return ServiceResult<List<ProductDto>>.Success(productsDto);
		}

		public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request)
		{
			// async manuel service bussiness check 
			var anyProduct =await productRepository.Where(x => x.Name == request.Name).AnyAsync();
			if (anyProduct)
			{
				return ServiceResult<CreateProductResponse>.Fail("Ürün ismi daha önce kullanılmıştır. Lütfen farklı bir isim giriniz.");
			}


			var product = new Product()
			{
				Name = request.Name,
				Price = request.Price,
				Stock = request.Stock
			};
			await productRepository.AddAsync(product);
			await unitOfWork.SaveChangesAsync();
			return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.Id),$"api/products/{product.Id}");
		}

		public async Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request)
		{
			var product = await productRepository.GetByIdAsync(id);
			if (product is null)
			{
				return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
			}
			product.Name = request.Name;
			product.Price = request.Price;
			product.Stock = request.Stock;
			 productRepository.Update(product);
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
			if (product is null)
			{
				return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
			}
			productRepository.Delete(product);
			await unitOfWork.SaveChangesAsync();
			return ServiceResult.Success(HttpStatusCode.NoContent);
		}

		public async Task<ServiceResult<List<ProductDto>>> GetAllListAsync()
		{
			var products = await productRepository.GetAll().ToListAsync();
			//var productsDto = products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).ToList();
			var productsDto = mapper.Map<List<ProductDto>>(products);
			return ServiceResult<List<ProductDto>>.Success(productsDto);
		}
	}
}
