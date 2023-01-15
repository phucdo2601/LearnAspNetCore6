using System.Linq.Expressions;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);   
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate); 
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveAll(IEnumerable<T> entities);
    }
}
