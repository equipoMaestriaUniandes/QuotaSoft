namespace Quota.Application.Services.Transversal
{
    using Quota.Application.Interfaces.Transversal;
    using Quota.Domain.Entities.Dto;
    using Quota.Domain.Entities.Enums;
    using Quota.Domain.Entities.ErrorHandler;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Entities.Response;
    using Quota.Domain.Interfaces.Services;
    using Quota.Domain.Interfaces.Services.Transversal;
    using Quota.Domain.Services.Utilities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The seguridad aplicaciones.
    /// </summary>
    public class LocationApplication : ILocationApplication
    {  

      private readonly ILocationService locationService;

        public LocationApplication(ILocationService locationService)
        {
            this.locationService = locationService;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public GenericResponse<IEnumerable<City>> GetCitiesByState(int stateId)
        {
            var objAux = this.locationService.GetCitiesByState(stateId);
            return HelperGeneric<IEnumerable<City>>.CastToGenericResponse(Helper.ManageResponse(objAux));
        }

        public GenericResponse<IEnumerable<Country>> GetCountries()
        {
            var objAux = this.locationService.GetCountries();
            return HelperGeneric<IEnumerable<Country>>.CastToGenericResponse(Helper.ManageResponse(objAux));
        }

        public GenericResponse<IEnumerable<State>> GetStates()
        {
            var objAux = this.locationService.GetStates();
            return HelperGeneric<IEnumerable<State>>.CastToGenericResponse(Helper.ManageResponse(objAux));
        }
    }
}