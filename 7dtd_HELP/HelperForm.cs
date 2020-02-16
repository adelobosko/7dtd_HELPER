using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static _7dtd_HELP.Win32;

namespace _7dtd_HELP
{
    public partial class HelperForm : Form
    {
        private GlobalKeyboardHook gHook;
        // git kui/7dtd-map
        private Map map;
        private Config config;
        private GraphicsMapDrawer graphicsMapDrawer;
        private string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public HelperForm()
        {
            InitializeComponent();
            KeyBoardHookInitialize();
            graphicsMapDrawer = new GraphicsMapDrawer(this.CreateGraphics());
            GlobalHelper.WebHelper = new WebHelper("");
            GlobalHelper.UpdateStatus = OnStatusChanged;
            map = new Map();
            this.Paint += this.HelperForm_Paint;
            this.MouseDown += this.HelperForm_MouseDown;
            this.MouseMove += this.HelperForm_MouseMove;
            this.MouseUp += this.HelperForm_MouseUp;

            this.MouseWheel += new MouseEventHandler(helperForm_MouseWheel);

        }

        public void OnStatusChanged(object sender, string message, int percentage)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    this.statusToolStripStatusLabel.Text = message;
                    this.statusToolStripProgressBar.Value = percentage;
                }));
            }
            catch
            {
            }
        }

        public void helperForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (mapSacleTrackBar.Value == mapSacleTrackBar.Maximum)
                    return;

                mapSacleTrackBar.Value = ++mapSacleTrackBar.Value;
            }
            else
            {
                if (mapSacleTrackBar.Value == mapSacleTrackBar.Minimum)
                    return;

                mapSacleTrackBar.Value = --mapSacleTrackBar.Value;
            }
        }

        private void KeyBoardHookInitialize()
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
                    atouseGimmeToolStripMenuItem.Checked = gimmeTimer.Enabled;
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

            if (graphicsMapDrawer != null)
            {
                graphicsMapDrawer.Width = Width;
                graphicsMapDrawer.Height = Height;
                this.Refresh();
            }

            LoadConfig();
            // TODO: make that easily
            map.AllowedDecorations.Clear();
            foreach (ToolStripMenuItem item in prefabsToolStripMenuItem.DropDownItems)
            {
                map.AllowedDecorations.Add(new ConfiguredDecoration()
                {
                    Name = item.Text,
                    Enabled = item.Checked
                });
            }
        }

        private void LoadConfig()
        {
            if (!Directory.Exists(GlobalHelper.Paths.ConfigFolder))
            {
                Directory.CreateDirectory(GlobalHelper.Paths.ConfigFolder);
            }

            if (!File.Exists(GlobalHelper.Paths.ConfigFile))
            {
                config = new Config();
            }

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
                timeToGimme = Convert.ToInt32(gimmeDelayToolStripTextBox.Text) * 60;
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
            prevMousePosition = e.Location;
            isMove = true;
        }

        private void HelperForm_Paint(object sender, PaintEventArgs e)
        {
            graphicsMapDrawer.Graphics = e.Graphics;
            map.Draw(graphicsMapDrawer);
        }

        
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

        private void HelperForm_SizeChanged(object sender, EventArgs e)
        {
            if(graphicsMapDrawer == null)
                return;
            
            graphicsMapDrawer.Width = Width;
            graphicsMapDrawer.Height = Height;
            this.Refresh();
        }


        private void prefabsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            map.LoadPrefabs(openFileDialog.FileName, new XmlPrefabsMapLoader());
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
                prefabsToolStripMenuItem.DropDownItems.Add(item);
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

        private void mapSacleTrackBar_ValueChanged(object sender, EventArgs e)
        {
            scaleToolStripTextBox.Text = mapSacleTrackBar.Value.ToString();
            this.Refresh();
        }

        private void prefabsChangedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.AllowedDecorations.Clear();
            foreach (ToolStripMenuItem item in prefabsToolStripMenuItem.DropDownItems)
            {
                map.AllowedDecorations.Add(new ConfiguredDecoration()
                {
                    Name = item.Text,
                    Enabled = item.Checked
                });
            }
        }

        private void updatePrefabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                config.PrefabsConfig.UpdatePrefabs();
            }).Start();
        }
    }
}
