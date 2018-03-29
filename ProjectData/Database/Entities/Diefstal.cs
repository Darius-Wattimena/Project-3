using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public enum DiefstalSoort
    {
        [Description("Alle diefstallen")] AlleDiefstallen,
        [Description("Diefstal van fiets")] DiefstalFiets,
        [Description("Diefstal van bromfiets/snorfiets")] DiefstalBromfietsSnorfiets,
        [Description("Diefstal van motor/scooter")] DiefstalMotorScooter,
        [Description("Diefstal van personenauto")] DiefstalPersonenauto,
        [Description("Diefstal van vervoermiddel (overig)")] DiefstalVervoermiddelOverig,
        [Description("Diefstal van vaartuig")] DiefstalVaartuig,
        [Description("Diefstal uit/vanaf personenauto")] DiefstalPersonenautoUV,
        [Description("Diefstal uit/vanaf vervoermiddel(overig)")] DiefstalVervoermiddelOverigUV,
        [Description("Diefstal uit/vanaf vaartuig")] DiefstalVaartuigUV,
        [Description("Diefstal van dier")] DiefstalDier,
        [Description("Straatroof")] Straatroof,
        [Description("Zakkenrollerij")] Zakkenrollerij,
        [Description("Totaal diefstal uit woning/schuur/e.d.")] TotaalDiefstalWoningSchuur,
        [Description("Diefstal/inbraak uit woning")] DiefstalInbraakWoning,
        [Description("Diefstal/inbraak uit schuur/garage/e.d")] DiefstalInbraakSchuurGarage,
        [Description("Winkeldiefstal")] Winkeldiefstal,
        [Description("Diefstal/inbraak uit winkel/bedrijf/e.d.")] DiefstalInbraakWinkelBedrijf,
        [Description("Diefstal/inbraak uit hotel/pension")] DiefstalInbraakHotelPension,
        [Description("Diefstal/inbraak uit school")] DiefstalInbraakSchool,
        [Description("Diefstal/inbraak uit sportcomplex")] DiefstalInbraakSportcomplex,
        [Description("Diefstal/inbraak uit defensiecomplex")] DiefstalInbraakDefensiecomplex,
        [Description("Diefstal/inbraak uit gebouw (overig)")] DiefstalInbraakGebouwOverig,
        [Description("Overval")] Overval,
        [Description("Diefstal en inbraak (overig)")] DiefstalEnInbraakOverig
    }
}
