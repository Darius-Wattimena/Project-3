using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Database
{
    public class QueryBuilder
    {
        private readonly StringBuilder _queryBuilder = new StringBuilder();
        private string groupBy;

        public QueryBuilder AppendCustom(string query)
        {
            _queryBuilder.Append(query + " ");
            return this;
        }

        public QueryBuilder Append(string fieldName, string value)
        {
            _queryBuilder.Append("AND " + fieldName + " = '" + value + "' ");
            return this;
        }

        public QueryBuilder Append(string fieldName, List<string> values)
        {
            if (values == null) return this;

            var query = string.Empty;
            var first = true;
            foreach (var value in values)
            {
                if (first)
                {
                    query += "AND ("+ fieldName + " = '" + value + "' ";
                    first = false;
                }
                else
                {

                    query += "OR " + fieldName + " = '" + value + "' ";
                }
            }

            query += ") ";
            _queryBuilder.Append(query);

            return this;
        }

        public QueryBuilder GroupBy(string query)
        {
            groupBy = query + " ";
            return this;
        }

        public string GetQuery()
        {
            if (!string.IsNullOrEmpty(groupBy))
            {
                _queryBuilder.Append(groupBy);
            }
            return _queryBuilder.ToString();
        }
    }
}
