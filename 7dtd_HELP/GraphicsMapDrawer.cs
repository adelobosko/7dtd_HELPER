using System.Drawing;

namespace _7dtd_HELP
{
    public class GraphicsMapDrawer : IMapDrawer
    {
        public Graphics Graphics { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }


        public void DrawMap(Map map)
        {
            DrawGrid(map);
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