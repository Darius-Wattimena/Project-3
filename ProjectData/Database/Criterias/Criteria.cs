using System.Text;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Criterias
{
    public abstract class Criteria<T> : ICriteria<T> where T : IEntity
    {
        protected QueryBuilder QueryBuilder = new QueryBuilder();

        public void GetQuery(StringBuilder query)
        {
            Build(query);
            query.Append(QueryBuilder.GetQuery());
        }

        public abstract void Build(StringBuilder query);
    }
}
