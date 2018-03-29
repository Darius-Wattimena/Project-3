using System.Text;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Criterias
{
    public class RegioCriteria : Criteria<Regio>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public override void Build(StringBuilder query)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                QueryBuilder.Append("Name", Name);
            }

            if (!string.IsNullOrEmpty(Code))
            {
                QueryBuilder.Append("Code", Code);
            }
        }
    }
}
