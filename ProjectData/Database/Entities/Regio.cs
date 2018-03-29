using System.ComponentModel;

namespace ProjectData.Database.Entities
{
    public class Regio : IEntity
    {
        public static readonly string Groningen = "PV20";
        public static readonly string Friesland = "PV21";
        public static readonly string Drenthe = "PV22";
        public static readonly string Overijssel = "PV23";
        public static readonly string Flevoland = "PV24";
        public static readonly string Gelderland = "PV25";
        public static readonly string Utrecht = "PV26";
        public static readonly string NoordHolland = "PV27";
        public static readonly string ZuidHolland = "PV28";
        public static readonly string Zeeland = "PV29";
        public static readonly string NoordBrabant = "PV30";
        public static readonly string Limburg = "PV31";
        public static readonly string NietInTeDelen = "PV99";

        public int RegioId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int GetId()
        {
            return RegioId;
        }
    }

    public enum RegioCode
    {
        [Description("PV20")] Groningen,
        [Description("PV21")] Friesland,
        [Description("PV22")] Drenthe,
        [Description("PV23")] Overijssel,
        [Description("PV24")] Flevoland,
        [Description("PV25")] Gelderland,
        [Description("PV26")] Utrecht,
        [Description("PV27")] NoordHolland,
        [Description("PV28")] ZuidHolland,
        [Description("PV29")] Zeeland,
        [Description("PV30")] NoordBrabant,
        [Description("PV31")] Limburg,
        [Description("PV99")] NietInTeDelen
}
}
