namespace Quota.Application.Services.Transversal
{
    using Quota.Application.Interfaces.Transversal;
    using Quota.Domain.Entities.Dto;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Response;
    using Quota.Domain.Interfaces.Services;
    using Quota.Domain.Interfaces.Services.Transversal;
    using Quota.Domain.Services.Utilities;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="UserApplication" />
    /// </summary>
    public class UserApplication : BaseApplication<User>, IUserApplication
    {
        /// <summary>
        /// Defines the authorizationService
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserApplication"/> class.
        /// </summary>
        /// <param name="userService">The userService<see cref="IUserService"/></param>
        public UserApplication(IBaseService<User> baseService, IUserService userService) : base(baseService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public GenericResponse<User> SignIn(string userName, string password)
        {
            var obj = this.userService.SignIn(userName, password);
            return HelperGeneric<User>.CastToGenericResponse(Helper.ManageResponse(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public GenericResponse<User> GetUserAuth(string userName)
        {
            var obj = this.userService.GetUserAuth(userName);
            return HelperGeneric<User>.CastToGenericResponse(Helper.ManageResponse(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public GenericResponse<string> GetToken(string userName, int? id)
        {
            var obj = this.userService.GetToken(userName, id);
            return HelperGeneric<string>.CastToGenericResponse(Helper.ManageResponse(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GenericResponse<IEnumerable<User>> GetUsers()
        {
            var obj = this.userService.GetUsers();
            return HelperGeneric<IEnumerable<User>>.CastToGenericResponse(Helper.ManageResponse(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public GenericResponse<User> GetUserByUserName(string userName)
        {
            var obj = this.userService.GetUserByUserName(userName);
            return HelperGeneric<User>.CastToGenericResponse(Helper.ManageResponse(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public GenericResponse<User> GetUser(int userId)
        {
            var obj = this.userService.GetUser(userId);
            return HelperGeneric<User>.CastToGenericResponse(Helper.ManageResponse(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public GenericResponse<User> GetUserByUserCode(int userCode)
        {
            var obj = this.userService.GetUserByUserCode(userCode);
            return HelperGeneric<User>.CastToGenericResponse(Helper.ManageResponse(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public GenericResponse<User> InsertUser(User user)
        {
            var obj = this.userService.InsertUser(user);

            return HelperGeneric<User>.CastToGenericResponse(Helper.ManageResponse(obj));
        }
    }
}
