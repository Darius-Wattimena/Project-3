using System.Text;
using ProjectData.Database.Entities;

namespace ProjectData.Database.Criterias
{
    public interface ICriteria<T> where T : IEntity
    {
        void Build(StringBuilder query);
    }
}
