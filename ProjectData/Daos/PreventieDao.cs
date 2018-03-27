using System.Text;
using ProjectData.Database.Criterias;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Daos
{
    public class PreventieDao : Dao<Preventie, PreventieCriteria>
    {
        protected override void Create(StringBuilder query, Preventie instance)
        {
            query.Append("(Regios, Perioden, SAvondsLichtBrandenBijAfwezigheid_1) ");
            query.Append("VALUES (");
            query.Append("'" + instance.Regios + "', ");
            query.Append("'" + instance.Perioden + "', ");
            query.Append("'" + instance.LichtAfwezig + "'");
            query.Append(")");
        }

        protected override string SetTableName()
        {
            return "preventie";
        }
    }
}
