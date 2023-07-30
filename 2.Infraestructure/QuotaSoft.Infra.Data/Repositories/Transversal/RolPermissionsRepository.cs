namespace Quota.Infra.Data.Repositories.Transversal
{
    using System.Linq;
    using Dapper;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Model.Transversal;
    using System.Collections.Generic;

    public class RolPermissionsRepository : BaseRepository<RolPermissions>, IRolPermissionsRepository
    {
        public RolPermissionsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public IEnumerable<RolPermissions> GetPermissionsByRol(int? rolId)
        {
            var query = "SELECT * FROM [perezgomez].[roles] WHERE rol = @rolId";
            return base.GetQueryData(query, new { rolId = rolId });
        }

        public IEnumerable<RolPermissions> GetMenuChildren()
        {
            var query = "SELECT * FROM [perezgomez].[menus] WHERE parent > 0";
            return base.GetQueryData(query);
        }
    }
}