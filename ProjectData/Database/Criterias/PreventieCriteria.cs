using System.Text;
using ProjectData.Database.Entities;
using System.Collections.Generic;

namespace ProjectData.Database.Criterias
{
    public class PreventieCriteria : Criteria<Preventie>
    {
        public List<string> Regios { get; set; }
        public List<string> Perioden { get; set; }
        public string LichtAfwezig { get; set; }

        public override void Build(StringBuilder query)
        {
            if (Regios.Count != 0)
            {
                QueryBuilder.Append("RegioS", Regios);
            }

            if (Perioden.Count != 0)
            {
                QueryBuilder.Append("Perioden", Perioden);
            }

            if (!string.IsNullOrEmpty(LichtAfwezig))
            {
                QueryBuilder.Append("SAvondsLichtBrandenBijAfwezigheid_1", LichtAfwezig);
            }

            QueryBuilder.AppendCustom("AND SAvondsLichtBrandenBijAfwezigheid_1 >= 10");
        }
    }
}
