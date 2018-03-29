using System.Collections.Generic;
using System.Linq;
using ProjectData.Database.Entities;

namespace ProjectData.Util
{
    public class GemiddeldInkomenUtil
    {
        public static List<GemiddeldInkomen> SumDiefstallenForeachRegio(List<GemiddeldInkomen> inkomens)
        {
            var sums = new Dictionary<string, GemiddeldInkomen>();
            foreach (var inkomen in inkomens)
            {
                var key = inkomen.RegioCode;
                if (sums.ContainsKey(key))
                {
                    var newInkomen = inkomen;
                    var value = inkomen.GemiddeldBesteedbaarInkomen;
                    var oldValue = sums[key].GemiddeldBesteedbaarInkomen;

                    newInkomen.GemiddeldBesteedbaarInkomen = value + oldValue;
                    sums[key] = newInkomen;
                }
                else
                {
                    sums.Add(key, inkomen);
                }
            }

            return sums.Values.ToList();
        }
    }
}
