using SarowaLibrary.DataAccessLayer.Base;
using SarowaLibrary.EntityLayer.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarowaLibrary.DataAccessLayer.Helpers
{
    public static class SortableHelpers
    {
        public static void UpdateSortIndex<T>(this IWriteRepository<T> repo,Dictionary<int,int> newIndex) where T : class, ISortable,IIntIdentity, new()
        {
            foreach (var keypair in newIndex)
            {
                repo.Table.Where(x => keypair.Key == x.Id).ExecuteUpdate(x => x.SetProperty(y => y.SortIndex, keypair.Value));
            }
        }
    }
}
