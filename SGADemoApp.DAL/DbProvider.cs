using MySql.Data.MySqlClient;
using System.Data;

namespace SGADemoApp.DAL
{
    public class DbProvider
    {
        private readonly string connectionString;

        public DbProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
