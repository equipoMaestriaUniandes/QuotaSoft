namespace Quota.Application.Interfaces.Transversal
{
    using Quota.Domain.Entities.Dto;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Response;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IUserApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        GenericResponse<User> SignIn(string userName, string password);
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        GenericResponse<User> GetUserAuth(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        GenericResponse<string> GetToken(string userName, int? id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        GenericResponse<IEnumerable<User>> GetUsers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        GenericResponse<User> GetUserByUserName(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        GenericResponse<User> GetUser(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        GenericResponse<User> GetUserByUserCode(int userCode);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        GenericResponse<User> InsertUser(User user);

        GenericResponse<User> UpdateUser(User user);

        GenericResponse<User> DeleteUser(int id);
    }
}
