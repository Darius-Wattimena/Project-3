using ProjectData.Database.Daos;
using ProjectData.Database.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectData.Converter
{
    public class RegioConverter
    {
        public static void Convert()
        {
            var lines = File.ReadAllLines("../../Resource/Dataset/83651NED_metadata.csv").Select(a => a.Split(';'));
            var csv = from line in lines
                      select (from piece in line
                              select piece);
            var linesList = lines.ToList();
            var i = 0;
            RegioDao dao = new RegioDao();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line[0]))
                {
                    linesList.RemoveAt(i);
                    i--;
                }
                i++;
            }

            i = 0;
            lines = linesList.ToArray();

            var replacableDirectory = new Dictionary<int, string[]>();

            //Als de string niet begint met \" voeg hem dan toe aan de vorige

            foreach (var line in lines)
            {
                if (!line[0].StartsWith("\""))
                {
                    replacableDirectory.Add(i, line);
                }
                i++;
            }

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

            foreach (var line in linesList)
            {
                if (i >= 52 && i <= 527)
                {
                    var lineArray = line.ToArray();
                    Regio regio = new Regio
                    {
                        Code = lineArray[0],
                        Name = lineArray[1],
                        Description = lineArray[2]
                    };
                    dao.Save(regio);
                }
                i++;
            }
        }
    }
}
