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
    internal class Database
    {
        private static Database _instance;

        private readonly MySqlConnection _connection;

        private static readonly string SERVER = Properties.Settings.Default.Database_Host;
        private static readonly string DATABASE = Properties.Settings.Default.Database_Table;
        private static readonly string USER = Properties.Settings.Default.Database_Username;
        private static readonly string PASSWORD = Properties.Settings.Default.Database_Password;

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
