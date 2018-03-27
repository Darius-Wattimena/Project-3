using System.Text;
using ProjectData.Database.Criterias;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Daos
{
    public class DiefstalDao : Dao<Diefstal, DiefstalCriteria>
    {
        protected override void Create(StringBuilder query, Diefstal instance)
        {
            query.Append("(GebruikVanGeweld, SoortDiefstal, Regios, Perioden, TotaalGeregistreerdeDiefstallen_1) ");
            query.Append("VALUES (");
            query.Append("'" + instance.Gebruikgeweld + "', ");
            query.Append("'" + instance.Soortdiefstal + "', ");
            query.Append("'" + instance.Regios + "', ");
            query.Append("'" + instance.Perioden + "', ");
            query.Append("'" + instance.Totaaldiefstal + "'");
            query.Append(")");
        }

        protected override string SetTableName()
        {
            return "diefstal";
        }
    }
}
