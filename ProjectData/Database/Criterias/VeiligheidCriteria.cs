using ProjectData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Database.Criterias
{
    public class VeiligheidCriteria : Criteria<Veiligheid>
    {
        public List<string> RegioList { get; set; }
        public string Periode { get; set; }
        public string  { get; set; }

        public override void Build(StringBuilder query)
        {
            if (RegioList != null && RegioList.Count != 0)
            {
                QueryBuilder.Append("Regio_Code", RegioList);
            }

            if (!string.IsNullOrEmpty(Periode))
            {
                QueryBuilder.Append("Perioden", Periode);
            }

           if (!string.IsNullOrEmpty( ))
           {
               QueryBuilder.Append("", );
           }
        }
    }
}
