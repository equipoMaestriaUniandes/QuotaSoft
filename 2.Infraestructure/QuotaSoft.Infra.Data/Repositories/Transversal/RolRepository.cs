namespace Quota.Infra.Data.Repositories.Transversal
{
    using System.Linq;
    using Dapper;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Model.Transversal;
    using System.Collections.Generic;

    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        public RolRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRol"></param>
        /// <returns></returns>
        public bool RolActive(int idRol)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Rol RolByUser(int userId)
        {
            var query = "SELECT r.* FROM [perezgomez].[roles] r " +
                "INNER JOIN [perezgomez].[usuarios] u ON r.Id = u.rol " +
                "WHERE u.id = @userId";
            return base.GetQueryData(query, new { userId = userId })?.FirstOrDefault();
        }
    }
}
