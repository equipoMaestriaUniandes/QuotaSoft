namespace Quota.Domain.Services.Transversal
{
    using Microsoft.Extensions.Configuration;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Services.Services;
    using Quota.Domain.Interfaces.Services.Transversal;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="LocationService" />
    /// </summary>
    public class LocationService : BaseService<Location>, ILocationService
    {
        /// <summary>
        /// Defines the menu Repository
        /// </summary>
        private readonly ILocationRepository locationRepository;

        /// <summary>
        /// Defines the configuration
        /// </summary>
        private readonly IConfiguration configuration;

        private readonly ICountryRepository countryRepository;

        private readonly IStateRepository stateRepository;

        private readonly ICityRepository cityRepository;

        public LocationService(ILocationRepository locationRepository,
            IConfiguration configuration, ICountryRepository countryRepository,
            IStateRepository stateRepository, ICityRepository cityRepository)
            : base(locationRepository)
        {
            this.locationRepository = locationRepository;
            this.configuration = configuration;
            this.countryRepository = countryRepository;
            this.stateRepository = stateRepository;
            this.cityRepository = cityRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<Country> GetCountries()
        {
            return this.countryRepository.GetObjectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<State> GetStates()
        {
            return this.stateRepository.GetObjectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public IEnumerable<City> GetCitiesByState(int stateId)
        {
            return this.cityRepository.GetCitiesByState(stateId);
        }
    }
}
