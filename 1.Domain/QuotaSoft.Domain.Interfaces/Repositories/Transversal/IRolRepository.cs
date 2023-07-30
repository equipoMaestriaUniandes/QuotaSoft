namespace Quota.Domain.Interfaces.Repositories.Transversal
{
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using System.Collections.Generic;
    using Quota.Domain.Entities.Model.Transversal;

    /// <summary>
    /// Defines the <see cref="IRolRepository" />
    /// </summary>
    public interface IRolRepository : IBaseRepository<Rol>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRol"></param>
        /// <returns></returns>
        bool RolActive(int idRol);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Rol RolByUser(int userId);
    }
}
