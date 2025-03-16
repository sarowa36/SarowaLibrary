namespace SarowaLibrary.EntityLayer.Base
{
    /// <summary>
    /// Dont forget add SoftDeletableInterception and 'modelBuilder.ApplyGlobalFilters&lt;ISoftDeletable&gt;(x =&gt; !x.IsDeleted);'in your DbContext
    /// </summary>
    public interface ISoftDeletable
    {
        public bool IsDeleted { get; set; }
    }
}
