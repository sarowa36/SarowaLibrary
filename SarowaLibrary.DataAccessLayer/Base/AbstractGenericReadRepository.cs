using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SarowaLibrary.DataAccessLayer.Base
{
    public abstract class AbstractGenericReadRepository<T,TDbContext> : IReadRepository<T> where T : class, TDbContext where TDbContext:DbContext
    {
        public DbSet<T> Table => _db.Set<T>();
        private readonly TDbContext _db;
        public AbstractGenericReadRepository(TDbContext db)
        {
            _db = db;
        }
        public virtual T? Get(object id)
        {
            return Table.Find(id);
        }
        public virtual bool Get(object id, out T? t)
        {
            t = this.Get(id);
            return t != null;
        }
        public virtual T? GetWhere(Expression<Func<T, bool>> expression)
        {
            return Table.FirstOrDefault(expression);
        }
        public bool GetWhere(Expression<Func<T, bool>> expression, out T? t)
        {
            t = this.GetWhere(expression);
            return t != null;
        }
        public virtual IQueryable<T> GetAll(int? index = null, int? count = null, string? orderPropertyName = null, bool isDesc = false)
        {
            var query = Table.AsQueryable();
            if(orderPropertyName != null && isDesc)
                query=query.OrderByDescending(x=>EF.Property<object>(x, orderPropertyName));
            else if(orderPropertyName!=null)
                query = query.OrderBy(x => EF.Property<object>(x, orderPropertyName));
            if (index != null)
                query = query.Skip((int)index);
            if (count != null)
                query = query.Take((int)count);
            return query;
        }
        public virtual bool Exist(Expression<Func<T, bool>> expression)
        {
            return Table.Any(expression);
        }
        public virtual int Count(Expression<Func<T, bool>>? expression = null)
        {
            if(expression!=null)
                return Table.Count(expression);
            return Table.Count();
        }
    }
}
