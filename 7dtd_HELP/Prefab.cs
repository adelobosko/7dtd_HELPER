using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _7dtd_HELP
{
    public class Prefab
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PrefabBlock> Blocks { get; set; }

        public Prefab()
        {
            Blocks = new List<PrefabBlock>();
        }

        public static List<PrefabBlock> GetPrefabBlocksByHtml(string sourceFile)
        {
            var blocks = new List<PrefabBlock>();
            var fileText = File.ReadAllText(sourceFile);
            var startTableText = "<tr><th>ID</th><th>Name</th><th>Count</th></tr>";
            var startTableIndex = fileText.IndexOf(startTableText, StringComparison.Ordinal);
            if (startTableIndex > -1)
            {
                var endTableText = "</table>";
                var endTableIndex = fileText.IndexOf(endTableText, startTableIndex + startTableText.Length, StringComparison.Ordinal);

                if (endTableIndex > -1)
                {
                    var tableText = fileText.Substring(startTableIndex + startTableText.Length,
                        endTableIndex - startTableIndex - startTableText.Length
                        )
                        .Replace(new []{"\r", "\n", " ", "<tr>", "<td>" }, "");

                    var rows = tableText.Split(new[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var row in rows)
                    {
                        var cols = row.Split(new[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);
                        if (cols.Length == 2)
                        {

                            var block = new PrefabBlock()
                            {
                                Name = cols[0],
                                Count = Convert.ToInt32(cols[1])
                            };
                            blocks.Add(block);
                        }
                    }
                }
            }

            return blocks;
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
}
