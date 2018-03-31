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
                default:
                    return "0";
            }
        }
    }
}
