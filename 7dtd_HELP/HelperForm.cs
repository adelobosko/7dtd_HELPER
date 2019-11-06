using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Xml;
using System.Xml.Linq;
using static _7dtd_HELP.Win32;

namespace _7dtd_HELP
{
    public partial class HelperForm : Form
    {
        private GlobalKeyboardHook gHook;
        private Map map;
        private GraphicsMapDrawer graphicsMapDrawer;
        private string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public HelperForm()
        {
            InitializeComponent();
            KeyBoardHookIntialize();
            graphicsMapDrawer = new GraphicsMapDrawer(this.CreateGraphics());
            map = new Map();
            this.Paint += this.HelperForm_Paint;
            this.MouseDown += this.HelperForm_MouseDown;
            this.MouseMove += this.HelperForm_MouseMove;
            this.MouseUp += this.HelperForm_MouseUp;
        }

        private void KeyBoardHookIntialize()
        {
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += gHook_KeyDown;
            /*foreach (System.Windows.Forms.Keys key in Enum.GetValues(typeof(System.Windows.Forms.Keys)))
                gHook.HookedKeys.Add(key);*/
            gHook.HookedKeys.Add(Keys.NumPad0);
            gHook.HookedKeys.Add(Keys.NumPad1);
            gHook.HookedKeys.Add(Keys.NumPad2);
            gHook.HookedKeys.Add(Keys.NumPad3);
            //MouseHook.Start();
        }

        private byte leftMouseFlag = 0;
        private byte rightMouseFlag = 0;
        private byte delay = 1;
        private byte currentState = 0;
        private int gimmeCounter = 0;


        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (GetAsyncKeyState((int)Win32.VirtualKeyShort.MENU) == 0)
                return;


            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    leftMouseFlag++;
                    e.Handled = true;
                    break;
                case Keys.NumPad2:
                    rightMouseFlag++;
                    e.Handled = true;
                    break;
                case Keys.NumPad3:
                {
                    gimmeTimer.Enabled = !gimmeTimer.Enabled;
                    gimmeCounter = 0;
                    if (gimmeTimer.Enabled)
                    {
                        SystemSounds.Exclamation.Play();
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                    }

                    e.Handled = true;
                    break;
                }
                case Keys.NumPad0:
                {
                    Clipboard.SetText("/gimme");
                    var tKey = new List<INPUT>()
                    {
                        InputHelper.GetKeyboardInput(ScanCodeShort.KEY_T, VirtualKeyShort.KEY_T, KEYEVENTF.KEYDOWN),
                        InputHelper.GetKeyboardInput(ScanCodeShort.KEY_T, VirtualKeyShort.KEY_T, KEYEVENTF.KEYUP),
                    }.ToArray();

                    InputHelper.Send(tKey);
                    Thread.Sleep(100);
                    InputHelper.Send(InputSet.Paste);
                    InputHelper.Send(InputSet.Enter);
                    e.Handled = true;
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play();
            gHook.hook();
            openFileDialog.InitialDirectory = defaultPath;
        }


        private void HelperForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            gHook.unhook();
        }


        private void gimmeTimer_Tick(object sender, EventArgs e)
        {
            gimmeCounter++;
            int timeToGimme;
            this.Text = gimmeCounter.ToString();
            try
            {
                timeToGimme = Convert.ToInt32(gimmeToolStripTextBox.Text) * 60;
            }
            catch
            {
                return;
            }
            if (gimmeCounter < timeToGimme)
                return;
            SystemSounds.Exclamation.Play();
        }

        

        private void timerInfinity_Tick(object sender, EventArgs e)
        {
            currentState++;
            if (currentState < delay) return;

            if (leftMouseFlag % 2 != 0)
            {
                InputHelper.Send(InputSet.LeftMouseButton);
            }
            else if (rightMouseFlag % 2 != 0)
            {
                InputHelper.Send(InputSet.RightMouseButton);
                Thread.Sleep(200);
            }

            currentState = 0;
        }


        
        private bool isMove;
        private Point prevMousePosition;
        private void HelperForm_MouseDown(object sender, MouseEventArgs e)
        {
            /*
             * if (e.Button != MouseButtons.Left) return;
             * ReleaseCapture();
             * SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            */
            prevMousePosition = e.Location;
            isMove = true;
        }

        private void HelperForm_Paint(object sender, PaintEventArgs e)
        {
            graphicsMapDrawer.Graphics = e.Graphics;
            map.Draw(graphicsMapDrawer);
            

            /*foreach (var t in decorations)
            {
                foreach (ToolStripMenuItem item in perfabsToolStripMenuItem.DropDownItems)
                {
                    if (t.Name != item.Text || !item.Checked) continue;
                    var size = 2;

                    var x = x0 + t.X / map.Scale;
                    var y = y0 - t.Y / map.Scale;

                    //var x = e.Location.X - x0;
                    //var y = y0 - e.Location.Y;

                    e.Graphics.FillRectangle(Brushes.Blue, x - size, y - size, size * 2, size * 2);
                    e.Graphics.DrawString(t.Name, this.Font, Brushes.Black, x, y);
                }
            }*/

            /*foreach (var t in decorations)
            {
                if (perList.Contains(t.Name))
                {
                    var size = 2;

                    var x = x0 + t.X / map.Scale;
                    var y = y0 - t.Y / map.Scale;

                    //var x = e.Location.X - x0;
                    //var y = y0 - e.Location.Y;

                    e.Graphics.FillRectangle(Brushes.Blue, x - size, y - size, size * 2, size * 2);
                    e.Graphics.DrawString(t.Name, this.Font, Brushes.Black, x, y);
                }
            }*/
        }

        List<string> perList = new List<string>() { "business_burnt_01", "house_old_bungalow_03", "cornfield_med", "cornfield_sm", "potatofield_sm" +
            "" };
        private void HelperForm_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void HelperForm_MouseMove(object sender, MouseEventArgs e)
        {
            float x0 = map.Offset.X + Width / 2;
            float y0 = map.Offset.Y + Height / 2;

            var x = e.Location.X - x0;
            var y = y0 - e.Location.Y;
            coordinatesToolStripTextBox.Text = $"{x * map.Scale};{y * map.Scale}";

            if (!isMove) return;
            map.Offset = new Point(map.Offset.X + e.Location.X - prevMousePosition.X, map.Offset.Y + e.Location.Y - prevMousePosition.Y);
            prevMousePosition = e.Location;
            Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            scaleToolStripTextBox.TextBox.Text = mapSacleTrackBar.Value.ToString();
            this.Refresh();
        }

        private void HelperForm_SizeChanged(object sender, EventArgs e)
        {
            graphicsMapDrawer.Width = Width;
            graphicsMapDrawer.Height = Height;
            this.Refresh();
        }


        private void prefabsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            map.LoadPerfabs(openFileDialog.FileName, new XmlPerfabsMapLoader());
            this.Refresh();
            /*if (decorations.Count <= 0)
                return;

            foreach (var name in decorations.Select(d => d.Name).Distinct())
            {
                var item = new ToolStripMenuItem()
                {
                    Name = $"{name}ToolStripMenuItem",
                    Checked = false,
                    Text = name
                };
                item.Click += (o, args) =>
                {
                    item.Checked = !item.Checked;
                };
                perfabsToolStripMenuItem.DropDownItems.Add(item);
            }*/
        }

        private void spawnpointsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void scaleToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            map.Offset = new Point(0, 0);
            int mapScale = int.TryParse(scaleToolStripTextBox.Text, out mapScale) ? mapScale : 1;
            map.Scale = mapScale;
        }

        private void sizeToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            map.Offset = new Point(0, 0);
            int mapSize = int.TryParse(sizeToolStripTextBox.Text, out mapSize) ? mapSize : 3072;
            map.Scale = mapSize;
        }

        private void sizeCellToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            int cellSize = int.TryParse(sizeCellToolStripTextBox.Text, out cellSize) ? cellSize : 50;
            map.CellSize = cellSize;
        }
    }

    public interface IMapDrawer
    {
        void DrawMap(Map map);
    }

    public class GraphicsMapDrawer : IMapDrawer
    {
        public Graphics Graphics { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public void DrawMap(Map map)
        {
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
                Graphics.DrawLine(Pens.Gray,
                    x0,
                    y0 + map.CellSize * i,
                    x0 + scaledR,
                    y0 + map.CellSize * i);
                Graphics.DrawLine(Pens.Gray,
                    x0,
                    y0 - map.CellSize * i,
                    x0 + scaledR,
                    y0 - map.CellSize * i);

                Graphics.DrawLine(Pens.Gray,
                    x0 + map.CellSize * i,
                    y0,
                    x0 + map.CellSize * i,
                    y0 + scaledR);
                Graphics.DrawLine(Pens.Gray,
                    x0 + map.CellSize * i,
                    y0,
                    x0 + map.CellSize * i,
                    y0 - scaledR);



                Graphics.DrawLine(Pens.Gray,
                    x0,
                    y0 - map.CellSize * i,
                    x0 - scaledR,
                    y0 - map.CellSize * i);
                Graphics.DrawLine(Pens.Gray,
                    x0,
                    y0 + map.CellSize * i,
                    x0 - scaledR,
                    y0 + map.CellSize * i);

                Graphics.DrawLine(Pens.Gray,
                    x0 - map.CellSize * i,
                    y0,
                    x0 - map.CellSize * i,
                    y0 - scaledR);
                Graphics.DrawLine(Pens.Gray,
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

    public class Map
    {
        public int CellSize { get; set; }
        public int Size {get; set; }
        public int Scale { get; set; }
        public Point Offset { get; set; }
        public Dictionary<string,List<MapPoint>> MapCollection { get; }
        public List<MapPoint> Perfabs { get; }
        public Map(int size = 3072, int sclae = 10, int cellSize = 50)
        {
            Size = size;
            Scale = sclae;
            CellSize = cellSize;
            MapCollection = new Dictionary<string, List<MapPoint>>();
            Perfabs = new List<MapPoint>();
        }

        public void LoadPerfabs(string filename, IMapLoader mapLoader)
        {
            Perfabs.Clear();
            var mapPoints = mapLoader.LoadMapPoints(filename);
            if(mapPoints == null)
                return;

            Perfabs.AddRange(mapPoints);
        }

        public void Draw(IMapDrawer mapDrawer)
        {
            mapDrawer.DrawMap(this);
        }
    }
}
