using System.Collections.Generic;
using System.Linq;
using ProjectData.Database.Entities;

namespace ProjectData.Util
{
    public class DiefstalUtil
    {
        /// <summary>
        /// Sum all the geregistreerde diefstallen and group them for every Regio.
        /// </summary>
        /// <param name="diefstalen">A list of Diefstallen.</param>
        /// <returns>A list of Diefstallen only with one Diefstal for every Regio.</returns>
        public static List<Diefstal> SumDiefstallenForeachRegio(List<Diefstal> diefstalen)
        {
            var sums = new Dictionary<string, Diefstal>();
            foreach (var diefstal in diefstalen)
            {
                var key = diefstal.RegioCode;
                if (sums.ContainsKey(key))
                {
                    var newDiefstal = diefstal;
                    var value = int.Parse(diefstal.TotaalGeregistreerdeDiefstallen);
                    var oldValue = int.Parse(sums[key].TotaalGeregistreerdeDiefstallen);

                    newDiefstal.TotaalGeregistreerdeDiefstallen = (value + oldValue).ToString();
                    sums[key] = newDiefstal;
                }
                else
                {
                    sums.Add(key, diefstal);
                }
            }

            return sums.Values.ToList();
        }
    }
}
