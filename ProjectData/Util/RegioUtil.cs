using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectData.Database.Entities;

namespace ProjectData.Util
{
    public class RegioUtil
    {
        /// <summary>
        /// Get a regio name from the given regio code.
        /// </summary>
        /// <param name="code">A string value of an Regio code.</param>
        /// <returns>An readable name of the regio.</returns>
        public static string GetRegioName(string code)
        {
            var regioCode = EnumUtil.GetEnumFormDescription<RegioCode>(code.Replace(" ", string.Empty));
            return GetRegioName(regioCode);
        }

        public static string GetRegioName(RegioCode code)
        {
            switch (code)
            {
                case RegioCode.Groningen:
                    return "Groningen";
                case RegioCode.Friesland:
                    return "Friesland";
                case RegioCode.Drenthe:
                    return "Drenthe";
                case RegioCode.Overijssel:
                    return "Overijssel";
                case RegioCode.Flevoland:
                    return "Flevoland";
                case RegioCode.Gelderland:
                    return "Gelderland";
                case RegioCode.Utrecht:
                    return "Utrecht";
                case RegioCode.NoordHolland:
                    return "Noord-Holland";
                case RegioCode.ZuidHolland:
                    return "Zuid-Holland";
                case RegioCode.Zeeland:
                    return "Zeeland";
                case RegioCode.NoordBrabant:
                    return "Noord-Brabant";
                case RegioCode.Limburg:
                    return "Limburg";
                case RegioCode.NietInTeDelen:
                    return "Niet in te delen";
                default:
                    throw new ArgumentOutOfRangeException(nameof(code), code, null);
            }
        }
    }
}
