using Microsoft.EntityFrameworkCore;

namespace SarowaLibrary.DataAccessLayer.Base
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
    }
}
