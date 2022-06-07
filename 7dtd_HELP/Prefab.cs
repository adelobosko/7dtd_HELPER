using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _7dtd_HELP
{
    public class Prefab
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public List<PrefabBlock> Blocks { get; set; }
        public PrefabSize Size { get; set; }
        public string ImageFullPath { get; internal set; }

        public Prefab()
        {
            Blocks = new List<PrefabBlock>();
            Size = new PrefabSize();
        }

        public static List<PrefabBlock> GetPrefabBlocksByHtml(string sourceFile)
        {
            var blocks = new List<PrefabBlock>();
            var fileText = File.ReadAllText(sourceFile);
            var startTableText = "<tr><th>ID</th><th>Name</th><th>Count</th></tr>";
            var startTableIndex = fileText.IndexOf(startTableText, StringComparison.Ordinal);
            if(startTableIndex > -1)
            {
                var endTableText = "</table>";
                var endTableIndex = fileText.IndexOf(endTableText, startTableIndex + startTableText.Length, StringComparison.Ordinal);

                if(endTableIndex > -1)
                {
                    var tableText = fileText.Substring(startTableIndex + startTableText.Length,
                        endTableIndex - startTableIndex - startTableText.Length
                        )
                        .Replace(new[] { "\r", "\n", " ", "<tr>", "<td>" }, "");

                    var rows = tableText.Split(new[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach(var row in rows)
                    {
                        var cols = row.Split(new[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);
                        if(cols.Length == 3)
                        {

                            var block = new PrefabBlock()
                            {
                                Name = cols[0],
                                Count = Convert.ToInt32(cols[2])
                            };
                            blocks.Add(block);
                        }
                    }
                }
            }

            return blocks;
        }


        public static PrefabSize GetPrefabSizeByHtml(string sourceFile)
        {
            var size = new PrefabSize();
            var fileText = File.ReadAllText(sourceFile);
            var startPrefabSizeText = "<tr><th>PrefabSize</th><td>";
            var startPrefabSizeIndex = fileText.IndexOf(startPrefabSizeText, StringComparison.Ordinal);
            if(startPrefabSizeIndex > -1)
            {
                var endPrefabSizeText = "</td></tr>";
                var endPrefabSizeIndex = fileText.IndexOf(endPrefabSizeText, startPrefabSizeIndex + startPrefabSizeText.Length, StringComparison.Ordinal);

                if(endPrefabSizeIndex > -1)
                {
                    var perfabSizeText = fileText.Substring(startPrefabSizeIndex + startPrefabSizeText.Length,
                        endPrefabSizeIndex - startPrefabSizeIndex - startPrefabSizeText.Length)
                        .Replace(new[] { "\r", "\n", " ", "<tr>", "<td>" }, "");

                    var cooridnates = perfabSizeText.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    size.Width = int.Parse(cooridnates[0]);
                    size.Height = int.Parse(cooridnates[2]);
                    size.Debth = int.Parse(cooridnates[1]);
                }
            }

            return size;
        }
    }

    public static class StringExtension
    {
        public static string Replace(this string str, string[] oldValues, string newValue)
        {
            return oldValues.Aggregate(str, (current, oldValue) => current.Replace(oldValue, newValue));
        }
    }

    public class PrefabBlock
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class PrefabSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Debth { get; set; }
    }
}
