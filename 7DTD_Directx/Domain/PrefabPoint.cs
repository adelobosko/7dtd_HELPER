using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _7DTD_Directx.Domain
{
    [Table("PrefabPoints", Schema = "Map")]
    public class PrefabPoint : MapPoint
    {
        public static string DefaultName = nameof(PrefabPoint);

        public Guid PrefabPointID { get; private set; }
        public Map Map { get; private set; }
        public PrefabInfo PrefabInfo { get; private set; }


        protected PrefabPoint() : base()
        {

        }


        public PrefabPoint(Map map, PrefabInfo prefabInfo, int x, int y, int z) : base(x, y, z)
        {
            Name = DefaultName;
            PrefabPointID = Guid.NewGuid();
            Map = map;
            PrefabInfo = prefabInfo;
        }


        public PrefabPoint(Map map, string name, PrefabInfo prefabInfo, int x, int y, int z) : this(map, prefabInfo, x, y, z)
        {
            Name = name;
        }
    }
}
