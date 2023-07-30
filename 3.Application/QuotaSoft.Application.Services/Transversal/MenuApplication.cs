namespace Quota.Application.Services.Transversal
{
    using Quota.Application.Interfaces.Transversal;
    using Quota.Domain.Entities.Dto;
    using Quota.Domain.Entities.Enums;
    using Quota.Domain.Entities.ErrorHandler;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Entities.Response;
    using Quota.Domain.Interfaces.Services;
    using Quota.Domain.Services.Utilities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The seguridad aplicaciones.
    /// </summary>
    public class MenuApplication : IMenuApplication
    {
        private readonly IUserService userService;

        private readonly IMenuService menuService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioServicio"></param>
        public MenuApplication(IUserService userService, IMenuService menuService)
        {
            this.userService = userService;
            this.menuService = menuService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GenericResponse<List<Menu>> GetMenuByClaimsUserIn(string userName)
        {
            List<Menu> menu = new List<Menu>();
            if (userName != null)
            {
                var userAux = this.userService.GetUserAuth(userName);
                menu = this.menuService.GetMenuByRol(userAux).ToList();
            }
            return HelperGeneric<List<Menu>>.CastToGenericResponse(Helper.ManageResponse(menu));
        }

        public GenericResponse<List<Menu>> GetMenuByUserIn(string userName)
        {

             var userAux = this.userService.GetUserAuth(userName.Trim());
            List<Menu> menu = this.menuService.GetMenuByRol(userAux).ToList();
            
            return HelperGeneric<List<Menu>>.CastToGenericResponse(Helper.ManageResponse(menu));
        }
    }
}