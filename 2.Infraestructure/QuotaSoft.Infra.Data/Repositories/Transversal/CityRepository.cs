namespace Quota.Infra.Data.Repositories.Transversal
{
    using System.Linq;
    using Dapper;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Model.Transversal;
    using System.Collections.Generic;

    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="stateId"></param>
       /// <returns></returns>
        public IEnumerable<City> GetCitiesByState(int stateId)
        {
            var query = "SELECT m.* FROM [perezgomez].[municipios] m " +
                " WHERE m.codigodep = @stateId ";
            return base.GetQueryData(query, new { stateId = stateId });
        }
    }
}
