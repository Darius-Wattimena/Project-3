using System.Text;
using ProjectData.Database.Criterias;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Daos
{
    public class PreventieDao : Dao<Preventie, PreventieCriteria>
    {
        protected override void Create(StringBuilder query, Preventie instance)
        {
            query.Append("(RegioS, Perioden, SAvondsLichtBrandenBijAfwezigheid_1 , FietsInBewaakteFietsenstalling_2 , WaardevolleSpullenMeenemenUitAuto_3 , WaardevolleSpullenThuisLaten_4 , SociaalPreventiefGedragSchaalscore_5 , ExtraVeiligheidsslotenOpBuitendeuren_6  , RolluikenVoorRamenEnOfDeuren_7, Buitenverlichting_8, Alarminstallatie_9, PreventieInRondWoningSomscore_10) ");
            query.Append("VALUES (");
            query.Append("'" + instance.RegioCode + "', ");
            query.Append("'" + instance.Perioden + "', ");
            query.Append("'" + instance.LichtBijAfwezigheid.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.FietsInStalling.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.SpullenUitAuto.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.SpullenThuisLaten.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.SociaalPreventiefGedragscore.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.ExtraSlotenDeur.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.Rolluiken.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.Buitenverlichting.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.Alarm.ToString().Replace(",", ".") + "', ");
            query.Append("'" + instance.PreventieSomscore.ToString().Replace(",", ".") + "'");
            query.Append(")");
        }

        protected override string SetTableName()
        {
            return "preventie";
        }
    }
}
