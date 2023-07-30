namespace Quota.Domain.Interfaces.Services
{
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Interfaces.Services.Transversal;
    using System.Collections.Generic;

   /// <summary>
   /// 
   /// </summary>
    public interface IMenuService : IBaseService<Menu>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IEnumerable<Menu> GetMenuByRol(User user);


    }
}