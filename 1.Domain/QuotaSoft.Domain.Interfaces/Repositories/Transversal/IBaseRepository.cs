namespace Quota.Domain.Interfaces.Repositories.Transversal
{
    using Quota.Domain.Entities.Model.Transversal;
    using System.Collections.Generic;

    public interface IBaseRepository<T>: IQueryRepository<T> where T : BaseEntity
    {
       public long Insert(T entity);

       public void Delete(T entity);

       public void Update(T entity);

       public void InsertMasive(IEnumerable<T> entities, string tableName);
    }
}
