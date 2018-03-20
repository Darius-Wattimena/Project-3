using System.Text;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Criterias
{
    public class PreventieCriteria : ICriteria<Preventie>
    {
        public string Regios { get; set; }
        public string Perioden { get; set; }
        public string LichtAfwezig { get; set; }

        public void Build(StringBuilder query)
        {
            if (!string.IsNullOrEmpty(Regios))
            {
                query.Append("AND Perioden = '" + Regios + "' ");
            }

            if (!string.IsNullOrEmpty(Perioden))
            {
                query.Append("AND Perioden = '" + Perioden + "' ");
            }

            if (!string.IsNullOrEmpty(LichtAfwezig)) {
                query.Append("AND LichtAfwezig = '" + LichtAfwezig + "' ");
            }
        }
    }
}
