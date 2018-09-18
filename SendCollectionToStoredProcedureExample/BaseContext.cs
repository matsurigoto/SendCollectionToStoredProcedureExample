using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;


namespace SendCollectionToStoredProcedureExample
{
    public class BaseContext: DbContext
    {
        protected string connectionName;

        public BaseContext(string connName = "BaseConnection")
            : base(connName)
        {
            connectionName = connName;
        }

        public BaseContext setDatabase(string databaseName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            //change the database before creating the new connection
            builder.InitialCatalog = databaseName;

            string sqlConnectionString = builder.ConnectionString;

            return new BaseContext(sqlConnectionString);
        }
    }
}
