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

        public string GebruikVanGeweld { get; set; }

        public string SoortDiefstal { get; set; }

        public string RegioCode { get; set; }

        public string Perioden { get; set; }

        public string TotaalGeregistreerdeDiefstallen { get; set; }

        public string GeregistreerdeDiefstallenRelatief { get; set; }

        public decimal GeregistreerdeDiefstallenPer1000Inw { get; set; }

        public string TotaalOpgehelderdeDiefstallen { get; set; }

        public decimal OpgehelderdeDiefstallenRelatief { get; set; }

        public string RegistratiesVanVerdachten { get; set; }

        public int GetId()
        {
            return DiefstalId;
        }
    }
}
