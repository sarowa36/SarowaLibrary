namespace SarowaLibrary.EntityLayer.Base
{
    /// <summary>
    /// That interface defines the Create Date for an Entity. Dont forget add 'modelBuilder.ApplyGlobalDefaultSqlValue&lt;ICreateDate, DateTime&gt;(x =&gt; x.CreateDate, "getdate()")' that in your DbContext 
    /// </summary>
    public interface ICreateDate
    {
        public DateTime CreateDate { get; set; }
    }
    public class CreateDate : ICreateDate
    {
        DateTime ICreateDate.CreateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
