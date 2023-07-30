namespace Quota.Domain.Interfaces.Repositories.Transversal
{
    using Quota.Domain.Entities;
    using Quota.Domain.Entities.Model.Authentication;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using System.Collections.Generic;

    public interface IUserRepository : IBaseRepository<User>
    {
        // IEnumerable<User> ObtenerUsuariosFiltro(UsuarioFiltro filtro);

        //  IEnumerable<User> GetUsers(int id = 0);

        User GetUserAuth(string userName);        

        // string ValidarExistencia(User user);

         User GetUserById(int? id);

        //bool ExistsUserByRolValidation(int rolId);

        // bool RolAsignedUserValidation(Rol rol);

        // IEnumerable<User> GetByRol(string rolId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUserByUserName(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        User GetUserByUserCode(int userCode);
    }
}
