﻿using ProjectData.Database.Daos;
using ProjectData.Database.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Globalization;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ProjectData.Converter
{
    public class ConverterUtil
    {
        public static string[] _items;

        public static void SetItems(string[] items)
        {
            _items = items;
        }

        public static string GetItem(int i)
        {
            return _items[i].Replace("\"", string.Empty);
        }

        public static decimal GetDecimal(string value)
        {
            return !string.IsNullOrEmpty(value) && value.Any(char.IsDigit) ? Convert.ToDecimal(value, new CultureInfo("en-US")) : decimal.Zero;
        }

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

        public static void ConvertGemiddeldInkomen()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("ProjectData.Resources.Gemiddeld_Inkomen.csv");

            var lines = ReadLines(() => stream, Encoding.UTF8).ToList().Select(a => a.Split(';'));
            var linesList = lines.ToList();
            ReadDataGemiddeldInkomen(linesList);
        }

        public static void ConvertDiefstal()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("ProjectData.Resources.Dataset_Diefstallen.csv");

            var lines = ReadLines(() => stream, Encoding.UTF8).ToList().Select(a => a.Split(';'));
            var linesList = lines.ToList();

            ReadDataDiefstal(linesList);
        }

        public static void ConvertPreventie()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var iets = assembly.GetManifestResourceNames();
            foreach (string str in iets) {
                Debug.Write(str);
            }
            var stream = assembly.GetManifestResourceStream("ProjectData.Resources.preventie.csv");

            var lines = ReadLines(() => stream, Encoding.UTF8).ToList().Select(a => a.Split(';'));
            var linesList = lines.ToList();

            ReadDataPreventie(linesList);
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

        private static void ReadDataGemiddeldInkomen(List<string[]> linesList)
        {
            var dao = new GemiddeldInkomenDao();
            var i = 0;
            foreach (var line in linesList)
            {
                if (i >= 1)
                {
                    var lineArray = line.ToArray();
                    SetItems(lineArray);

                    var inkomen = new GemiddeldInkomen
                    {
                        RegioCode = GetItem(1),
                        Perioden = GetItem(2),
                        AantalPersonen = GetDecimal(GetItem(3)),
                        GemiddeldBesteedbaarInkomen = GetDecimal(GetItem(4)),
                        RangnummerBesteedbaarInkomen = int.Parse(GetItem(5)),
                        GemiddeldGestandaardiseerdInkomen = GetDecimal(GetItem(6)),
                        RangnummerGestandaardiseerdInkomen = int.Parse(GetItem(7)),
                        AantalPersonen_2 = GetDecimal(GetItem(8)),
                        InVanPersonenMetEnZonderInkomen = int.Parse(GetItem(9)),
                        GemiddeldPersoonlijkInkomen = GetDecimal(GetItem(10)),
                        RangnummerPersoonlijkInkomen = int.Parse(GetItem(11)),
                        GemiddeldBesteedbaarInkomen_2 = GetDecimal(GetItem(12)),
                        RangnummerBesteedbaarInkomen_2 = int.Parse(GetItem(13))
                    };

                    dao.Save(inkomen);
                }
            }
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
                    SetItems(lineArray);

                    var diefstal = new Diefstal
                    {
                        GebruikVanGeweld = GetItem(1),
                        SoortDiefstal = GetItem(2),
                        RegioCode = GetItem(3),
                        Perioden = GetItem(4),
                        TotaalGeregistreerdeDiefstallen = GetItem(5),
                        GeregistreerdeDiefstallenRelatief = GetItem(6),
                        GeregistreerdeDiefstallenPer1000Inw = GetDecimal(GetItem(7)),
                        TotaalOpgehelderdeDiefstallen = GetItem(8),
                        OpgehelderdeDiefstallenRelatief = GetDecimal(GetItem(9)),
                        RegistratiesVanVerdachten = GetItem(10)
                    };

                    dao.Save(diefstal);
                }
                i++;
            }
        }

        private static void ReadDataPreventie(List<string[]> linesList) {
            var dao = new PreventieDao();
            var i = 0;
            foreach (var line in linesList)
            {
                if (i >= 1)
                {
                    var lineArray = line.ToArray();
                    var LichtAf = lineArray[4].Replace("\"", string.Empty);
                    var FietsStal = lineArray[5].Replace("\"", string.Empty);
                    var SpullenAuto = lineArray[6].Replace("\"", string.Empty);
                    var SpullenThuis = lineArray[7].Replace("\"", string.Empty);
                    var SociaalPrev = lineArray[8].Replace("\"", string.Empty);
                    var ExtraSloten = lineArray[9].Replace("\"", string.Empty);
                    var Rolluiken = lineArray[10].Replace("\"", string.Empty);
                    var Buitenverlichting = lineArray[11].Replace("\"", string.Empty);
                    var Alarm = lineArray[12].Replace("\"", string.Empty);
                    var PreventieSom = lineArray[13].Replace("\"", string.Empty);

                    var preventie = new Preventie
                    {
                        RegioCode = lineArray[2].Replace("\"", string.Empty),
                        Perioden = lineArray[3].Replace("\"", string.Empty),
                        
                    };

                    preventie.LichtBijAfwezigheid = !string.IsNullOrEmpty(LichtAf) && LichtAf.Any(char.IsDigit) ? decimal.Parse(LichtAf) : decimal.Zero;
                    preventie.FietsInStalling = !string.IsNullOrEmpty(FietsStal) && FietsStal.Any(char.IsDigit) ? decimal.Parse(FietsStal) : decimal.Zero;
                    preventie.SpullenUitAuto = !string.IsNullOrEmpty(SpullenAuto) && SpullenAuto.Any(char.IsDigit) ? decimal.Parse(SpullenAuto) : decimal.Zero;
                    preventie.SpullenThuisLaten = !string.IsNullOrEmpty(SpullenThuis) && SpullenThuis.Any(char.IsDigit) ? decimal.Parse(SpullenThuis) : decimal.Zero;
                    preventie.SociaalPreventiefGedragscore = !string.IsNullOrEmpty(SociaalPrev) && SociaalPrev.Any(char.IsDigit) ? decimal.Parse(SociaalPrev) : decimal.Zero;
                    preventie.ExtraSlotenDeur = !string.IsNullOrEmpty(ExtraSloten) && ExtraSloten.Any(char.IsDigit) ? decimal.Parse(ExtraSloten) : decimal.Zero;
                    preventie.Rolluiken = !string.IsNullOrEmpty(Rolluiken) && Rolluiken.Any(char.IsDigit) ? decimal.Parse(Rolluiken) : decimal.Zero;
                    preventie.Buitenverlichting = !string.IsNullOrEmpty(Buitenverlichting) && Buitenverlichting.Any(char.IsDigit) ? decimal.Parse(Buitenverlichting) : decimal.Zero;
                    preventie.Alarm = !string.IsNullOrEmpty(Alarm) && Alarm.Any(char.IsDigit) ? decimal.Parse(Alarm) : decimal.Zero;
                    preventie.PreventieSomscore = !string.IsNullOrEmpty(PreventieSom) && PreventieSom.Any(char.IsDigit) ? decimal.Parse(PreventieSom) : decimal.Zero;
                    // , CultureInfo.InvariantCulture Debug.Write(preventie.LichtBijAfwezigheid);
                    dao.Save(preventie);
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
