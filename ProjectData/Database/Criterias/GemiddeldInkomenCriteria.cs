using System.Collections.Generic;
using System.Text;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Criterias
{
    public class GemiddeldInkomenCriteria : Criteria<GemiddeldInkomen>
    {
        public string Regios { get; set; }
        public List<string> RegioList { get; set; }
        public string Periode { get; set; }
        public List<string> Perioden { get; set; }

        public override void Build(StringBuilder query)
        {
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
        }
    }
}
