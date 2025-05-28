using App.Repositories.Context;

namespace App.Repositories;
	public class UnitOfWork(AppDbContext context) : IUnitOfWork
	{
		public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
	}
