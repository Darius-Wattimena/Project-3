using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using ProjectData.Database.Entities;
using ProjectData.Database.Criterias;
using ProjectData.Util;

namespace ProjectData.Database.Daos
{
    public abstract class Dao<T, U> 
        where T : IEntity
        where U : ICriteria<T>
    {
        private readonly string _tableName;

        private readonly Database _database = Database.GetInstance();

        protected Dao() => _tableName = SetTableName();

        private List<T> ExecuteQuery(MySqlCommand command)
        {
            Log.Info("Query Executed | " + command.CommandText);
            _database.OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();
            List<T> result = DatabaseUtil.GetDataFromDataReader<T>(reader);
            _database.CloseConnection();
            return result;
        }

        public List<T> ExecuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, _database.GetConnection());
            return ExecuteQuery(command);
        }

        private void ExecuteQueryNoResult(MySqlCommand command)
        {
            Log.Info("Query Executed | " + command.CommandText);
            _database.OpenConnection();
            command.ExecuteNonQuery();
            _database.CloseConnection();
        }

        public void ExecuteQueryNoResult(string query)
        {
            MySqlCommand command = new MySqlCommand(query, _database.GetConnection());
            ExecuteQueryNoResult(command);
        }

        public void Save(T instance)
        {
            if (instance.GetId() == 0)
            {
                Create(instance);
            }
        }

        public List<T> Find(Dictionary<string, object> parameters)
        {
            StringBuilder query = new StringBuilder("SELECT * FROM " + _tableName + " \n");
            MySqlCommand command = new MySqlCommand();
            query.Append("WHERE 1=1 \n");

            foreach (var parameter in parameters)
            {
                query.Append("AND " + parameter.Key + " = @" + parameter.Key + " \n");
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }
            command.CommandText = query.ToString();

            return ExecuteQuery(command);
        }

        public List<T> FindAll()
        {
            string query = "SELECT * FROM " + _tableName;
            return ExecuteQuery(query);
        }

        public List<T> FindByNewCriteria(Criteria<T> criteria)
        {
            StringBuilder query = new StringBuilder("SELECT * FROM " + _tableName);
            query.Append(" WHERE 1=1 ");
            criteria.GetQuery(query);
            return ExecuteQuery(query.ToString());
        }

        public List<T> FindByCriteria(U criteria)
        {
            StringBuilder query = new StringBuilder("SELECT * FROM " + _tableName);
            query.Append(" WHERE 1=1 ");
            criteria.Build(query);
            return ExecuteQuery(query.ToString());
        }

        private void Create(T instance)
        {
            StringBuilder query = new StringBuilder("INSERT INTO ");
            query.Append(_tableName);
            query.Append(" ");
            Create(query, instance);
            ExecuteQueryNoResult(query.ToString());
        }

        protected abstract void Create(StringBuilder query, T instance);

        protected abstract string SetTableName();
    }
}
