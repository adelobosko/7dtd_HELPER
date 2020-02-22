using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static _7dtd_HELP.Win32;

namespace _7dtd_HELP
{
    public partial class HelperForm : Form
    {
        private GlobalKeyboardHook gHook;
        private List<ToolStripMenuItem> groupStripMenuItems;

        public HelperForm()
        {
            InitializeComponent();
            this.MouseWheel += MapSacleTrackBarOnMouseWheel;
            mapPictureBox.MouseMove += MapPictureBox_MouseMove;
            mapPictureBox.MouseDown += HelperForm_MouseDown;
            mapPictureBox.MouseUp += MapPictureBox_MouseUp;
            KeyBoardHookInitialize();
            GlobalHelper.WebHelper = new WebHelper("");
            GlobalHelper.UpdateStatus = OnStatusChanged;
            GlobalHelper.UpdateSubStatus = OnSubStatusChanged;
            groupStripMenuItems = new List<ToolStripMenuItem>();
        }

        private void MapSacleTrackBarOnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (mapSacleTrackBar.Value == mapSacleTrackBar.Maximum)
                    return;
                mapSacleTrackBar.Value++;
            }
            else if (e.Delta < 0)
            {
                if (mapSacleTrackBar.Value == mapSacleTrackBar.Minimum)
                    return;
                mapSacleTrackBar.Value--;
            }
        }


        private Point prevRMBPosition;
        private void HelperForm_MouseDown(object sender, MouseEventArgs e)
        {
            toolTipPanel.Visible = false;
            if (e.Button == MouseButtons.Right)
            {
                mapPictureBox.Cursor = Cursors.SizeAll;
                prevRMBPosition = e.Location;
            }

            else if (e.Button == MouseButtons.Left)
            {
                int x0 = mapPictureBox.Width / 2;
                int y0 = mapPictureBox.Height / 2;
                var x = e.Location.X - x0;
                var y = y0 - e.Location.Y;
                var xCoord = x * GlobalHelper.Config.Map.Scale;
                var yCoord = y * GlobalHelper.Config.Map.Scale;
                GetPrefabsNearby(GlobalHelper.Config, xCoord, yCoord);
            }
        }

        private void GetPrefabsNearby(Config config, int xCenter, int yCenter)
        {
            foreach (Control control in toolTipPanel.Controls)
            {
                control.Dispose();
            }
            toolTipPanel.Controls.Clear();

            var radius = config.Map.ToolTipRadius;
            var objectsNearBy = new List<MapObjectNearBy>();

            foreach (var mapPrefab in config.Map.Prefabs)
            {
                var distance = Math.Sqrt(Math.Pow(xCenter - mapPrefab.X, 2) + Math.Pow(yCenter - mapPrefab.Y, 2));
                if (distance <= radius)
                {
                    objectsNearBy.Add(new MapObjectNearBy()
                    {
                        Distance = distance,
                        Object = mapPrefab
                    });
                }
            }

            if (config.Map.SpawnPoints.IsEnabled)
            {
                foreach (var mapPoint in config.Map.SpawnPoints.MapPoints)
                {
                    var distance = Math.Sqrt(Math.Pow(xCenter - mapPoint.X, 2) + Math.Pow(yCenter - mapPoint.Y, 2));
                    if (distance <= radius)
                    {
                        objectsNearBy.Add(new MapObjectNearBy()
                        {
                            Distance = distance,
                            Object = mapPoint
                        });
                    }
                }
            }


            foreach (var mapObjectNearBy in objectsNearBy.OrderByDescending(o => o.Distance))
            {
                if (mapObjectNearBy.Object is MapPoint mapPoint)
                {
                    var nameLabel = new Label();
                    nameLabel.Text = mapPoint.Name;
                    nameLabel.Dock = DockStyle.Top;
                    nameLabel.ForeColor = Color.Black;

                    var distanceLabel = new Label();
                    distanceLabel.Text = $"Distance: {mapObjectNearBy.Distance:0.00}";
                    distanceLabel.Dock = DockStyle.Top;
                    distanceLabel.ForeColor = Color.Black;

                    var coordinatesLabel = new Label();
                    coordinatesLabel.Text = $"{mapPoint.X}; {mapPoint.Y}";
                    coordinatesLabel.Dock = DockStyle.Top;
                    coordinatesLabel.ForeColor = Color.Black;

                    var coordinates7dtdLabel = new Label();
                    var xCoord7dtd = mapPoint.X < 0 ? $"{Math.Abs(mapPoint.X)}W" : $"{Math.Abs(mapPoint.X)}E";
                    var yCoord7dtd = mapPoint.Y < 0 ? $"{Math.Abs(mapPoint.Y)}S" : $"{Math.Abs(mapPoint.Y)}N";
                    coordinates7dtdLabel.Text = $"{xCoord7dtd}; {yCoord7dtd}";
                    coordinates7dtdLabel.Dock = DockStyle.Top;
                    coordinates7dtdLabel.ForeColor = Color.Black;

                    var allowedGroups = config.DecorationGroups.Where(g => g.IsEnabled).ToList();
                    var groups = allowedGroups.Where(g => g.Prefabs.Count(p => p.Name == mapPoint.Name) > 0).ToList().Select(g => new
                    {
                        Name = g.Name,
                        BrushColor = g.BrushColor,
                        Icon = g.Icon,
                        Description = g.Prefabs.FirstOrDefault(p => p.Name == mapPoint.Name)?.Description
                    });

                    foreach (var group in groups)
                    {
                        var groupLabel = new Label();
                        groupLabel.ImageAlign = ContentAlignment.MiddleLeft;
                        groupLabel.TextAlign = ContentAlignment.MiddleCenter;
                        groupLabel.Text = group.Name+" "+ group.Description;
                        groupLabel.Parent = toolTipPanel;
                        groupLabel.ForeColor = Color.Black;

                        if (group.Icon != null)
                        {
                            groupLabel.Image = group.Icon.GetBitmapByFile().ResizeImage(16, 16);
                        }
                        else
                        {
                            var bitmap = new Bitmap(16, 16);
                            var g = Graphics.FromImage(bitmap);
                            g.Clear(((SolidBrush)group.BrushColor).Color);
                            groupLabel.Image = bitmap;
                        }
                        groupLabel.Dock = DockStyle.Top;
                        toolTipPanel.Controls.Add(groupLabel);
                    }


                    coordinates7dtdLabel.Parent = toolTipPanel;
                    coordinatesLabel.Parent = toolTipPanel;
                    distanceLabel.Parent = toolTipPanel;
                    nameLabel.Parent = toolTipPanel;
                    toolTipPanel.Controls.Add(coordinatesLabel);
                    toolTipPanel.Controls.Add(coordinates7dtdLabel);
                    toolTipPanel.Controls.Add(distanceLabel);
                    toolTipPanel.Controls.Add(nameLabel);
                }
            }

            if (objectsNearBy.Count > 0)
            {
                toolTipPanel.Visible = true;
            }
        }


        private void MapPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mapPictureBox.Cursor = Cursors.Hand;
            }
        }
        private void MapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (GlobalHelper.Config?.Map == null)
            {
                return;
            }

            int x0 = mapPictureBox.Width / 2;
            int y0 = mapPictureBox.Height / 2;

            var x = e.Location.X - x0;
            var y = y0 - e.Location.Y;

            var xCoord = x * GlobalHelper.Config.Map.Scale;
            var yCoord = y * GlobalHelper.Config.Map.Scale;
            var xCoord7dtd = xCoord < 0 ? $"{Math.Abs(xCoord)}W" : $"{Math.Abs(xCoord)}E";
            var yCoord7dtd = yCoord < 0 ? $"{Math.Abs(yCoord)}S" : $"{Math.Abs(yCoord)}N";
            coordinatesToolStripTextBox.Text = $"{xCoord};{yCoord}";
            coordinates7dtdToolStripTextBox.Text = $"{xCoord7dtd};{yCoord7dtd}";


            if (e.Button == MouseButtons.Right)
            {
                var changePoint = new Point(
                    e.Location.X - prevRMBPosition.X,
                    e.Location.Y - prevRMBPosition.Y);
                bodyPanel.AutoScrollPosition = new Point(
                    -bodyPanel.AutoScrollPosition.X - changePoint.X,
                    -bodyPanel.AutoScrollPosition.Y - changePoint.Y);
            }
            //GlobalHelper.Config.Map.Offset = new Point(GlobalHelper.Config.Map.Offset.X + e.Location.X - prevMousePosition.X, GlobalHelper.Config.Map.Offset.Y + e.Location.Y - prevMousePosition.Y);
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
            RedrawMap();
        }


        public void RedrawMap()
        {
            var scaledSize = GlobalHelper.Config.Map.Size / GlobalHelper.Config.Map.Scale;
            var bm = new Bitmap(scaledSize, scaledSize);
            using (var gr = Graphics.FromImage(bm))
            {
                //DrawBiomes(map);
                if (GlobalHelper.Config.Map.IsBiomesShown)
                {
                    var bitmap = GlobalHelper.Config.Map.GetBiomes(scaledSize, scaledSize);
                    if (bitmap != null)
                    {
                        gr.DrawImage(bitmap, new Point(0, 0));
                    }
                }


                //DrawGrid(map);
                var gridColor = Pens.Gray;
                var rowsAndColumns = scaledSize / GlobalHelper.Config.Map.CellSize;
                int x0 = scaledSize / 2;
                int y0 = scaledSize / 2;
                int sizeRectangle = 4;

                gr.FillRectangle(
                    Brushes.Black,
                    x0 - sizeRectangle,
                    y0 - sizeRectangle,
                    sizeRectangle * 2,
                    sizeRectangle * 2
                );

                for (var i = 0; i < rowsAndColumns; i++)
                {
                    gr.DrawLine(gridColor,
                        x0,
                        y0 + GlobalHelper.Config.Map.CellSize * i,
                        x0 + scaledSize,
                        y0 + GlobalHelper.Config.Map.CellSize * i);
                    gr.DrawLine(gridColor,
                        x0,
                        y0 - GlobalHelper.Config.Map.CellSize * i,
                        x0 + scaledSize,
                        y0 - GlobalHelper.Config.Map.CellSize * i);

                    gr.DrawLine(gridColor,
                        x0 + GlobalHelper.Config.Map.CellSize * i,
                        y0,
                        x0 + GlobalHelper.Config.Map.CellSize * i,
                        y0 + scaledSize);
                    gr.DrawLine(gridColor,
                        x0 + GlobalHelper.Config.Map.CellSize * i,
                        y0,
                        x0 + GlobalHelper.Config.Map.CellSize * i,
                        y0 - scaledSize);



                    gr.DrawLine(gridColor,
                        x0,
                        y0 - GlobalHelper.Config.Map.CellSize * i,
                        x0 - scaledSize,
                        y0 - GlobalHelper.Config.Map.CellSize * i);
                    gr.DrawLine(gridColor,
                        x0,
                        y0 + GlobalHelper.Config.Map.CellSize * i,
                        x0 - scaledSize,
                        y0 + GlobalHelper.Config.Map.CellSize * i);

                    gr.DrawLine(gridColor,
                        x0 - GlobalHelper.Config.Map.CellSize * i,
                        y0,
                        x0 - GlobalHelper.Config.Map.CellSize * i,
                        y0 - scaledSize);
                    gr.DrawLine(gridColor,
                        x0 - GlobalHelper.Config.Map.CellSize * i,
                        y0,
                        x0 - GlobalHelper.Config.Map.CellSize * i,
                        y0 + scaledSize);
                }


                //DrawPrefabs(map);

                //TODO: Draw myself
                try
                {
                    var font = new Font("Courier New", 14);
                    var size = 2;

                    var x = x0 + GlobalHelper.MyCoordinates.X / GlobalHelper.Config.Map.Scale;
                    var y = y0 - GlobalHelper.MyCoordinates.Y / GlobalHelper.Config.Map.Scale;
                    gr.FillRectangle(
                        Brushes.BlueViolet,
                        x - size,
                        y - size,
                        size * 2,
                        size * 2
                    );
                    gr.DrawString(GlobalHelper.MyCoordinates.Name, font, Brushes.BlueViolet, x - size, y - size);
                }
                catch
                {
                }

                var allowedGroups = GlobalHelper.Config.DecorationGroups.Where(g => g.IsEnabled).ToList();

                foreach (var prefab in GlobalHelper.Config.Map.Prefabs)
                {
                    var font = new Font("Courier New", 14);
                    var x = x0 + prefab.X / GlobalHelper.Config.Map.Scale;
                    var y = y0 - prefab.Y / GlobalHelper.Config.Map.Scale;

                    if (!GlobalHelper.Config.Map.IsShowAllPrefabIcons)
                    {
                        var firstGroup =
                            allowedGroups.FirstOrDefault(g => g.Prefabs.Count(p => p.Name == prefab.Name) > 0);

                        if (firstGroup == null)
                            continue;

                        if (firstGroup.Icon == null)
                        {
                            gr.FillRectangle(
                                firstGroup.BrushColor,
                                x - firstGroup.BrushSize / 2,
                                y - firstGroup.BrushSize / 2,
                                firstGroup.BrushSize,
                                firstGroup.BrushSize
                            );
                        }
                        else
                        {
                            if (firstGroup.Icon.Width == -1 && firstGroup.Icon.Height == -1)
                            {
                                var image = firstGroup.Icon.GetBitmapByFile();
                                gr.DrawImage(
                                    image,
                                    new Point(
                                        x - image.Width / 2,
                                        y - image.Height / 2
                                    )
                                );
                            }
                            else
                            {
                                var image = firstGroup.Icon.GetBitmapByFile()
                                    .ResizeImage(firstGroup.Icon.Width, firstGroup.Icon.Height);
                                gr.DrawImage(image,
                                    new Point(
                                        x - image.Width / 2,
                                        y - image.Height / 2
                                    )
                                );
                            }
                        }
                    }
                    else
                    {
                        var groups = allowedGroups.Where(g => g.Prefabs.Count(p => p.Name == prefab.Name) > 0).ToList();

                        if (!groups.Any())
                            continue;

                        foreach (var group in groups)
                        {
                            if (group.Icon == null)
                            {
                                gr.FillRectangle(
                                    group.BrushColor,
                                    x - group.BrushSize / 2,
                                    y - group.BrushSize / 2,
                                    group.BrushSize,
                                    group.BrushSize
                                );
                            }
                            else
                            {
                                if (group.Icon.Width == -1 && group.Icon.Height == -1)
                                {
                                    var image = group.Icon.GetBitmapByFile();
                                    gr.DrawImage(
                                        image,
                                        new Point(
                                            x - image.Width / 2,
                                            y - image.Height / 2
                                        )
                                    );
                                }
                                else
                                {
                                    var image = group.Icon.GetBitmapByFile()
                                        .ResizeImage(group.Icon.Width, group.Icon.Height);
                                    gr.DrawImage(image,
                                        new Point(
                                            x - image.Width / 2,
                                            y - image.Height / 2
                                        )
                                    );
                                }
                            }
                        }
                    }
                }


                //DrawSpawnPoints
                if (GlobalHelper.Config.Map.SpawnPoints.IsEnabled)
                {
                    foreach (var mapPoint in GlobalHelper.Config.Map.SpawnPoints.MapPoints)
                    {
                        var x = x0 + mapPoint.X / GlobalHelper.Config.Map.Scale;
                        var y = y0 - mapPoint.Y / GlobalHelper.Config.Map.Scale;

                        if (GlobalHelper.Config.Map.SpawnPoints.Icon == null)
                        {
                            gr.FillRectangle(
                                GlobalHelper.Config.Map.SpawnPoints.BrushColor,
                                x - GlobalHelper.Config.Map.SpawnPoints.BrushSize / 2,
                                y - GlobalHelper.Config.Map.SpawnPoints.BrushSize / 2,
                                GlobalHelper.Config.Map.SpawnPoints.BrushSize,
                                GlobalHelper.Config.Map.SpawnPoints.BrushSize
                            );
                        }
                        else
                        {
                            if (GlobalHelper.Config.Map.SpawnPoints.Icon.Width == -1
                                && GlobalHelper.Config.Map.SpawnPoints.Icon.Height == -1)
                            {
                                var image = GlobalHelper.Config.Map.SpawnPoints.Icon.GetBitmapByFile();
                                gr.DrawImage(
                                    image,
                                    new Point(
                                        x - image.Width / 2,
                                        y - image.Height / 2
                                    )
                                );
                            }
                            else
                            {
                                var image = GlobalHelper.Config.Map.SpawnPoints.Icon.GetBitmapByFile()
                                    .ResizeImage(
                                        GlobalHelper.Config.Map.SpawnPoints.Icon.Width,
                                        GlobalHelper.Config.Map.SpawnPoints.Icon.Height);
                                gr.DrawImage(image,
                                    new Point(
                                        x - image.Width / 2,
                                        y - image.Height / 2
                                    )
                                );
                            }
                        }
                    }
                }

                //DrawCollections(map);
                //Rectangle rect = new Rectangle(10, 10, 260, 90);
                //gr.FillEllipse(Brushes.LightGreen, rect);
                //using (Pen thick_pen = new Pen(Color.Blue, 5))
                //{
                //    gr.DrawEllipse(thick_pen, rect);
                //}
            }
            mapPictureBox.Image = bm;
        }


        public void CenterScrollPositions()
        {
            bodyPanel.VerticalScroll.Minimum = 0;
            bodyPanel.VerticalScroll.Maximum = mapPictureBox.Height;
            bodyPanel.HorizontalScroll.Minimum = 0;
            bodyPanel.HorizontalScroll.Maximum = mapPictureBox.Width;
            bodyPanel.HorizontalScroll.Value = mapPictureBox.Width / 2;
            bodyPanel.VerticalScroll.Value = mapPictureBox.Height / 2;
        }

        private void UpdateUI()
        {
            mapSacleTrackBar.Value = Convert.ToString(GlobalHelper.Config.Map.Scale, 2).Length - 1;
            CenterScrollPositions();

            setIconSpawnPointsToolStripMenuItem.Image = GlobalHelper.Config.Map.SpawnPoints.Icon == null
                ? new Bitmap(16, 16)
                : Image.FromFile(GlobalHelper.Config.Map.SpawnPoints.Icon.FullName).ResizeImage(16, 16);

            var bitmap = new Bitmap(16, 16);
            var g = Graphics.FromImage(bitmap);
            g.Clear(((SolidBrush)GlobalHelper.Config.Map.SpawnPoints.BrushColor).Color);
            setSpawnPointsBrushColorToolStripMenuItem.Image = bitmap;
            spawnPointsBrushSizeToolStripTextBox.Text = GlobalHelper.Config.Map.SpawnPoints.BrushSize.ToString();
            showAllPrefabIconsToolStripMenuItem.Checked = GlobalHelper.Config.Map.IsShowAllPrefabIcons;

            var spawnPointsObjectCollection = GlobalHelper.Config.Map.SpawnPoints;
            if (spawnPointsObjectCollection == null)
            {
                spawnPointsToolStripMenuItem.Visible = false;
            }
            else
            {
                spawnPointsToolStripMenuItem.Visible = true;
                spawnPointsToolStripMenuItem.Checked = spawnPointsObjectCollection.IsEnabled;
            }

            this.Text = $@"{GlobalHelper.Config.Map.Name} - {GlobalHelper.Config.Map.Ip}:{GlobalHelper.Config.Map.Port}";

            sizeCellToolStripTextBox.Text = GlobalHelper.Config.Map.CellSize.ToString();
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
                    RedrawMap();
                };

                var groupEdit = new ToolStripMenuItem()
                {
                    Name = $"{group.Name}EditToolStripMenuItem",
                    Checked = false,
                    Text = "Edit"
                };
                groupEdit.Click += (o, args) =>
                {
                    var groupPrefab = new GroupPrefabsForm();
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
                    RedrawMap();
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
                    RedrawMap();
                };

                item.DropDownItems.Add(groupDelete);

                groupStripMenuItems.Add(item);
                groupsToolStripMenuItem.DropDownItems.Add(item);
            }
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

        private void sizeToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GlobalHelper.Config?.Map == null)
            {
                return;
            }

            int mapSize = int.TryParse(sizeToolStripTextBox.Text, out mapSize) ? mapSize : Map.DefaultSize;
            GlobalHelper.Config.Map.Size = mapSize;
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
            GlobalHelper.Config.Map.Scale = (int)Math.Pow(2, mapSacleTrackBar.Value);
            mapPictureBox.Height = GlobalHelper.Config.Map.Size / GlobalHelper.Config.Map.Scale;
            mapPictureBox.Width = GlobalHelper.Config.Map.Size / GlobalHelper.Config.Map.Scale;

            RedrawMap();
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

            var groupPrefabsForm = new GroupPrefabsForm();
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

                GlobalHelper.Config.Save();
                UpdateUI();
                RedrawMap();
            }
            groupPrefabsForm.Dispose();
        }

        private void spawnPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalHelper.Config.Map.SpawnPoints.IsEnabled = !GlobalHelper.Config.Map.SpawnPoints.IsEnabled;
            spawnPointsToolStripMenuItem.Checked = GlobalHelper.Config.Map.SpawnPoints.IsEnabled;
            GlobalHelper.Config.Save();
            RedrawMap();
        }

        private void showBiomesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalHelper.Config.Map.IsBiomesShown = !GlobalHelper.Config.Map.IsBiomesShown;
            showBiomesToolStripMenuItem.Checked = GlobalHelper.Config.Map.IsBiomesShown;
            RedrawMap();
        }
        private void coordsToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GlobalHelper.MyCoordinates.Name = "I AM HERE";
                var text = coordsToolStripTextBox.Text.Split(';');
                var xW = text[0][text[0].Length - 1];
                var xText = Convert.ToInt32(text[0].Substring(0, text[0].Length - 1));

                var yW = text[1][text[1].Length - 1];
                var yText = Convert.ToInt32(text[1].Substring(0, text[1].Length - 1));
                if (xW == 'W')
                {
                    GlobalHelper.MyCoordinates.X = -1 * xText;
                }
                else if (xW == 'E')
                {
                    GlobalHelper.MyCoordinates.X = xText;
                }

                if (xW == 'S')
                {
                    GlobalHelper.MyCoordinates.Y = -1 * xText;
                }
                else if (xW == 'N')
                {
                    GlobalHelper.MyCoordinates.Y = xText;
                }
            }
            catch
            {

            }
        }

        private void setIconSpawnPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var setIconForm = new SetIconForm();
            setIconForm.Icon = GlobalHelper.Config.Map.SpawnPoints.Icon;
            setIconForm.PreviewIcon();
            if (setIconForm.ShowDialog(this) == DialogResult.OK)
            {
                var resultIcon = setIconForm.Icon;
                GlobalHelper.Config.Map.SpawnPoints.Icon = resultIcon;
            }
            setIconForm.Dispose();
            setIconSpawnPointsToolStripMenuItem.Image = GlobalHelper.Config.Map.SpawnPoints.Icon == null
                ? new Bitmap(16, 16)
                : Image.FromFile(GlobalHelper.Config.Map.SpawnPoints.Icon.FullName).ResizeImage(16, 16);

            RedrawMap();
        }

        private void setSpawnPointsBrushColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colorDialog1 = new ColorDialog();
            SolidBrush color;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = new SolidBrush(colorDialog1.Color);
                GlobalHelper.Config.Map.SpawnPoints.BrushColor = color;

                var bitmap = new Bitmap(16, 16);
                var g = Graphics.FromImage(bitmap);
                g.Clear(((SolidBrush)GlobalHelper.Config.Map.SpawnPoints.BrushColor).Color);
                setSpawnPointsBrushColorToolStripMenuItem.Image = bitmap;
                RedrawMap();
            }

            colorDialog1.Dispose();
        }

        private void spawnPointsBrushSizeToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var brushSize = Convert.ToInt32(spawnPointsBrushSizeToolStripTextBox.Text);
                GlobalHelper.Config.Map.SpawnPoints.BrushSize = brushSize > 0 ? brushSize : 1;
            }
            catch
            {
            }
        }

        private void showAllPrefabIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalHelper.Config.Map.IsShowAllPrefabIcons = !GlobalHelper.Config.Map.IsShowAllPrefabIcons;
            showAllPrefabIconsToolStripMenuItem.Checked = GlobalHelper.Config.Map.IsShowAllPrefabIcons;
            RedrawMap();
        }
    }
}
