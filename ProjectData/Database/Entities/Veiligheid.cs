using System;

namespace ProjectData.Database.Entities
{
    public class Veiligheid : IEntity
    {
        public int VeiligheidsbelevingId { get; set; }

        public string Marges { get; set; }

        public string RegioCode { get; set; }

        public string Perioden { get; set; }

        public string WelEensOnveilig { get; set; }

        public string VaakOnveilig { get; set; }

        public string Zakkenrollerij { get; set; }

        public string StraatBeroving { get; set; }

        public string WoningInbraak { get; set; }

        public string Mishandeling { get; set; }

        public string WelEensOnveiligBuurt { get; set; }

        public string VaakOnveiligBuurt { get; set; }

        public string AvondBuurt { get; set; }

        public string AvondAlleenThuis { get; set; }

        public string AvondDeurNietOpen { get; set; }

        public string LooptOm { get; set; }

        public string BangSlachtoffer { get; set; }

        public string CriminaliteitBuurtToe { get; set; }

        public string CriminaliteitBuurtAf { get; set; }

        public string CriminaliteitBuurtGelijk { get; set; }

        public string CijferVeiligheidBuurt { get; set; }

        public string Uitgaan { get; set; }

        public string Hangplekken { get; set; }

        public string CentrumWoonplaats { get; set; }

        public string Winkelgebied { get; set; }

        public string InOV { get; set; }

        public string Treinstation { get; set; }

        public string EigenHuis { get; set; }

        public string OnbekendenStraat { get; set; }

        public string OnbekendenOV { get; set; }

        public string PersoneelWinkelsBedrijven { get; set; }

        public string PersoneelOverheid { get; set; }

        public string BekendenPartnerFamilie { get; set; }

        public int GetId()
        {
            return VeiligheidsbelevingId;
        }
    }
}