namespace Quota.Domain.Services.Transversal
{
    using Quota.Domain.Entities.Dto;
    using Quota.Domain.Entities.Enums;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Interfaces.Services;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="AuthorizationService" />
    /// </summary>
    public class AuthorizationService : IAuthorizationService
    {
        /// <summary>
        /// Defines the rolPermissions
        /// </summary>
        private readonly IRolPermissionsRepository rolPermissionsRepository;

        /// <summary>
        /// The Usuario repositorio
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rolPermissionsRepository"></param>
        /// <param name="userRepository"></param>
        public AuthorizationService(IRolPermissionsRepository rolPermissionsRepository, IUserRepository userRepository)
        {
            this.rolPermissionsRepository = rolPermissionsRepository;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestAuthorization"></param>
        /// <returns></returns>
        public IEnumerable<AuthorizationDto> RequestAuthorization(RequestAuthorizationDto requestAuthorization)
        {
            if (this.UserIsAdmin(requestAuthorization))
            {
                return this.AuthorizeAllFeatures(requestAuthorization.requestFuncionalities);
            }
            return FuctionalityAuth(requestAuthorization);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestAuthorization"></param>
        /// <returns></returns>
        private bool UserIsAdmin(RequestAuthorizationDto requestAuthorization)
        {
            if (!requestAuthorization.isAuth)
            {
                return false;
            }

            var user = this.userRepository.GetUserAuth(requestAuthorization.userName);
            // return usuario.Rol?.Tipo?.Codigo.Equals(nameof(TipoRolCodigoEnum.ADM)) ?? false;
            return user.Rol?.id == ((int)RolEnum.ADM) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionalities"></param>
        /// <returns></returns>
        private IEnumerable<AuthorizationDto> AuthorizeAllFeatures(IEnumerable<FunctionalityDto> functionalities)
        {
            return functionalities.Select(x => new AuthorizationDto()
            {
                authorizationCode = AuthorizationCode.Authorized,
                functionalityName = x.name
            }).ToList();
        }


        /// <summary>
        /// The AutorizaFunctionalityePermitidad
        /// </summary>
        /// <param name="requestAuthorization">The requestAuthorization<see cref="RequestAuthorizationDto"/></param>
        /// <returns>The <see cref="IEnumerable{Authorization}"/></returns>
        private IEnumerable<AuthorizationDto> FuctionalityAuth(RequestAuthorizationDto requestAuthorization)
        {        
            IEnumerable<RolPermissions> userPermissions = null;
            var authorizationes = new List<AuthorizationDto>();
            requestAuthorization.requestFuncionalities
            .ToList()
            .ForEach(x =>
            {
                var authorization = new AuthorizationDto()
                {
                    authorizationCode = AuthorizationCode.Authorized,
                    functionalityName = x.name
                };

                if (!requestAuthorization.isAuth && x.requireRequestAccess)
                {
                    authorization.authorizationCode = AuthorizationCode.UnAuthenticated;
                }
                else if (requestAuthorization.isAuth &&
                            x.requireRequestAccess)
                {
                    userPermissions  = userPermissions ?? GetUserPermissions(requestAuthorization);

                    var usuarioTienePermisoFunctionality = HasPermissionsMenu(x, userPermissions);
                    authorization.authorizationCode = !usuarioTienePermisoFunctionality ? AuthorizationCode.UnAuthorized : authorization.authorizationCode;
                }

                authorizationes.Add(authorization);
            });

            return authorizationes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionality"></param>
        /// <param name="userPermissions"></param>
        /// <returns></returns>
        private bool HasPermissionsMenu(FunctionalityDto functionality, IEnumerable<RolPermissions> userPermissions)
        {
            var permission = userPermissions.Any(x => x.menuId.Equals(functionality.menuId));

            return permission;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestAuthorization"></param>
        /// <returns></returns>
        private IEnumerable<RolPermissions> GetUserPermissions(RequestAuthorizationDto requestAuthorization)
        {
            if (requestAuthorization.isAuth)
            {
                var rol = userRepository.GetUserAuth(requestAuthorization.userName).Rol;
                return this.rolPermissionsRepository.GetPermissionsByRol(rol.id);
            }

            return new List<RolPermissions>();
        }
    }
}
