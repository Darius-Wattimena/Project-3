using System.Text;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Criterias
{
    public class RegioCriteria : ICriteria<Regio>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public void Build(StringBuilder query)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                query.Append("AND Name = '" + Name + "' ");
            }

            if (!string.IsNullOrEmpty(Code))
            {
                query.Append("AND Code = '" + Code + "' ");
            }
        }
    }
}
