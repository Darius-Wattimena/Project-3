using System.Text;
using ProjectData.Database.Criterias;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Daos
{
    public class GemiddeldInkomenDao : Dao<GemiddeldInkomen, GemiddeldInkomenCriteria>
    {
        protected override void Create(StringBuilder query, GemiddeldInkomen instance)
        {
            query.Append("(Regio_Code, Perioden, Aantal_Personen, Gemiddeld_Besteedbaar_Inkomen, Rangnummer_Besteedbaar_Inkomen, Gemiddeld_Gestandaardiseerd_Inkomen, Rangnummer_Gestandaardiseerd_Inkomen, Aantal_Personen_2, In_Van_Personen_Met_En_Zonder_Inkomen, Gemiddeld_Persoonlijk_Inkomen, Rangnummer_Persoonlijk_Inkomen, Gemiddeld_Besteedbaar_Inkomen_2, Rangnummer_Besteedbaar_Inkomen_2)");
            query.Append(" VALUES (");
            query.Append("'" + instance.RegioCode + "', ");
            query.Append("'" + instance.Perioden + "', ");
            query.Append("'" + instance.AantalPersonen.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.GemiddeldBesteedbaarInkomen.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.RangnummerBesteedbaarInkomen + "', ");
            query.Append("'" + instance.GemiddeldGestandaardiseerdInkomen.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.RangnummerGestandaardiseerdInkomen + "', ");
            query.Append("'" + instance.AantalPersonen_2.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.InVanPersonenMetEnZonderInkomen + "', ");
            query.Append("'" + instance.GemiddeldPersoonlijkInkomen.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.RangnummerPersoonlijkInkomen + "', ");
            query.Append("'" + instance.GemiddeldBesteedbaarInkomen_2.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.RangnummerBesteedbaarInkomen_2 + "'");
            query.Append(")");
        }

        protected override string SetTableName()
        {
            return "gemiddeldinkomen";
        }
    }
}
