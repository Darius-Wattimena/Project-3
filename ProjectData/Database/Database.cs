using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using ProjectData.Database.Criterias;
using ProjectData.Database.Daos;
using ProjectData.Database.Entities;
using ProjectData.Util;

namespace ProjectData.Database
{
    class Database
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

            Log.Info(connectionString.ToString());

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
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
