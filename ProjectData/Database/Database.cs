using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using ProjectData.Database.Criterias;
using ProjectData.Database.Daos;
using ProjectData.Database.Entities;

namespace ProjectData.Database
{
    public class Database
    {
        private static Database _instance;

        private MySqlConnection _connection;

        private const string SERVER = "localhost";
        private const string DATABASE = "project3";
        private const string USER = "root";
        private const string PASSWORD = "admin";

        public static Database GetInstance()
        {
            return _instance ?? (_instance = new Database());
        }

        private Database()
        {
            StringBuilder connectionString = new StringBuilder();
            connectionString.Append("SERVER=" + SERVER + ";");
            connectionString.Append("DATABASE=" + DATABASE + ";");
            connectionString.Append("UID=" + USER + ";");
            connectionString.Append("PASSWORD=" + PASSWORD + ";");

            _connection = new MySqlConnection(connectionString.ToString());
        }

        public List<E> ExecuteRaw<T, E, C>(string query, T dao) 
            where E : IEntity
            where C : ICriteria<E>
            where T : Dao<E, C>
        {
            OpenConnection();
            List<E> result = dao.ExecuteQuery(query);
            CloseConnection();
            return result;
        }

        public void TestConnection()
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SHOW STATUS LIKE 'Conn%';", _connection);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void OpenConnection()
        {
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
