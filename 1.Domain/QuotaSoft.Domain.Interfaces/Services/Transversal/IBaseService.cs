﻿namespace Quota.Domain.Interfaces.Services.Transversal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Quota.Domain.Entities.Model.Transversal;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="DataType">The type of the ata type.</typeparam>
    public interface IBaseService<T> where T : BaseEntity
    {
        /// <summary>
        /// Reads procedure.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> ExecuteProcedure(string procedure);

        /// <summary>
        /// Procedures the with parameters.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <param name="myObject">My object.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> ExecuteProcedureWithParams(string procedure, T myObject);

        /// <summary>
        /// Executes the insert procedure.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <param name="myObject">My object.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> ExecuteInsertProcedure(string procedure, T myObject);

        /// <summary>
        /// Executes the procedure with parameters.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <param name="myObject">My object.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> ExecuteProcedureWithParams(string procedure, object myObject);
    }
}
