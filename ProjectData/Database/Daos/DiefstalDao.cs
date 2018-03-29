using System.Text;
using ProjectData.Database.Criterias;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Daos
{
    public class DiefstalDao : Dao<Diefstal, DiefstalCriteria>
    {
        protected override void Create(StringBuilder query, Diefstal instance)
        {
            query.Append("(Gebruik_Van_Geweld, Soort_Diefstal, Regio_Code, Perioden, Totaal_Geregistreerde_Diefstallen, Geregistreerde_Diefstallen_Relatief, Geregistreerde_Diefstallen_Per1000_Inw, Totaal_Opgehelderde_Diefstallen, Opgehelderde_Diefstallen_Relatief, Registraties_Van_Verdachten)");
            query.Append(" VALUES (");
            query.Append("'" + instance.GebruikVanGeweld + "', ");
            query.Append("'" + instance.SoortDiefstal + "', ");
            query.Append("'" + instance.RegioCode + "', ");
            query.Append("'" + instance.Perioden + "', ");
            query.Append("'" + instance.TotaalGeregistreerdeDiefstallen + "', ");
            query.Append("'" + instance.GeregistreerdeDiefstallenRelatief + "', ");
            query.Append("'" + instance.GeregistreerdeDiefstallenPer1000Inw.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.TotaalOpgehelderdeDiefstallen + "', ");
            query.Append("'" + instance.OpgehelderdeDiefstallenRelatief.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.RegistratiesVanVerdachten + "'");
            query.Append(")");
        }

        protected override string SetTableName()
        {
            return "diefstal";
        }
    }
}
