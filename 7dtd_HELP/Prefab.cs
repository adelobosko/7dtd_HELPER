using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7dtd_HELP
{
    public class Prefab
    {
        public string FileName { get; set; }
        public string Name { get; set; }

        public List<PrefabBlock> Blocks { get; set; }

        public Prefab()
        {
            Blocks = new List<PrefabBlock>();
        }
    }

    public class PrefabBlock
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
