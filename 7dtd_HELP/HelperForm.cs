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
        private readonly GraphicsMapDrawer graphicsMapDrawer;
        private List<ToolStripMenuItem> groupStripMenuItems;

        public HelperForm()
        {
            InitializeComponent();
            KeyBoardHookInitialize();
            graphicsMapDrawer = new GraphicsMapDrawer(this.CreateGraphics());
            GlobalHelper.WebHelper = new WebHelper("");
            GlobalHelper.UpdateStatus = OnStatusChanged;
            GlobalHelper.UpdateSubStatus = OnSubStatusChanged;
            groupStripMenuItems = new List<ToolStripMenuItem>();
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
                    Console.WriteLine($"{message} {percentage}%");
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void OnSubStatusChanged(object sender, string message, int percentage)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    this.subStatusToolStripStatusLabel.Text = message;
                    this.subStatusToolStripProgressBar.Value = percentage;
                    Console.WriteLine($"{message} {percentage}%");
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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

            if (graphicsMapDrawer != null)
            {
                graphicsMapDrawer.Width = Width;
                graphicsMapDrawer.Height = Height;
                this.Refresh();
            }

            GlobalHelper.Config = Config.Load(GlobalHelper.Config);

            foreach (var name in GlobalHelper.Config.Maps)
            {
                if (name == Map.DefaultName)
                {
                    continue;
                }
                var item = new ToolStripMenuItem()
                {
                    Name = $"{name}ToolStripMenuItem",
                    Checked = false,
                    Text = name
                };
                item.Click += (o, args) =>
                {
                    Map.Load(name);
                    UpdateUI();
                };
                loadToolStripMenuItem.DropDownItems.Add(item);
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            var spawnPoints = GlobalHelper.Config.Map.MapObjects.SingleOrDefault(mo =>
                string.Equals(mo.Name, "spawnPoints", StringComparison.CurrentCultureIgnoreCase));
            if (spawnPoints == null)
            {
                spawnPointsToolStripMenuItem.Visible = false;
            }
            else
            {
                spawnPointsToolStripMenuItem.Visible = true;
                spawnPointsToolStripMenuItem.Checked = spawnPoints.IsEnabled;
            }

            this.Text = $@"{GlobalHelper.Config.Map.Name} - {GlobalHelper.Config.Map.Ip}:{GlobalHelper.Config.Map.Port}";

            sizeCellToolStripTextBox.Text = GlobalHelper.Config.Map.CellSize.ToString();
            scaleToolStripTextBox.Text = GlobalHelper.Config.Map.Scale.ToString();
            sizeToolStripTextBox.Text = GlobalHelper.Config.Map.Size.ToString();

            foreach (var groupStripMenuItem in groupStripMenuItems)
            {
                if (groupsToolStripMenuItem.DropDownItems.Contains(groupStripMenuItem))
                {
                    groupsToolStripMenuItem.DropDownItems.Remove(groupStripMenuItem);
                    groupStripMenuItem.Dispose();
                }
            }

            groupStripMenuItems.Clear();

            foreach (var group in GlobalHelper.Config.DecorationGroups)
            {
                var item = new ToolStripMenuItem()
                {
                    Name = $"{group.Name}ToolStripMenuItem",
                    Checked = group.IsEnabled,
                    Text = group.Name
                };
                item.Click += (o, args) =>
                {
                    group.IsEnabled = !group.IsEnabled;
                    item.Checked = group.IsEnabled;
                };

                var groupEdit = new ToolStripMenuItem()
                {
                    Name = $"{group.Name}EditToolStripMenuItem",
                    Checked = false,
                    Text = "Edit"
                };
                groupEdit.Click += (o, args) =>
                {
                    var groupPrefab = new GroupPrefabs();
                    groupPrefab.Result = new DecorationGroup()
                    {
                        Name = group.Name,
                        Prefabs = group.Prefabs,
                        Icon = group.Icon,
                        IsEnabled = group.IsEnabled
                    };

                    if (groupPrefab.ShowDialog(this) == DialogResult.OK)
                    {
                        var decorationGroup = groupPrefab.Result;

                        var twin = GlobalHelper.Config.DecorationGroups.SingleOrDefault(dg =>
                            string.Equals(dg.Name, decorationGroup.Name, StringComparison.CurrentCultureIgnoreCase));

                        if (twin != null)
                        {
                            if (group.Name == twin.Name)
                            {
                                GlobalHelper.Config.DecorationGroups.Remove(twin);
                            }
                            else
                            {
                                decorationGroup.Name += "_Twin";
                                MessageBox.Show(
                                    $"{twin.Name} has already exist. Name is changed to {decorationGroup.Name}");
                            }
                        }
                        GlobalHelper.Config.DecorationGroups.Add(decorationGroup);
                    }
                    groupPrefab.Dispose();

                    GlobalHelper.Config.Save();
                    UpdateUI();
                };

                item.DropDownItems.Add(groupEdit);

                var groupDelete = new ToolStripMenuItem()
                {
                    Name = $"{group.Name}DeleteToolStripMenuItem",
                    Checked = false,
                    Text = "Delete"
                };
                groupDelete.Click += (o, args) =>
                {
                    var twin = GlobalHelper.Config.DecorationGroups.SingleOrDefault(dg =>
                            string.Equals(dg.Name, group.Name, StringComparison.CurrentCultureIgnoreCase));

                    if (twin == null) return;

                    GlobalHelper.Config.DecorationGroups.Remove(twin);
                    GlobalHelper.Config.Save();
                    UpdateUI();
                };

                item.DropDownItems.Add(groupDelete);

                groupStripMenuItems.Add(item);
                groupsToolStripMenuItem.DropDownItems.Add(item);
            }

            this.Refresh();
            Invalidate();
        }


        private void HelperForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalHelper.Config.Save();
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
            if (GlobalHelper.Config?.Map != null)
            {
                GlobalHelper.Config.Map.Draw(graphicsMapDrawer);
            }
        }


        private void HelperForm_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void HelperForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (GlobalHelper.Config?.Map == null)
            {
                return;
            }

            float x0 = GlobalHelper.Config.Map.Offset.X + Width / 2;
            float y0 = GlobalHelper.Config.Map.Offset.Y + Height / 2;

            var x = e.Location.X - x0;
            var y = y0 - e.Location.Y;

            var xCoord = x * GlobalHelper.Config.Map.Scale;
            var yCoord = y * GlobalHelper.Config.Map.Scale;
            var xCoord7dtd = xCoord < 0 ? $"{Math.Abs(xCoord)}W" : $"{Math.Abs(xCoord)}E";
            var yCoord7dtd = yCoord < 0 ? $"{Math.Abs(yCoord)}S" : $"{Math.Abs(yCoord)}N";
            coordinatesToolStripTextBox.Text = $"{xCoord};{yCoord}";
            coordinates7dtdToolStripTextBox.Text = $"{xCoord7dtd};{yCoord7dtd}";

            if (!isMove) return;
            GlobalHelper.Config.Map.Offset = new Point(GlobalHelper.Config.Map.Offset.X + e.Location.X - prevMousePosition.X, GlobalHelper.Config.Map.Offset.Y + e.Location.Y - prevMousePosition.Y);
            prevMousePosition = e.Location;
            Invalidate();
        }

        private void HelperForm_SizeChanged(object sender, EventArgs e)
        {
            if (graphicsMapDrawer == null)
                return;

            graphicsMapDrawer.Width = Width;
            graphicsMapDrawer.Height = Height;
            this.Refresh();
        }


        private void mapFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.ApplicationData,
                SelectedPath = GlobalHelper.Paths.MapsAppDataDirectory
            })
            {
                var result = fbd.ShowDialog();

                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath)) return;

                var mapName = Path.GetFileName(fbd.SelectedPath);
                var hostsFile = Path.Combine(fbd.SelectedPath, "hosts.txt");
                var worldDirectory = Path.Combine(fbd.SelectedPath, "World");
                var mapInfoFile = Path.Combine(worldDirectory, "map_info.xml");
                var prefabsFile = Path.Combine(worldDirectory, "prefabs.xml");
                var spawnPointsFile = Path.Combine(worldDirectory, "spawnpoints.xml");
                if (!File.Exists(hostsFile) || !Directory.Exists(worldDirectory)
                                            || !File.Exists(mapInfoFile)
                                            || !File.Exists(prefabsFile)
                                            || !File.Exists(spawnPointsFile))
                {
                    MessageBox.Show("It, seems, is not 7dtd map directory...");
                    return;
                }

                var hosts = File.ReadAllText(hostsFile)
                    .Replace("\r", "")
                    .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                var ip = "";
                var port = "";
                if (hosts.Length > 0)
                {
                    var host = hosts[0].Split(':');
                    if (host.Length > 1)
                    {
                        ip = host[0];
                        port = host[1];
                    }
                }

                if (GlobalHelper.Config.Maps.Contains(mapName))
                {
                    var mapTwin = Map.Load(mapName);
                    GlobalHelper.Config.Map.CellSize = mapTwin.CellSize;
                    GlobalHelper.Config.Map.Description = mapTwin.Description;
                    GlobalHelper.Config.Map.Offset = mapTwin.Offset;
                    GlobalHelper.Config.Map.Scale = mapTwin.Scale;
                }
                else
                {
                    GlobalHelper.Config.Map = new Map()
                    {
                        Name = mapName
                    };
                    var item = new ToolStripMenuItem()
                    {
                        Name = $"{mapName}ToolStripMenuItem",
                        Checked = false,
                        Text = mapName
                    };
                    item.Click += (o, args) =>
                    {
                        Map.Load(mapName);
                    };
                    loadToolStripMenuItem.DropDownItems.Add(item);
                }

                GlobalHelper.Config.Map.LoadPrefabs(prefabsFile, new XmlPrefabsMapLoader());
                GlobalHelper.Config.Map.LoadMapInfo(mapInfoFile);
                GlobalHelper.Config.Map.Ip = ip;
                GlobalHelper.Config.Map.Port = port;
                GlobalHelper.Config.Map.LoadSpawnPoints(spawnPointsFile);
                GlobalHelper.Config.Map.DirectoryPath = fbd.SelectedPath;

                GlobalHelper.Config.Save();
                UpdateUI();
            }
        }

        private void scaleToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GlobalHelper.Config?.Map == null)
            {
                return;
            }

            GlobalHelper.Config.Map.Offset = new Point(0, 0);
            int mapScale = int.TryParse(scaleToolStripTextBox.Text, out mapScale) ? mapScale : 1;
            GlobalHelper.Config.Map.Scale = mapScale;
        }

        private void sizeToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GlobalHelper.Config?.Map == null)
            {
                return;
            }

            GlobalHelper.Config.Map.Offset = new Point(0, 0);
            int mapSize = int.TryParse(sizeToolStripTextBox.Text, out mapSize) ? mapSize : 3072;
            GlobalHelper.Config.Map.Scale = mapSize;
        }

        private void sizeCellToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GlobalHelper.Config?.Map == null)
            {
                return;
            }

            int cellSize = int.TryParse(sizeCellToolStripTextBox.Text, out cellSize) ? cellSize : 50;
            GlobalHelper.Config.Map.CellSize = cellSize;
        }

        private void mapSacleTrackBar_ValueChanged(object sender, EventArgs e)
        {
            scaleToolStripTextBox.Text = mapSacleTrackBar.Value.ToString();
            this.Refresh();
        }

        private void updatePrefabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                GlobalHelper.Config.PrefabsConfig.UpdatePrefabs();
            }).Start();
        }

        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalHelper.Config.PrefabsConfig.Prefabs.Count == 0)
            {
                MessageBox.Show($"Prefabs is empty. You need to update the prefabs (Map => UpdatePrefabs)");
                return;
            }

            var groupPrefabsForm = new GroupPrefabs();
            if (groupPrefabsForm.ShowDialog(this) == DialogResult.OK)
            {
                var decorationGroup = groupPrefabsForm.Result;
                var twin = GlobalHelper.Config.DecorationGroups.SingleOrDefault(dg =>
                    string.Equals(dg.Name, decorationGroup.Name, StringComparison.CurrentCultureIgnoreCase));

                if (twin != null)
                {
                    decorationGroup.Name += "_Twin";
                    MessageBox.Show(
                        $"{twin.Name} has already exist. Name is changed to {decorationGroup.Name}");
                }
                GlobalHelper.Config.DecorationGroups.Add(decorationGroup);
            }
            groupPrefabsForm.Dispose();

            GlobalHelper.Config.Save();
            UpdateUI();
        }

        private void spawnPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var spawnPoints = GlobalHelper.Config.Map.MapObjects.SingleOrDefault(mo => string.Equals(mo.Name, "SpawnPoints", StringComparison.CurrentCultureIgnoreCase));
            if (spawnPoints == null)
            {
                spawnPointsToolStripMenuItem.Visible = false;
                return;
            }

            spawnPoints.IsEnabled = !spawnPoints.IsEnabled;
            spawnPointsToolStripMenuItem.Checked = spawnPoints.IsEnabled;
            GlobalHelper.Config.Save();
            Invalidate();
        }

        private void showBiomesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalHelper.Config.Map.IsBiomesShown = !GlobalHelper.Config.Map.IsBiomesShown;
            showBiomesToolStripMenuItem.Checked = GlobalHelper.Config.Map.IsBiomesShown;
            Invalidate();
        }
    }
}
