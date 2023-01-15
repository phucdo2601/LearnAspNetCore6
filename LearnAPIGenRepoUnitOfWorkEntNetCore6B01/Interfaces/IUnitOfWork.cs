using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Repositories;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();

        IUserRepository UserRepository { get; }
        ICarRepository CarRepository { get; }
    }
}
