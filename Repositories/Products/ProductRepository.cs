﻿using App.Repositories.Concrete;
using App.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Products
{
	public class ProductRepository(AppDbContext context) : GenericRepository<Product,int>(context), IProductRepository
	{
		public Task<List<Product>> GetTopPriceProductsAsync(int count)
		{
			return Context.Products.OrderByDescending(p => p.Price).Take(count).ToListAsync();
		}
	}
}
