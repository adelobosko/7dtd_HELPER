using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _7DTD_Directx.Domain
{
    [Table("PrefabsInfo", Schema = "Prefab")]
    public class PrefabInfo
    {
        public Guid PrefabInfoID { get; private set; }
        public string Name { get; private set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public int Debth { get; set; }
        //public string? ImageFullPath { get; internal set; }

        public List<AvailablePrefabBlock> AvaliableBlocks { get; set; }


        public PrefabInfo(string name, int width, int height, int debth)
        {
            PrefabInfoID = Guid.NewGuid();
            Name = name;
            Width = width;
            Height = height;
            Debth = debth;
            AvaliableBlocks = new List<AvailablePrefabBlock>();
        }
    }
}
