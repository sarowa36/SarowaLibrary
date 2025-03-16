using System.Linq.Expressions;

namespace SarowaLibrary.DataAccessLayer.Base
{
    public interface IWriteRepository<T>:IRepository<T> where T : class
    {
        Task CreateAsync(T t);
        Task CreateRangeAsync(IEnumerable<T> values);
        Task UpdateAsync(T t);
        Task UpdateRangeAsync(IEnumerable<T> values);
        Task DeleteAsync(T t);
        Task DeleteWhereAsync(Expression<Func<T,bool>> expression);
        Task DeleteAsync(object id);
        Task DeleteRangeAsync(IEnumerable<T> values);
        Task<int> SaveChangesAsync();
    }
}
