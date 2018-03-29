using System.Collections.Generic;
using System.Linq;
using ProjectData.Database.Entities;

namespace ProjectData.Util
{
    public class GemiddeldInkomenUtil
    {
        /// <summary>
        /// Get the average of the GemiddeldInkomen grouped by each Regio.
        /// </summary>
        /// <param name="inkomens">A list of GemiddeldInkomens.</param>
        /// <returns>A list of GemiddeldInkomens only with one GemiddeldInkomen for every regio.</returns>
        public static List<GemiddeldInkomen> ParInkomenForeachRegio(List<GemiddeldInkomen> inkomens)
        {
            var sums = new Dictionary<string, GemiddeldInkomen>();
            foreach (var inkomen in inkomens)
            {
                var key = inkomen.RegioCode;
                if (sums.ContainsKey(key))
                {
                    var newInkomen = inkomen;
                    var value = inkomen.GemiddeldPersoonlijkInkomen;
                    var oldValue = sums[key].GemiddeldPersoonlijkInkomen;

                    newInkomen.GemiddeldPersoonlijkInkomen = (value + oldValue) / 2;
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
