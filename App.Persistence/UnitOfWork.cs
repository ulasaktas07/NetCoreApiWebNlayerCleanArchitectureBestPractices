using App.Aplication.Contract.Persistence;

namespace App.Persistence;
	public class UnitOfWork(AppDbContext context) : IUnitOfWork
	{
		public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
	}
