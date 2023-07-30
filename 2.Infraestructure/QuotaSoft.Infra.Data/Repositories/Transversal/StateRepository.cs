namespace Quota.Infra.Data.Repositories.Transversal
{
    using System.Linq;
    using Dapper;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Model.Transversal;
    using System.Collections.Generic;

    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="countryId"></param>
      /// <returns></returns>
        public State StateByCountry(int countryId)
        {
            var query = "SELECT d.* FROM [perezgomez].[departamentos] d " +
                "INNER JOIN [perezgomez].[paises] p ON d.IdPais = p.Id " +
                "WHERE p.id = @countryId";
            return base.GetQueryData(query, new { countryId = countryId })?.FirstOrDefault();
        }
    }
}
