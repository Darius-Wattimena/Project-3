using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjectData.Database.Entities;
using ProjectData.Database.Criterias;

namespace ProjectData.Database.Daos
{
    public abstract class Dao<T, U> 
        where T : IEntity
        where U : ICriteria<T>
    {
        private readonly string tableName;

        private readonly Database database = Database.GetInstance();

        protected Dao()
        {
            tableName = SetTableName();
        }

        private List<T> ExecuteQuery(MySqlCommand command)
        {
            database.OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();
            List<T> result = DatabaseUtil.GetDataFromDataReader<T>(reader);
            database.CloseConnection();
            return result;
        }

        public List<T> ExecuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, database.GetConnection());
            return ExecuteQuery(command);
        }

        private void ExecuteQueryNoResult(MySqlCommand command)
        {
            database.OpenConnection();
            command.ExecuteNonQuery();
            database.CloseConnection();
        }

        public void ExecuteQueryNoResult(string query)
        {
            MySqlCommand command = new MySqlCommand(query, database.GetConnection());
            ExecuteQueryNoResult(command);
        }

        public void Save(T instance)
        {
            if (instance.GetId() == 0)
            {
                Create(instance);
            }
            else
            {
                //Update(instance);
            }
        }

        public List<T> Find(Dictionary<string, object> parameters)
        {
            StringBuilder query = new StringBuilder("SELECT * FROM " + tableName + " \n");
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
            string query = "SELECT * FROM " + tableName;
            return ExecuteQuery(query);
        }

        public List<T> FindByCriteria(U criteria)
        {
            StringBuilder query = new StringBuilder("SELECT * FROM " + tableName);
            query.Append(" WHERE 1=1 ");
            criteria.Build(query);
            return ExecuteQuery(query.ToString());
        }

        private void Create(T instance)
        {
            StringBuilder query = new StringBuilder("INSERT INTO ");
            query.Append(tableName);
            query.Append(" ");
            Create(query, instance);
            ExecuteQueryNoResult(query.ToString());
        }

        protected abstract void Create(StringBuilder query, T instance);

        protected abstract string SetTableName();
    }
}
