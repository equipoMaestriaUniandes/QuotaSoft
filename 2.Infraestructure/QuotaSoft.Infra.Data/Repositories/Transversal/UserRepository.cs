namespace Quota.Infra.Data.Repositories.Transversal
{
    using System.Linq;
    using Dapper;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using Quota.Domain.Entities.Model.Authentication;

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserAuth(string userName)
        {
            var query = "SELECT * FROM [dbo].[user] WHERE userName = @userName";
            return base.GetQueryData(query, new { userName = userName })?.FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserById(int? userId)
        {
            var query = "SELECT * FROM [dbo].[user] WHERE id = @userId";
            return base.GetQueryData(query, new { userId = userId })?.FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            var query = "SELECT * FROM [dbo].[user] WHERE userName = @usuario";
            return base.GetQueryData(query, new { usuario = userName })?.FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public User GetUserByUserCode(int userCode)
        {
            var query = "SELECT * FROM [dbo].[user] WHERE id = @userCode";
            return base.GetQueryData(query, new { userCode = userCode })?.FirstOrDefault();
        }
    }
}
