namespace Quota.Domain.Interfaces.Services
{
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Interfaces.Services.Transversal;
    using System.Collections.Generic;

    /// <summary>
    /// The RolPermissionsService interface.
    /// </summary>
    public interface IRolPermissionsService : IBaseService<RolPermissions>
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