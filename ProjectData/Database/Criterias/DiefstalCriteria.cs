using System.Text;
using ProjectData.Database.Entities;
using System.Collections.Generic;

namespace ProjectData.Database.Criterias
{
    public class DiefstalCriteria : ICriteria<Diefstal>
    {
        public string Regios { get; set; }
        public List<string> Perioden { get; set; }
        public string Gebruikgeweld { get; set; }
        public string Soortdiefstal { get; set; }
        public string Totaaldiefstal { get; set; }

        public void Build(StringBuilder query)
        {
            if (!string.IsNullOrEmpty(Regios))
            {
                query.Append("AND RegioS = '" + Regios + "' ");
            }

            if (!(Perioden.Count == 0))
            {
                string MySqlQuery = "";
                for (int i = 0; i < Perioden.Count; i++)
                {
                    if (i == 0)
                    {
                        MySqlQuery = "AND (Perioden = '" + Perioden[i] + "' ";
                    }
                    else
                    {
                        MySqlQuery += "OR Perioden = '" + Perioden[i] + "' ";
                    }

                }
                MySqlQuery += ")";

                query.Append(MySqlQuery);
            }

            if (!string.IsNullOrEmpty(Gebruikgeweld))
            {
                query.Append("AND GebruikVanGeweld = " + Gebruikgeweld + " ");
            }

            if (!string.IsNullOrEmpty(Soortdiefstal))
            {
                query.Append("AND SoortDiefstal = " + Soortdiefstal + " ");
            }

            if (!string.IsNullOrEmpty(Totaaldiefstal))
            {
                query.Append("AND TotaalGeregistreerdeDiefstallen_1 = " + Totaaldiefstal + " ");
            }
        }
    }
}
