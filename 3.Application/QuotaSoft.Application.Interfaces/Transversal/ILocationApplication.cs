namespace Quota.Application.Interfaces.Transversal
{
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Entities.Response;
    using System.Collections.Generic;

    public interface ILocationApplication
    {
       
        GenericResponse<IEnumerable<Country>> GetCountries();


        GenericResponse<IEnumerable<State>> GetStates();

       /// <summary>
       /// 
       /// </summary>
       /// <param name="stateId"></param>
       /// <returns></returns>
        GenericResponse<IEnumerable<City>> GetCitiesByState(int stateId);
    }
}
