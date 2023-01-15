using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
		private readonly LearnUOfWorkVPSCSharpContext _learnUOfWorkVPSCSharpContext;

        public UnitOfWork(LearnUOfWorkVPSCSharpContext learnUOfWorkVPSCSharpContext)
		{
			_learnUOfWorkVPSCSharpContext= learnUOfWorkVPSCSharpContext;
		}

        public IUserRepository UserRepository => new UserRepository(_learnUOfWorkVPSCSharpContext);

        public ICarRepository CarRepository => new CarRepository(_learnUOfWorkVPSCSharpContext);

        public async Task<bool> SaveAsync()
        {
			try
			{
				return await _learnUOfWorkVPSCSharpContext.SaveChangesAsync() > 0;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
