using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _7dtd_HELP
{
    public class XmlPrefabsMapLoader : IMapLoader
    {
        private readonly string _root = "prefabs";
        private readonly string _element = "decoration";

        public List<MapPoint> LoadMapPoints(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                    throw new Exception($"File \"{filename}\" does not exist.");
                var xmlDoc = XDocument.Load(filename);
                var prefabs = xmlDoc.Element(_root);
                if(prefabs == null)
                    throw new Exception($"element \"{_root}\" did not find.");


                var decorations = new List<MapPoint>();
                decorations.AddRange(prefabs.Elements(_element).Select(GetMapPoint).Where(mapPoint => mapPoint != null));

                return decorations;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
                return null;
            }
        }

        private static MapPoint GetMapPoint(XElement decoration)
        {
            try
            {
                var nameAttribute = decoration.Attribute("name");
                var positionAttribute = decoration.Attribute("position");

                if (nameAttribute == null || positionAttribute == null)
                    throw new Exception($"nameAttribute (\"{nameAttribute}\") or positionAttribute (\"{positionAttribute}\") did not find.");

                var x = int.Parse(positionAttribute.Value.Split(',')[0]);
                var y = int.Parse(positionAttribute.Value.Split(',')[2]);
                var mapPoint = new MapPoint()
                {
                    Name = nameAttribute.Value,
                    X = x,
                    Y = y
                };

                return mapPoint;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
                return null;
            }
        }
    }
}