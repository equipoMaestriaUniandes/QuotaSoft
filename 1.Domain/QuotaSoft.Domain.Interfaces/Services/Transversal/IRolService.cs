namespace Quota.Domain.Interfaces.Services.Transversal
{
    using Quota.Domain.Entities.Model.Transversal;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IRolService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Rol GetMenuByRol(int userId);
    }
}
