using SarowaLibrary.EntityLayer.Base;

namespace SarowaLibrary.DataAccessLayer.Helpers
{
    public static class RecursiveHelpers
    {
        /// <summary>
        /// this function converting recursive list to default style list from starting child to parent.
        /// </summary>
        public static List<T> RecursiveListToDefaultListChildToParent<T>(int id, List<T> allItems) where T : class, IIntIdentity, IRecursive<T>
        {
            var rcategories = new List<T>();
            T? cat = allItems.Where(x => x.Id == id).FirstOrDefault();
            if (cat != null)
            {
                rcategories.Add(cat);
                if (cat.ParentId != null)
                {
                    rcategories.AddRange(RecursiveListToDefaultListChildToParent((int)cat.ParentId, allItems));
                }
            }

            return rcategories;
        }
        /// <summary>
        /// this function converting recursive list to default style list from starting parent to child. like parent.childs=[child1,child2] to [parent,child1,child2]
        /// </summary>
        public static List<T> RecursiveListToDefaultListParentToChild<T>(this IEnumerable<T> list) where T : class, IIntIdentity, IRecursive<T>
        {

            List<T> returnvalues = new List<T>();
            foreach (T item in list)
            {
                returnvalues.Add(item);
                if (item.Childrens != null && item.Childrens.Count() > 0)
                {
                    returnvalues.AddRange(RecursiveListToDefaultListParentToChild(item.Childrens));
                }

            }
            return returnvalues;
        }
        /// <summary>
        /// this function make iteration in category child till find and remove given category
        /// </summary>
        public static List<T> FindRecursiveValueAndRemoveFromList<T>(this List<T> list, int id) where T : class, IIntIdentity, IRecursive<T>
        {
            foreach (var item in list)
            {
                if (item.Id == id)
                {
                    list.Remove(item);
                    break;
                }
                else if (item.Childrens != null && item.Childrens.Count() > 0)
                {
                    item.Childrens = FindRecursiveValueAndRemoveFromList(item.Childrens, id);
                }
            }
            return list;
        }
    }
}
