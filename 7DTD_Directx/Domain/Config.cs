using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _7DTD_Directx.Domain
{
    [Table("Configs", Schema = "Config")]
    public class Config
    {
        public Guid ConfigID { get; private set; }
        public Map? CurrentMap { get; set; }

        [NotMapped]
        public List<Map> AvailableMaps { get; set; }

        //public List<DecorationGroup> DecorationGroups { get; set; }
        //public PrefabsConfig PrefabsConfig { get; set; }
        //public Rectangle CoordinatesRectangle { get; set; }
        //public Point CurrentMapCenterGameCoordinates { get; set; }


        public Config()
        {
            ConfigID = Guid.NewGuid();
            AvailableMaps = new List<Map>();
        }
    }
}
