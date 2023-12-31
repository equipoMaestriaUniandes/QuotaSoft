﻿namespace Quota.Infra.Data.Repositories.Transversal
{
    using System.Linq;
    using Dapper;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Model.Transversal;
    using System.Collections.Generic;

    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<Menu> GetMenuByRol(User user)
        {
            var query = "SELECT m.* FROM [dbo].[menu] m " +
                "INNER JOIN[dbo].[permission] rp ON m.Id = rp.menuId " +
                "INNER JOIN[dbo].[rol] r ON rp.ROL = r.Id  " +
                "WHERE r.Id = @rolId";
            return base.GetQueryData(query, new { rolId = user.Rol?.id });
        }
    }
}
