using System.Text;
using ProjectData.Database.Entities;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace ProjectData.Database.Criterias
{
    public class DiefstalCriteria : Criteria<Diefstal>
    {
        public string Regios { get; set; }
        public List<string> RegioList { get; set; }
        public string Periode { get; set; }
        public List<string> Perioden { get; set; }
        public string Gebruikgeweld { get; set; }
        public string Soortdiefstal { get; set; }
        public string Totaaldiefstal { get; set; }
        public bool NoEmptyValues { get; set; }

        public override void Build(StringBuilder query)
        {
            if (NoEmptyValues)
            {
                QueryBuilder.AppendCustom("AND Totaal_Geregistreerde_Diefstallen <> ''");
            }

            if (!string.IsNullOrEmpty(Regios))
            {
                QueryBuilder.Append("Regio_Code", Regios);
            }

            if (RegioList != null && RegioList.Count != 0)
            {
                QueryBuilder.Append("Regio_Code", RegioList);
            }

            if (!string.IsNullOrEmpty(Periode))
            {
                QueryBuilder.Append("Perioden", Periode);
            }

            if (Perioden != null && Perioden.Count != 0)
            {
                QueryBuilder.Append("Perioden", Perioden);
            }

            if (!string.IsNullOrEmpty(Gebruikgeweld))
            {
                QueryBuilder.Append("Gebruik_Van_Geweld", Gebruikgeweld);
            }

            if (!string.IsNullOrEmpty(Soortdiefstal))
            {
                QueryBuilder.Append("Soort_Diefstal", Soortdiefstal);
            }

            if (!string.IsNullOrEmpty(Totaaldiefstal))
            {
                QueryBuilder.Append("Totaal_Geregistreerde_Diefstallen", Totaaldiefstal);
            }
        }
    }
}
