namespace App.Aplication.Contract.Persistence
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
	}
}
