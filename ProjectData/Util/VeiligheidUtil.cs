using ProjectData.Database.Entities;
using System;
using System.Globalization;

namespace ProjectData.Util
{
    public class VeiligheidUtil
    {
        public static double GetVeiligheidValueFromString(string value)
        {
            return Convert.ToDouble(value, CultureInfo.InvariantCulture.NumberFormat);
        }

        public static VeiligheidSoort PickVeiligheidType(string pickedVeiligheid)
        {
            switch (pickedVeiligheid)
            {
                case "Voelt zich wel eens onveilig":
                    return VeiligheidSoort.WelEensOnveilig;
                case "Voelt zich vaak onveilig":
                    return VeiligheidSoort.VaakOnveilig;
                case "Denkt dat de kans groot is slachtoffer te worden van zakkenrollerij":
                    return VeiligheidSoort.Zakkenrollerij;
                case "Denkt dat de kans groot is slachtoffer te worden van een beroving op straat":
                    return VeiligheidSoort.StraatBeroving;
                case "Denkt dat de kans groot is slachtoffer te worden van een inbraak in de woning":
                    return VeiligheidSoort.WoningInbraak;
                case "Is bang om slachtoffer te worden van criminaliteit":
                    return VeiligheidSoort.BangSlachtoffer;
                case "Ziet respectloos gedrag op straat plaatsvinden":
                    return VeiligheidSoort.OnbekendenStraat;
                default:
                    return VeiligheidSoort.WelEensOnveilig;
            }
        }

        public static string GetVeiligheidValueByType(Veiligheid veiligheid, VeiligheidSoort soort)
        {
            switch (soort)
            {
                case VeiligheidSoort.WelEensOnveilig:
                    return veiligheid.WelEensOnveilig;
                case VeiligheidSoort.VaakOnveilig:
                    return veiligheid.VaakOnveilig;
                case VeiligheidSoort.Zakkenrollerij:
                    return veiligheid.Zakkenrollerij;
                case VeiligheidSoort.StraatBeroving:
                    return veiligheid.StraatBeroving;
                case VeiligheidSoort.WoningInbraak:
                    return veiligheid.WoningInbraak;
                case VeiligheidSoort.BangSlachtoffer:
                    return veiligheid.BangSlachtoffer;
                case VeiligheidSoort.OnbekendenStraat:
                    return veiligheid.OnbekendenStraat;
                default:
                    return "0";
            }
        }
    }
}
