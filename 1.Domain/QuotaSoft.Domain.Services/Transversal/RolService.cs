namespace Quota.Domain.Services.Transversal
{
    using Microsoft.Extensions.Configuration;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Services.Services;
    using Quota.Domain.Interfaces.Services.Transversal;

    /// <summary>
    /// Defines the <see cref="RolService" />
    /// </summary>
    public class RolService : BaseService<Rol>, IRolService
    {
        /// <summary>
        /// Defines the menu Repository
        /// </summary>
        private readonly IRolRepository rolRepository;

        /// <summary>
        /// Defines the configuration
        /// </summary>
        private readonly IConfiguration configuration;

        public RolService(IRolRepository rolRepository,
            IConfiguration configuration)
            : base(rolRepository)
        {
            this.rolRepository = rolRepository;
            this.configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Rol GetMenuByRol(int userId)
        {
            return this.rolRepository.RolByUser(userId);
        }
    }
}
