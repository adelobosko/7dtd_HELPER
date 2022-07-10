using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _7DTD_Directx.Domain
{
    [Table("SpawnPoints", Schema = "Map")]
    public class SpawnPoint : MapPoint
    {
        public static string DefaultName = nameof(SpawnPoint);

        public Guid SpawnPointID { get; private set; }
        public Map Map { get; private set; }


        protected SpawnPoint() : base()
        {

        }


        public SpawnPoint(Map map, int x, int y, int z) : base(x, y, z)
        {
            SpawnPointID = Guid.NewGuid();
            Map = map;
            Name = DefaultName;
        }


        public SpawnPoint(Map map, string name, int x, int y, int z) : this(map, x, y, z)
        {
            Name = name;
        }
    }
}
