namespace Quota.Domain.Services.Transversal
{
    using Microsoft.Extensions.Configuration;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Services.Services;
    using Quota.Domain.Interfaces.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Quota.Domain.Entities.Model.Authentication;

    /// <summary>
    /// Defines the <see cref="MenuService" />
    /// </summary>
    public class MenuService : BaseService<Menu>, IMenuService
    {
        /// <summary>
        /// Defines the menu Repository
        /// </summary>
        private readonly IMenuRepository menuRepository;

        /// <summary>
        /// Defines the configuration
        /// </summary>
        private readonly IConfiguration configuration;

        public MenuService(IMenuRepository menuRepository,
            IConfiguration configuration)
            : base(menuRepository)
        {
            this.menuRepository = menuRepository;
            this.configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<Menu> GetMenuByRol(User user)
        {
           return this.menuRepository.GetMenuByRol(user);
        }
    }
}
