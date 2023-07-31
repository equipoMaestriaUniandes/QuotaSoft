namespace Quota.Domain.Interfaces.Services
{
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Interfaces.Services.Transversal;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IUserService" />
    /// </summary>
    public interface IUserService : IBaseService<User>
    {
      //  IEnumerable<User> GetByRol(int rolId);

        
       // User UpdatePassword(int userId, string oldPassword, string newPassword);

      //  User InactivateUser(User user);

       /// <summary>
       /// 
       /// </summary>
       /// <param name="userName"></param>
       /// <param name="password"></param>
       /// <returns></returns>
        User SignIn(string userName, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUserAuth(string userName);

       /// <summary>
       /// 
       /// </summary>
       /// <param name="userName"></param>
       /// <returns></returns>
        string GetToken(string userName, int? id);
                
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUserById(int? userId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUserByUserName(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUser(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        User GetUserByUserCode(int userCode);

        User InsertUser(User user);

        User UpdateUser(User user);

        User DeleteUser(int id);

    }
}
