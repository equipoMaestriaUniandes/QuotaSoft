namespace Quota.Domain.Interfaces.Repositories.Transversal
{
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using System.Collections.Generic;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Entities.Model.Authentication;

    /// <summary>
    /// Defines the <see cref="IMenuRepository" />
    /// </summary>
    public interface IMenuRepository : IBaseRepository<Menu>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IEnumerable<Menu> GetMenuByRol(User user);
    }
}
