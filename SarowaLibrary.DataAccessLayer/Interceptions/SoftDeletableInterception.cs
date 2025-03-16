using SarowaLibrary.EntityLayer.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SarowaLibrary.DataAccessLayer.Interceptions
{
    public class SoftDeletableInterception :SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData,
        InterceptionResult<int> result)
        {
            if (eventData.Context is null) return result;

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry is not { State: EntityState.Deleted, Entity: ISoftDeletable delete }) continue;
                entry.State = EntityState.Modified;
                delete.IsDeleted = true; 
            }
            return result;
        }
    }
}
