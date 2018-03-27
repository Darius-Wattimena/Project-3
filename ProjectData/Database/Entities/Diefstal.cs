using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Database.Entities
{
    public class Diefstal : IEntity
    {
        public int DiefstalId { get; set; }

        public string Regios { get; set; }

        public string Perioden { get; set; }

        public int Gebruikgeweld { get; set; }

        public int Soortdiefstal { get; set; }

        public float Totaaldiefstal { get; set; }

        public int GetId()
        {
            return DiefstalId;
        }
    }
}
