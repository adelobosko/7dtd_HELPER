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
                var rotationAttribute = decoration.Attribute("rotation");

                if (nameAttribute == null || positionAttribute == null || rotationAttribute == null)
                    throw new Exception($"nameAttribute or positionAttribute or rotationAttribute could not find.");

                var positionSplit = positionAttribute.Value.Split(',');
                var positionX = int.Parse(positionSplit[0]);
                var positionY = int.Parse(positionSplit[2]);

                var roration = int.Parse(rotationAttribute.Value);

                var mapPoint = new MapPoint()
                {
                    Name = nameAttribute.Value,
                    X = positionX,
                    Y = positionY,
                    Rotation = roration
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