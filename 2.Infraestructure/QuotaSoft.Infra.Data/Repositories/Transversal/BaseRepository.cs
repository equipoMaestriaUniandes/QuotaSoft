namespace Quota.Infra.Data.Repositories.Transversal
{
    using System;
    using System.Data.SqlClient;
    using global::Dapper.Contrib.Extensions;
    using Quota.Domain.Entities.Enums;
    using Newtonsoft.Json;
    using Quota.Domain.Entities.Model.Transversal;
    using Quota.Domain.Interfaces.Repositories.Transversal;
    using System.Collections.Generic;
    using System.Linq;
    using Quota.Domain.Entities.Config;

    public class BaseRepository<T> : QueryRepository<T>, IBaseRepository<T> where T : BaseEntity
    {
        public BaseRepository(IDbFactory dbFactory)
          : base(dbFactory)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual long Insert(T entity)
        {
            using (var db = this.DbFactory.GetConnection())
            {
               return db.Insert(entity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            using (var db = this.DbFactory.GetConnection())
            {
                try
                {
                    db.Delete(entity);
                }
                catch (SqlException sqlException)
                {
                    if (sqlException.Number == (int)BaseRepositpryEnum.ERRORFIVEHOUNDREDFORTYSEVEN)
                    {
                        throw new InvalidOperationException("Error, this register has relationships.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            using (var db = this.DbFactory.GetConnection())
            {
                db.Update(entity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="tableName"></param>
        public void InsertMasive(IEnumerable<T> entities, string tableName)
        {
            using (SqlConnection conn = new SqlConnection(this.DbFactory.GetConnString()))
            {
                var dataTable = entities.ToList().ConvertToDataTable();
                var propertiesToInsert = entities.FirstOrDefault().GetPropertiesWhitoutAttributes("Key");
                using (var bulkCopy = new SqlBulkCopy(conn))
                {
                    foreach (var propertyAux in propertiesToInsert)
                    {
                        bulkCopy.ColumnMappings.Add(propertyAux, propertyAux);
                    }
                    bulkCopy.DestinationTableName = tableName;
                    bulkCopy.BatchSize = ConstantsData.BatchSize;
                    bulkCopy.BulkCopyTimeout = ConstantsData.BulkCopyTimeout;
                    conn.Open();
                    bulkCopy.WriteToServer(dataTable);
                    conn.Close();
                }
            }
        }
    }
}
