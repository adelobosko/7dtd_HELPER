using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace _7dtd_HELP
{
    public class GraphicsMapDrawer : IMapDrawer
    {
        public Graphics Graphics { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }


        public void DrawMap(Map map)
        {
            if (map == null)
            {
                return;
            }
            DrawBiomes(map);
            DrawGrid(map);
            DrawPrefabs(map);
            DrawCollections(map);
        }

        private void DrawBiomes(Map map)
        {
            if (!map.IsBiomesShown)
            {
                return;
            }

            var width = map.Size / map.Scale * 2;
            var height = map.Size / map.Scale * 2;
            var bitmap = map.GetBiomes(width, height);
            if (bitmap == null)
            {
                return;
            }

            var scaledR = (map.Size / map.Scale);
            int x0 = map.Offset.X + Width / 2;
            int y0 = map.Offset.Y + Height / 2;
            Graphics.DrawImage(bitmap, new Point(x0 - scaledR, y0 - scaledR));
        }

        private void DrawCollections(Map map)
        {
            var size = 2;
            float x0 = map.Offset.X + Width / 2;
            float y0 = map.Offset.Y + Height / 2;

            var paintedCollections = map.MapObjects.Where(mo => mo.IsEnabled);
            foreach (var collection in paintedCollections)
            {
                foreach (var mapPoint in collection.MapPoints)
                {
                    var x = x0 + (float)mapPoint.X / map.Scale;
                    var y = y0 - (float)mapPoint.Y / map.Scale;
                    Graphics.FillRectangle(Brushes.Red, x - size, y - size, size * 2, size * 2);
                }
            }

        }

        private void DrawPrefabs(Map map)
        {
            var allowedGroups = GlobalHelper.Config.DecorationGroups.Where(g => g.IsEnabled).ToList();

            foreach (var prefab in map.Prefabs)
            {
                var firstGroup = allowedGroups.FirstOrDefault(g => g.Prefabs.Count(p => p.Name == prefab.Name) > 0);

                if (firstGroup == null)
                    continue;

                var font = new Font("Courier New", 14);
                var size = 2;
                float x0 = map.Offset.X + Width / 2;
                float y0 = map.Offset.Y + Height / 2;

                var x = x0 + (float)prefab.X / map.Scale;
                var y = y0 - (float)prefab.Y / map.Scale;

                if (firstGroup.Icon == null)
                {
                    Graphics.FillRectangle(Brushes.Blue, x - size, y - size, size * 2, size * 2);
                }
                else
                {
                    if (firstGroup.Icon.Width == -1 && firstGroup.Icon.Height == -1)
                    {
                        Graphics.DrawImage(
                            firstGroup.Icon.GetBitmapByFile(), 
                            new Point(
                                (int)x - firstGroup.Icon.GetBitmapByFile().Width / 2, 
                                (int)y - firstGroup.Icon.GetBitmapByFile().Height / 2
                                )
                            );
                    }
                    else
                    {
                        var image = firstGroup.Icon.GetBitmapByFile().ResizeImage(firstGroup.Icon.Width, firstGroup.Icon.Height);
                        Graphics.DrawImage(image,
                            new Point(
                                (int)x - image.Width / 2,
                                (int)y - image.Height / 2
                            )
                        );
                    }
                }
            }
        }

        private void DrawGrid(Map map)
        {
            var gridColor = Pens.Gray;
            var scaledR = (map.Size / map.Scale);
            var rowsAndColumns = (map.Size / map.Scale) / map.CellSize;
            float x0 = map.Offset.X + Width / 2;
            float y0 = map.Offset.Y + Height / 2;

            Graphics.FillRectangle(Brushes.Black, x0 - 4, y0 - 4, 8, 8);
            Graphics.DrawRectangle(Pens.Red,
                x0 - scaledR,
                y0 - scaledR,
                scaledR * 2,
                scaledR * 2);

            for (var i = 0; i < rowsAndColumns; i++)
            {
                Graphics.DrawLine(gridColor,
                    x0,
                    y0 + map.CellSize * i,
                    x0 + scaledR,
                    y0 + map.CellSize * i);
                Graphics.DrawLine(gridColor,
                    x0,
                    y0 - map.CellSize * i,
                    x0 + scaledR,
                            y0 - map.CellSize * i);

                Graphics.DrawLine(gridColor,
                    x0 + map.CellSize * i,
                    y0,
                    x0 + map.CellSize * i,
                    y0 + scaledR);
                Graphics.DrawLine(gridColor,
                    x0 + map.CellSize * i,
                    y0,
                    x0 + map.CellSize * i,
                    y0 - scaledR);



                Graphics.DrawLine(gridColor,
                    x0,
                    y0 - map.CellSize * i,
                    x0 - scaledR,
                    y0 - map.CellSize * i);
                Graphics.DrawLine(gridColor,
                    x0,
                    y0 + map.CellSize * i,
                    x0 - scaledR,
                            y0 + map.CellSize * i);

                Graphics.DrawLine(gridColor,
                    x0 - map.CellSize * i,
                    y0,
                    x0 - map.CellSize * i,
                    y0 - scaledR);
                Graphics.DrawLine(gridColor,
                    x0 - map.CellSize * i,
                    y0,
                    x0 - map.CellSize * i,
                    y0 + scaledR);
            }
        }

        public GraphicsMapDrawer(Graphics graphics)
        {
            Graphics = graphics;
        }
    }
}