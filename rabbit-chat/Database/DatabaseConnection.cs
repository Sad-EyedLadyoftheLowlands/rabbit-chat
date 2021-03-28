using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace rabbit_chat.Database
{
    public interface IDatabaseConnection
    {
        NpgsqlConnection GetConnection();
        void Dispose(NpgsqlConnection connection);
    }
    public class DatabaseConnection : IDatabaseConnection
    {
        // This can be readonly - to be kept in mind
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Opens Npgsql connection with credentials from appsettings
        /// </summary>
        /// <returns></returns>
        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection connection =
                new NpgsqlConnection(_configuration.GetValue<string>("PostgreSQL:ConnectionString"));
            
            connection.Open();

            return connection;
        }

        /// <summary>
        /// Takes in an Npgsql connection and closes it
        /// </summary>
        /// <param name="connection"></param>
        public void Dispose(NpgsqlConnection connection)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
            
            // Not sure why we do this - ensuring there are not connections hanging around?
            connection = null;
        }
    }
}