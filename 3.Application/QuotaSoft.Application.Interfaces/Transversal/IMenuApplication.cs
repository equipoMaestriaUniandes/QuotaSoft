namespace Quota.Application.Interfaces.Transversal
{
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Entities.Response;
    using System.Collections.Generic;

    public interface IMenuApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        GenericResponse<List<Menu>> GetMenuByClaimsUserIn(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        GenericResponse<List<Menu>> GetMenuByUserIn(string userName);
    }
}
