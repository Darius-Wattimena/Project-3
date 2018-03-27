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
            query.Append("'" + instance.LichtBijAfwezigheid + "', ");
            query.Append("'" + instance.FietsInStalling + "', ");
            query.Append("'" + instance.SpullenUitAuto + "', ");
            query.Append("'" + instance.SpullenThuisLaten + "', ");
            query.Append("'" + instance.SociaalPreventiefGedragscore + "', ");
            query.Append("'" + instance.ExtraSlotenDeur + "', ");
            query.Append("'" + instance.Rolluiken + "', ");
            query.Append("'" + instance.Buitenverlichting + "', ");
            query.Append("'" + instance.Alarm + "', ");
            query.Append("'" + instance.PreventieSomscore + "'");
            query.Append(")");
        }

        protected override string SetTableName()
        {
            return "preventie";
        }
    }
}
