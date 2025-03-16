using System.Linq.Expressions;

namespace SarowaLibrary.DataAccessLayer.Base
{
    public interface IReadRepository<T> :IRepository<T> where T : class
    {
        public T? Get(object id);
        public bool Get(object id, out T? t);
        public T? GetWhere(Expression<Func<T, bool>> expression);
        public bool GetWhere(Expression<Func<T, bool>> expression,out T? t);
        public IQueryable<T> GetAll(int? index = null, int? count = null,string? orderPropertyName=null,bool isDesc=false);
        public bool Exist(Expression<Func<T, bool>> expression);
        public int Count(Expression<Func<T, bool>>? expression=null);
    }
}
