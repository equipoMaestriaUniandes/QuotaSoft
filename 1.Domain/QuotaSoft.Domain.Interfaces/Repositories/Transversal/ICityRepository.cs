namespace Quota.Domain.Interfaces.Repositories.Transversal
{
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using System.Collections.Generic;
    using Quota.Domain.Entities.Model.Transversal;

    /// <summary>
    /// Defines the <see cref="ICityRepository" />
    /// </summary>
    public interface ICityRepository : IBaseRepository<City>
    {
        IEnumerable<City> GetCitiesByState(int stateId);
    }
}