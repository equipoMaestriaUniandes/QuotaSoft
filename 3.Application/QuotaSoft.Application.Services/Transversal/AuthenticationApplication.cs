namespace Quota.Application.Services.Transversal
{
    using Quota.Application.Interfaces.Transversal;
    using Quota.Domain.Entities.Dto;
    using Quota.Domain.Entities.Enums;
    using Quota.Domain.Entities.ErrorHandler;
    using Quota.Domain.Entities.Response;
    using Quota.Domain.Interfaces.Services;
    using Quota.Domain.Interfaces.Services.Transversal;
    using Quota.Domain.Services.Utilities;

    /// <summary>
    /// The seguridad aplicaciones.
    /// </summary>
    public class AuthenticationApplication : IAuthenticationApplication
    {
        private readonly IUserService userService;

        private readonly IRolService rolService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioServicio"></param>
        public AuthenticationApplication(IUserService userService, IRolService rolService)
        {
            this.userService = userService;
            this.rolService = rolService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="credencialDto"></param>
        /// <returns></returns>
        public GenericResponse<LoginResponse> Authentication(CredentialDto credencialDto)
        {
            var loginResponse = new LoginResponse();
            var userAux = this.userService.SignIn(credencialDto.userName, credencialDto.password);
            if(userAux != null) {
            //var rolAux = this.rolService.GetMenuByRol(userAux.id);
                loginResponse.user = new UserDto
                {
                    id = userAux.id,
                    name = userAux.Name,
                    userName = userAux.UserName,
                    token = this.userService.GetToken(userAux.UserName, userAux.id)                   
                }; 
            }
            return HelperGeneric<LoginResponse>.CastToGenericResponse(Helper.ManageResponse(loginResponse));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public GenericResponse<UserDto> GetUserAuth(string userName)
        {
            var userAuth = new UserDto();
            var userAux = this.userService.GetUserAuth(userName);
            var rolAux = this.rolService.GetMenuByRol(userAux.id);
            if (userAux == null)
            {
                throw new ExceptionGeneric(ExceptionGenericTypes.Authentication, "Use not found");
            }else
            {
                userAuth = new UserDto
                {
                    id = userAux.id,
                    name = userAux.Name,
                    lastName = userAux.LastName,
                    userName = userAux.UserName,
                    token = this.userService.GetToken(userAux.UserName, userAux.id)                 
                };
            }
            return HelperGeneric<UserDto>.CastToGenericResponse(Helper.ManageResponse(userAuth));
        }
    }
}