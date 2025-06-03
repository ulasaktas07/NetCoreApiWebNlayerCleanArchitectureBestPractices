﻿using App.Aplication.Contract.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Products
{
	public class ProductRepository(AppDbContext context) : GenericRepository<Product,int>(context), IProductRepository
	{
		public Task<List<Product>> GetTopPriceProductsAsync(int count)
		{
			return Context.Products.OrderByDescending(p => p.Price).Take(count).ToListAsync();
		}
	}
}
