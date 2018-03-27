namespace ProjectData.Database.Entities
{
    public class Preventie : IEntity
    {
        public int PreventieId { get; set; }

        public string RegioCode { get; set; }

        public string Perioden { get; set; }

        public decimal LichtBijAfwezigheid { get; set; }

        public decimal FietsInStalling { get; set; }

        public decimal SpullenUitAuto { get; set; }

        public decimal SpullenThuisLaten { get; set; }

        public decimal SociaalPreventiefGedragscore { get; set; }

        public decimal ExtraSlotenDeur { get; set; }

        public decimal Rolluiken { get; set; }

        public decimal Buitenverlichting { get; set; }

        public decimal Alarm { get; set; }

        public decimal PreventieSomscore { get; set; }

        public int GetId()
        {
            return PreventieId;
        }
    }
}
