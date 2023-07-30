namespace Quota.Infra.IoC
{
    using Quota.Domain.Interfaces.Services;
    using Quota.Domain.Services.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Infra.Data.Repositories.Transversal;
    using Quota.Domain.Interfaces.Services.Transversal;
    using Quota.Domain.Services.Transversal;
    using Quota.Application.Interfaces.Transversal;
    using Quota.Application.Services.Transversal;

    public class DependencyInjector
    {
        public DependencyInjector()
        {
        }

        public IServiceCollection GetServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDbFactory, DbFactory>();

            services.AddSingleton(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddSingleton<IRolPermissionsRepository, RolPermissionsRepository>();
            services.AddSingleton<IRolRepository, RolRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IMenuRepository, MenuRepository>();
            services.AddSingleton<ILocationRepository, LocationRepository>();
            services.AddSingleton<ICountryRepository, CountryRepository>();
            services.AddSingleton<ICityRepository, CityRepository>();
            services.AddSingleton<IStateRepository, StateRepository>();

            services.AddSingleton(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<IRolPermissionsService, RolPermissionsService>();            
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IRolService, RolService>();
            services.AddSingleton<IMenuService, MenuService>();
            services.AddSingleton<ILocationService, LocationService>();

            services.AddSingleton(typeof(IBaseApplication<>), typeof(BaseApplication<>));
            services.AddSingleton<IUserApplication, UserApplication>();
            services.AddSingleton<IMenuApplication, MenuApplication>();
            services.AddSingleton<IAuthenticationApplication, AuthenticationApplication>();
            services.AddSingleton<IAuthorizationApplication, AuthorizationApplication>();
            services.AddSingleton<ILocationApplication, LocationApplication>();

            return services;
        }
    }
}