namespace ProjectData.Database.Entities
{
    public class GemiddeldInkomen : IEntity
    {
        public int GemiddeldInkomenId { get; set; }

        public string RegioCode { get; set; }

        public string Perioden { get; set; }

        public decimal AantalPersonen { get; set; }

        public decimal GemiddeldBesteedbaarInkomen { get; set; }

        public int RangnummerBesteedbaarInkomen { get; set; }

        public decimal GemiddeldGestandaardiseerdInkomen { get; set; }

        public int RangnummerGestandaardiseerdInkomen { get; set; }

        public decimal AantalPersonen_2 { get; set; }

        public int InVanPersonenMetEnZonderInkomen { get; set; }

        public decimal GemiddeldPersoonlijkInkomen { get; set; }

        public int RangnummerPersoonlijkInkomen { get; set; }

        public decimal GemiddeldBesteedbaarInkomen_2 { get; set; }

        public int RangnummerBesteedbaarInkomen_2 { get; set; }

        public int GetId()
        {
            return GemiddeldInkomenId;
        }
    }
}
