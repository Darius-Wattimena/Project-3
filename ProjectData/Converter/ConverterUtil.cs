using ProjectData.Database.Daos;
using ProjectData.Database.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ProjectData.Util;

namespace ProjectData.Converter
{
    public class ConverterUtil
    {
        public static IEnumerable<string> ReadLines(Func<Stream> streamProvider, Encoding encoding)
        {
            using (var stream = streamProvider())
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public static void ConvertDiefstal()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("ProjectData.Resources.Dataset_Diefstallen.csv");

            var lines = ReadLines(() => stream, Encoding.UTF8).ToList().Select(a => a.Split(';'));
            var linesList = lines.ToList();

            ReadDataDiefstal(linesList);
        }

        public static void ConvertRegio()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("ProjectData.Resources.Metadata.csv");

            //var lines = File.ReadAllLines("../../Resource/Dataset/83651NED_metadata.csv").Select(a => a.Split(';'));
            var lines = ReadLines(() => stream, Encoding.UTF8).ToList().Select(a => a.Split(';'));
            var linesList = lines.ToList();

            linesList = RemoveUnneededLines(lines, linesList);
            lines = linesList.ToArray();

            var replacableDirectory = FindAllReplacableLines(linesList);

            linesList = ReplaceLines(lines, linesList, replacableDirectory);
            ReadDataRegio(linesList);
        }

        private static List<string[]> RemoveUnneededLines(IEnumerable<string[]> lines, List<string[]> linesList)
        {
            var i = 0;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line[0]))
                {
                    linesList.RemoveAt(i);
                    i--;
                }
                i++;
            }

            return linesList;
        }

        private static Dictionary<int, string[]> FindAllReplacableLines(List<string[]> lines)
        {
            var i = 0;
            var replacableDirectory = new Dictionary<int, string[]>();

            foreach (var line in lines)
            {
                if (!line[0].StartsWith("\""))
                {
                    replacableDirectory.Add(i, line);
                }
                i++;
            }

            return replacableDirectory;
        }

        private static List<string[]> ReplaceLines(IEnumerable<string[]> lines, List<string[]> linesList, Dictionary<int, string[]> replacableDirectory)
        {
            var i = lines.Count();

            foreach (var line in lines.Reverse())
            {
                if (replacableDirectory.ContainsKey(i))
                {
                    var items = replacableDirectory[i];
                    var previousItems = linesList[i - 1];

                    var lastItem = previousItems.Length - 1;
                    var newItem = previousItems[lastItem] + " " + items[0];

                    previousItems[lastItem] = newItem;
                    var previousItemsList = previousItems.ToList();

                    var newTotalItems = lastItem + items.Count() - 1;

                    for (var j = lastItem; j < newTotalItems; j++)
                    {
                        var itemIndex = j - lastItem + 1;
                        previousItemsList.Add(items[itemIndex]);
                    }

                    linesList.RemoveAt(i);
                    linesList.RemoveAt(i - 1);
                    linesList.Insert(i - 1, previousItemsList.ToArray());
                }
                i--;
            }

            return linesList;
        }

        private static void ReadDataDiefstal(List<string[]> linesList)
        {
            var dao = new DiefstalDao();
            var i = 0;
            foreach (var line in linesList)
            {
                if (i >= 1)
                {
                    var lineArray = line.ToArray();
                    var GDPer1000Inw = lineArray[7].Replace("\"", string.Empty);
                    var ODRelatief = lineArray[9].Replace("\"", string.Empty);

                    var diefstal = new Diefstal
                    {
                        GebruikVanGeweld = lineArray[1].Replace("\"", string.Empty),
                        SoortDiefstal = lineArray[2].Replace("\"", string.Empty),
                        RegioCode = lineArray[3].Replace("\"", string.Empty),
                        Perioden = lineArray[4].Replace("\"", string.Empty),
                        TotaalGeregistreerdeDiefstallen = lineArray[5].Replace("\"", string.Empty),
                        GeregistreerdeDiefstallenRelatief = lineArray[6].Replace("\"", string.Empty),
                        TotaalOpgehelderdeDiefstallen = lineArray[8].Replace("\"", string.Empty),
                        RegistratiesVanVerdachten = lineArray[10].Replace("\"", string.Empty)
                    };

                    diefstal.GeregistreerdeDiefstallenPer1000Inw = !string.IsNullOrEmpty(GDPer1000Inw) && GDPer1000Inw.Any(char.IsDigit) ? decimal.Parse(GDPer1000Inw) : decimal.Zero;
                    diefstal.OpgehelderdeDiefstallenRelatief = !string.IsNullOrEmpty(ODRelatief) && GDPer1000Inw.Any(char.IsDigit) ? decimal.Parse(ODRelatief) : decimal.Zero;

                    dao.Save(diefstal);
                }
                i++;
            }
        }

        private static void ReadDataRegio(List<string[]> linesList)
        {

            var dao = new RegioDao();
            var i = 0;
            foreach (var line in linesList)
            {
                if (i >= 51 && i <= 526)
                {
                    var lineArray = line.ToArray();
                    Regio regio = new Regio
                    {
                        Code = lineArray[0].Replace("\"", string.Empty),
                        Name = lineArray[1].Replace("\"", string.Empty).Replace("\'", string.Empty),
                        Description = lineArray[2].Replace("\"", string.Empty)
                    };
                    dao.Save(regio);
                }
                i++;
            }
        }
    }
}
