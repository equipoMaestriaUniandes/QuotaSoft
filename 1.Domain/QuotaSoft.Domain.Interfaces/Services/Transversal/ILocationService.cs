namespace Quota.Domain.Interfaces.Services.Transversal
{
    using Quota.Domain.Entities.Model.Transversal;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILocationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Country> GetCountries();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<State> GetStates();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        IEnumerable<City> GetCitiesByState(int stateId);
    }
}
