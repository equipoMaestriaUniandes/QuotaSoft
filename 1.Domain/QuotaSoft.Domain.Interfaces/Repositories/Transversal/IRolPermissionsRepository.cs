namespace Quota.Domain.Interfaces.Repositories.Transversal
{
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using System.Collections.Generic;
    using Quota.Domain.Entities.Model.Transversal;

    /// <summary>
    /// Defines the <see cref="IRolPermissionsRepository" />
    /// </summary>
    public interface IRolPermissionsRepository : IBaseRepository<RolPermissions>
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="rolId"></param>
       /// <returns></returns>
        IEnumerable<RolPermissions> GetPermissionsByRol(int? rolId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<RolPermissions> GetMenuChildren();
    }
}

