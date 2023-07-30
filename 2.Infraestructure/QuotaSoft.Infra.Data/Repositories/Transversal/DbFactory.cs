namespace Quota.Infra.Data.Repositories.Transversal
{
    using Microsoft.Extensions.Options;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using Quota.Domain.Entities.Config;
    using Quota.Domain.Interfaces.Repositories.Transversal;

    public class DbFactory : IDbFactory
    {
        /// <summary>
        /// The string connection.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbFactory"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        public DbFactory(IOptions<AppSettings> appSettings)
        {
            this.connectionString = appSettings.Value.DefaultConnectionString;
        }

        /// <summary>
        /// The get connection.
        /// </summary>
        /// <returns>
        /// The <see cref="IDbConnection"/>.
        /// </returns>
        public IDbConnection GetConnection()
        {
            DbConnection sqlConnection = new SqlConnection(this.connectionString);
            var wrapConnection = new WrapDBConnection(sqlConnection);
            wrapConnection.Open();
            return wrapConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetConnString() {
            return this.connectionString;
        }

    }
}
