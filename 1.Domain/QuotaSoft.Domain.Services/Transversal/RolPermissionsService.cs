namespace Quota.Domain.Services.Transversal
{
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Quota.Domain.Entities.Enums;
    using Quota.Domain.Entities.ErrorHandler;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Interfaces.Services;
    using Quota.Domain.Services.Services;
    using Quota.Domain.Services.Transversal.Validator;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="UserService" />
    /// </summary>
    public class RolPermissionsService : BaseService<RolPermissions>, IRolPermissionsService
    {
        /// <summary>
        /// The User repository
        /// </summary>
        private readonly IRolPermissionsRepository rolPermissionsRepository;

        /// <summary>
        /// Defines the rol Repository
        /// </summary>
        private readonly IRolRepository rolRepository;

        /// <summary>
        /// Defines the configuration
        /// </summary>
        private readonly IConfiguration configuration;

        public RolPermissionsService(IRolPermissionsRepository rolPermissionsRepository, IRolRepository rolRepository,
            IConfiguration configuration)
            : base(rolPermissionsRepository)
        {
            this.rolPermissionsRepository = rolPermissionsRepository;
            this.rolRepository = rolRepository;
            this.configuration = configuration;
        }

        public IEnumerable<RolPermissions> GetMenuChildren()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rolId"></param>
        /// <returns></returns>
        public IEnumerable<RolPermissions> GetPermissionsByRol(int? rolId)
        {
            return this.GetPermissionsByRol(rolId);
        }
    }
}
