using System.Text;
using ProjectData.Database.Criterias;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Daos
{
    public class VeiligheidDao : Dao<Veiligheid, VeiligheidCriteria>
    {
        protected override void Create(StringBuilder query, Veiligheid instance)
        {
            query.Append("(Marges, ) ");
            query.Append("VALUES (");
            //query.Append("'" + instance.Regios + "', ");
            //query.Append("'" + instance.Perioden + "', ");
            //query.Append("'" + instance.LichtAfwezig + "'");
            query.Append(")");
        }

        protected override string SetTableName()
        {
            return "veiligheid";
        }
    }
}
