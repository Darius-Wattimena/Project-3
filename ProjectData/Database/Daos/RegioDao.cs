using System.Text;
using ProjectData.Database.Criterias;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Daos
{
    public class RegioDao : Dao<Regio, RegioCriteria>
    {
        protected override void Create(StringBuilder query, Regio instance)
        {
            query.Append("(Code, Name) ");
            query.Append("VALUES (");
            query.Append("'" + instance.Code + "', ");
            query.Append("'" + instance.Name + "'");
            query.Append(")");
        }

        protected override string SetTableName()
        {
            return "regio";
        }
    }
}
