﻿using App.Repositories.Abstract;
using App.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Repositories.Concrete
{
	public class GenericRepository<T, TId>(AppDbContext context) : IGenericRepository<T,TId> where T : BaseEntity<TId> where TId : struct
	{
		protected AppDbContext Context = context;
		private readonly DbSet<T> _dbSet = context.Set<T>();

		public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

		public Task<bool> AnyAsync(TId id) => _dbSet.AnyAsync(x=>x.Id.Equals(id));

		public void Delete(T entity) => _dbSet.Remove(entity);

		public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();

		public ValueTask<T?> GetByIdAsync(int id) => _dbSet.FindAsync(id);

		public void Update(T entity) => _dbSet.Update(entity);

		public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();
	}
}
