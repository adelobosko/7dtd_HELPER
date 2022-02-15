using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using _7dtd_HELP.Automation;
using static _7dtd_HELP.WinApi.User32;

namespace _7dtd_HELP
{
    public partial class HelperForm : Form
    {
        private GlobalKeyboardHook gHook;
        private AutomationConfig _automationConfig;
        private Logger.Logger _logger;
        private readonly List<ToolStripMenuItem> _groupStripMenuItems;
        private Point _prevRmbPosition;
        private bool _isRmbPressed;
        private bool _isLmbPressed;


        private int _gimmeCounter = 0;


        public HelperForm()
        {
            InitializeComponent();

            this.MouseWheel += MapScaleTrackBarOnMouseWheel;
            mapPictureBox.MouseMove += MapPictureBox_MouseMove;
            mapPictureBox.MouseDown += HelperForm_MouseDown;
            mapPictureBox.MouseUp += MapPictureBox_MouseUp;
            GlobalHelper.WebHelper = new WebHelper("");
            GlobalHelper.UpdateStatus = OnStatusChanged;
            GlobalHelper.UpdateSubStatus = OnSubStatusChanged;
            _groupStripMenuItems = new List<ToolStripMenuItem>();


            this._automationConfig = new AutomationConfig()
            {
                LmbClick = new DelayableMouseButtonClick(
                    () =>
                        {
                            InputHelper.Send(InputSet.LeftMouseButton);
                        },
                    delay: 1,
                    keysCombination: "ALT + NUMPAD1"
                ),
                RmbClick = new DelayableMouseButtonClick(
                    () =>
                    {
                        InputHelper.Send(InputSet.RightMouseButton);
                    },
                    delay: 1,
                    keysCombination: "ALT + NUMPAD2"
                )
            };
            _logger = new Logger.Logger(logTextBox, true);

            typeCheckToolStripComboBox.SelectedIndex = 0;
            typeCheckToolStripComboBox.SelectedIndexChanged += (o, args) =>
            {
                switch (typeCheckToolStripComboBox.SelectedIndex)
                {
                    case 0:
                        checkNToolStripTextBox.Enabled = false;
                        break;
                    default:
                        checkNToolStripTextBox.Enabled = true;
                        break;
                }
            };

            beepIfDayToolStripComboBox.SelectedIndex = 0;
            beepIfDayToolStripComboBox.SelectedIndexChanged += (o, args) =>
            {
                switch (beepIfDayToolStripComboBox.SelectedIndex)
                {
                    case 0:
                        beepIfDayKToolStripTextBox.Enabled = false;
                        break;
                    default:
                        beepIfDayKToolStripTextBox.Enabled = true;
                        break;
                }
            };

            KeyBoardHookInitialize();
        }

        private void MapScaleTrackBarOnMouseWheel(object sender, MouseEventArgs e)
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


        private void HelperForm_MouseDown(object sender, MouseEventArgs e)
        {
            toolTipPanel.Visible = false;

            if (e.Button == MouseButtons.Right)
            {
                if (_isLmbPressed == false)
                {
                    mapPictureBox.Cursor = Cursors.SizeAll;
                    _prevRmbPosition = e.Location;
                }

                _isRmbPressed = true;
            }

            else if (e.Button == MouseButtons.Left)
            {
                if (_isRmbPressed == false)
                {
                    int x0 = mapPictureBox.Width / 2;
                    int y0 = mapPictureBox.Height / 2;
                    var x = e.Location.X - x0;
                    var y = y0 - e.Location.Y;
                    var xCoord = x * GlobalHelper.Config.Map.Scale;
                    var yCoord = y * GlobalHelper.Config.Map.Scale;
                    GetPrefabsNearby(GlobalHelper.Config, xCoord, yCoord);

                }

                _isLmbPressed = true;
            }

            if (_isRmbPressed && _isLmbPressed)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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
                    var groups = allowedGroups.Where(g => g.Prefabs.Count(p => p.Name == mapPoint.Name) > 0);

                    foreach (var group in groups)
                    {
                        var groupLabel = new Label();
                        groupLabel.ImageAlign = ContentAlignment.MiddleLeft;
                        groupLabel.TextAlign = ContentAlignment.MiddleCenter;
                        groupLabel.Text = group.Name;
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
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        _isLmbPressed = false;
                        break;
                    }
                case MouseButtons.Right:
                    {

                        mapPictureBox.Cursor = Cursors.Hand;
                        _isRmbPressed = false;
                        break;
                    }
            }
        }

        private Point GetGamePosByMapPos(Point mapPoint, Point mapCenter)
        {
            var x = mapPoint.X - mapCenter.X;
            var y = mapCenter.Y - mapPoint.Y;

            var xCoordinate = x * GlobalHelper.Config.Map.Scale;
            var yCoordinate = y * GlobalHelper.Config.Map.Scale;

            return new Point(xCoordinate, yCoordinate);
        }

        private Point GetMapPosByGamePos(Point gamePoint, Point mapCenter)
        {
            var x = gamePoint.X / GlobalHelper.Config.Map.Scale;
            var y = gamePoint.Y / GlobalHelper.Config.Map.Scale;

            var xCoordinate = x + mapCenter.X;
            var yCoordinate = Math.Abs(y - mapCenter.Y);

            return new Point(xCoordinate, yCoordinate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gamePoint">Ex. -500;300</param>
        /// <param name="mask">
        /// {x}: ABS(x) = 500;
        /// {y}: ABS(y) = 300;
        /// {-x}: x = -500;
        /// {-y}: y = 300</param>
        /// {xOS}: W or E (WEST / EAST);
        /// {yOS}: S or N (SOUTH / NORTH);
        /// <returns></returns>
        private string GetCordsByFormat(Point gamePoint, string mask = "{x}{xOS};{y}{yOS}")
        {
            var result = new StringBuilder();

            mask = mask.Replace("{X}", "{x}")
                .Replace("{Y}", "{y}")
                .Replace("{XOS}", "{xOS}")
                .Replace("{YOS}", "{yOS}");

            result = new StringBuilder(mask);

            result = result.Replace("{x}", $"{Math.Abs(gamePoint.X)}");
            result = result.Replace("{y}", $"{Math.Abs(gamePoint.Y)}");
            result = result.Replace("{-x}", $"{gamePoint.X}");
            result = result.Replace("{-y}", $"{gamePoint.Y}");
            result = result.Replace("{xOS}", $"{(gamePoint.X < 0 ? "W" : "E")}");
            result = result.Replace("{yOS}", $"{(gamePoint.Y < 0 ? "S" : "N")}");

            return result.ToString();
        }


        private void MapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (GlobalHelper.Config?.Map == null)
            {
                return;
            }

            int x0 = mapPictureBox.Width / 2;
            int y0 = mapPictureBox.Height / 2;
            var mapCenter = new Point(x0, y0);

            var gamePoint = GetGamePosByMapPos(e.Location, mapCenter);
            coordinates7dtdToolStripTextBox.Text = GetCordsByFormat(gamePoint);



            if (e.Button == MouseButtons.Right)
            {
                var changePoint = new Point(
                    e.Location.X - _prevRmbPosition.X,
                    e.Location.Y - _prevRmbPosition.Y);
                bodyPanel.AutoScrollPosition = new Point(
                    -bodyPanel.AutoScrollPosition.X - changePoint.X,
                    -bodyPanel.AutoScrollPosition.Y - changePoint.Y);
            }
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
            gHook.HookedKeys.Add(Keys.NumPad4);
            //MouseHook.Start();
        }


        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (GetAsyncKeyState((int)VirtualKeyShort.MENU) == 0)
                return;


            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    _automationConfig.LmbClick.IsTimerEnabled = !_automationConfig.LmbClick.IsTimerEnabled;
                    e.Handled = true;
                    break;
                case Keys.NumPad2:
                    _automationConfig.RmbClick.IsTimerEnabled = !_automationConfig.RmbClick.IsTimerEnabled;
                    e.Handled = true;
                    break;
                case Keys.NumPad3:
                    {
                        gimmeTimer.Enabled = !gimmeTimer.Enabled;
                        _gimmeCounter = 0;
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
                        var tKey = new List<Input>()
                    {
                        InputHelper.GetKeyboardInput(ScanCodeShort.KEY_T, VirtualKeyShort.KEY_T, KeyEventF.KEYDOWN),
                        InputHelper.GetKeyboardInput(ScanCodeShort.KEY_T, VirtualKeyShort.KEY_T, KeyEventF.KEYUP),
                    }.ToArray();

                        InputHelper.Send(tKey);
                        Thread.Sleep(100);
                        InputHelper.Send(InputSet.Paste);
                        InputHelper.Send(InputSet.Enter);
                        e.Handled = true;
                        break;
                    }
                case Keys.NumPad4:
                    {
                        DrawMeOnMap();
                        e.Handled = true;
                        break;
                    }
            }
        }


        private void HelperForm_Load(object sender, EventArgs e)
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
                    try
                    {
                        GlobalHelper.Config.Map = Map.Load(name);
                        LoadMapFolder(GlobalHelper.Config.Map.DirectoryPath);
                        UpdateUI();
                    }
                    catch (ArgumentException ex)
                    {
                        GlobalHelper.Config.Maps.Remove(name);
                        loadToolStripMenuItem.DropDownItems.Remove(item);
                        item.Dispose();
                    }
                };
                loadToolStripMenuItem.DropDownItems.Add(item);
            }

            UpdateUI();
            redrawExecuteTimer.Restart();
        }


        private async Task<Bitmap> RedrawMapAsync()
        {

            var scaledSize = GlobalHelper.Config.Map.Size / GlobalHelper.Config.Map.Scale;
            var bmp = new Bitmap(scaledSize, scaledSize);

            bmp = await DrawBiomesAsync(bmp, scaledSize);

            bmp = await DrawRadiationAsync(bmp, scaledSize);

            bmp = await DrawCitiesAsync(bmp, scaledSize);

            bmp = await DrawGridAsync(bmp, scaledSize);

            bmp = await DrawPrefabsAsync(bmp, scaledSize);

            bmp = await DrawSpawnPointsAsync(bmp, scaledSize);

            bmp = await DrawMeAsync(bmp, scaledSize);

            //DrawCollections(map);
            //Rectangle rect = new Rectangle(10, 10, 260, 90);
            //gr.FillEllipse(Brushes.LightGreen, rect);
            //using (Pen thick_pen = new Pen(Color.Blue, 5))
            //{
            //    gr.DrawEllipse(thick_pen, rect);
            //}

            return bmp;
        }


        private Task<Bitmap> DrawBiomesAsync(Bitmap bmp, int scaledSize)
        {
            var task = new Task<Bitmap>(() =>
            {
                if (GlobalHelper.Config.Map.Biomes.IsShown)
                {
                    var bitmap = GlobalHelper.Config.Map.Biomes.GetBitmap(scaledSize, scaledSize);

                    if (bitmap != null)
                    {
                        bitmap.SetResolution(96, 96);
                        bitmap = bitmap.ChangeOpacity(GlobalHelper.Config.Map.Biomes.Opacity / 100f);

                        //bitmap.Save("biome.png");
                        using (var gr = Graphics.FromImage(bmp))
                        {
                            gr.DrawImage(bitmap, new Point(0, 0));
                        }
                    }
                }

                return bmp;
            });
            task.Start();

            return task;
        }


        private Task<Bitmap> DrawRadiationAsync(Bitmap mapBitmap, int scaledSize)
        {
            var oldColor = Color.FromArgb(255, 0, 0, 0);
            var newColor = Color.FromArgb(0, 0, 0, 0);

            var task = new Task<Bitmap>(() =>
            {
                if (GlobalHelper.Config.Map.Radiation.IsShown)
                {
                    var bitmap = GlobalHelper.Config.Map.Radiation.GetBitmap(scaledSize, scaledSize);

                    if (bitmap != null)
                    {
                        bitmap.SetResolution(96, 96);
                        BitmapHelper.ReplaceColor(bitmap, oldColor, newColor);
                        bitmap = bitmap.ChangeOpacity(GlobalHelper.Config.Map.Radiation.Opacity / 100f);


                        //bitmap.Save("rad.png");
                        using (var gr = Graphics.FromImage(mapBitmap))
                        {
                            gr.DrawImage(bitmap, new Point(0, 0));
                        }
                    }
                }

                return mapBitmap;
            });

            task.Start();

            return task;
        }


        private Task<Bitmap> DrawCitiesAsync(Bitmap bmp, int scaledSize)
        {
            var oldColor = Color.FromArgb(255, 0, 0, 0);
            var newColor = Color.FromArgb(0, 0, 0, 0);

            var task = new Task<Bitmap>(() =>
            {
                if (GlobalHelper.Config.Map.Cities.IsShown)
                {
                    var bitmap = GlobalHelper.Config.Map.Cities.GetBitmap(scaledSize, scaledSize);
                    if (bitmap != null)
                    {
                        bitmap.SetResolution(96, 96);
                        //BitmapHelper.ReplaceColor(bitmap, oldColor, newColor);
                        //BitmapHelper.ReplaceAlpha(bitmap, 254);
                        bitmap = bitmap.ChangeOpacity(GlobalHelper.Config.Map.Cities.Opacity / 100f);
                        //bitmap.Save("city.png");

                        using (var gr = Graphics.FromImage(bmp))
                        {
                            gr.DrawImage(bitmap, new Point(0, 0));
                        }
                    }
                }

                return bmp;
            });
            task.Start();

            return task;
        }


        private Task<Bitmap> DrawGridAsync(Bitmap bmp, int scaledSize)
        {
            var task = new Task<Bitmap>(() =>
            {
                //DrawGrid(map);
                var gridColor = Pens.Gray;
                var rowsAndColumns = scaledSize / GlobalHelper.Config.Map.CellSize;
                int x0 = scaledSize / 2;
                int y0 = scaledSize / 2;
                int sizeRectangle = 4;

                using (var gr = Graphics.FromImage(bmp))
                {
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

                    gr.DrawImage(bmp, new Point(0, 0));
                }

                return bmp;
            });
            task.Start();

            return task;
        }


        private Task<Bitmap> DrawPrefabsAsync(Bitmap bmp, int scaledSize)
        {
            var task = new Task<Bitmap>(() =>
            {

                using (var gr = Graphics.FromImage(bmp))
                {
                    var allowedGroups = GlobalHelper.Config.DecorationGroups.Where(g => g.IsEnabled).ToList();
                    int x0 = scaledSize / 2;
                    int y0 = scaledSize / 2;

                    foreach (var prefab in GlobalHelper.Config.Map.Prefabs)
                    {
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
                    gr.DrawImage(bmp, new Point(0, 0));
                }

                return bmp;
            });
            task.Start();

            return task;
        }


        private Task<Bitmap> DrawSpawnPointsAsync(Bitmap bmp, int scaledSize)
        {
            var task = new Task<Bitmap>(() =>
            {
                if (GlobalHelper.Config.Map.SpawnPoints.IsEnabled)
                {
                    int x0 = scaledSize / 2;
                    int y0 = scaledSize / 2;

                    using (var gr = Graphics.FromImage(bmp))
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
                }

                return bmp;
            });
            task.Start();

            return task;
        }


        private Task<Bitmap> DrawMeAsync(Bitmap bmp, int scaledSize)
        {
            var task = new Task<Bitmap>(() =>
            {
                int x0 = scaledSize / 2;
                int y0 = scaledSize / 2;

                using (var gr = Graphics.FromImage(bmp))
                {
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
                }

                return bmp;
            });
            task.Start();

            return task;
        }


        public async void RedrawMap()
        {
            var bodyPanelCenterPoint = new Point(bodyPanel.Width / 2 - loadingLabel.Height / 2, bodyPanel.Height / 2 - loadingLabel.Width / 2);

            loadingLabel.Location = bodyPanelCenterPoint;
            loadingLabel.Show();
            var bmp = await RedrawMapAsync();

            mapPictureBox.Image = bmp;
            loadingLabel.Hide();

            SetMapPositionBySavedCenterGameCoordinates();
        }


        private void SetMapPositionBySavedCenterGameCoordinates()
        {
            int x0 = mapPictureBox.Width / 2;
            int y0 = mapPictureBox.Height / 2;
            var mapCenter = new Point(x0, y0);
            var mapPos = GetMapPosByGamePos(GlobalHelper.Config.CurrentMapCenterGameCoordinates, mapCenter);
            var mapPosToCenter = new Point(mapPos.X - bodyPanel.Width / 2, mapPos.Y - bodyPanel.Height / 2);
            bodyPanel.AutoScrollPosition = mapPosToCenter;
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

            showBiomesToolStripMenuItem.Checked = GlobalHelper.Config.Map.Biomes.IsShown;
            biomesOpacityToolStripTextBox.Text = $"{GlobalHelper.Config.Map.Biomes.Opacity}";


            showCitiesToolStripMenuItem.Checked = GlobalHelper.Config.Map.Cities.IsShown;
            citiesOpacityToolStripTextBox.Text = $"{GlobalHelper.Config.Map.Cities.Opacity}";

            showRadiationToolStripMenuItem.Checked = GlobalHelper.Config.Map.Radiation.IsShown;
            radiationOpacityToolStripTextBox.Text = $"{GlobalHelper.Config.Map.Radiation.Opacity}";

            this.Text = $@"{GlobalHelper.Config.Map.Name} - {GlobalHelper.Config.Map.Ip}:{GlobalHelper.Config.Map.Port}";

            sizeCellToolStripTextBox.Text = GlobalHelper.Config.Map.CellSize.ToString();
            sizeToolStripTextBox.Text = GlobalHelper.Config.Map.Size.ToString();

            ipToolStripTextBox.Text = GlobalHelper.Config.Map.Ip;
            portToolStripTextBox.Text = GlobalHelper.Config.Map.Port;

            isClearEveryNewRequestToolStripMenuItem.Checked = _logger.IsClearLogForEveryLog;

            foreach (var groupStripMenuItem in _groupStripMenuItems)
            {
                if (groupsToolStripMenuItem.DropDownItems.Contains(groupStripMenuItem))
                {
                    groupsToolStripMenuItem.DropDownItems.Remove(groupStripMenuItem);
                    groupStripMenuItem.Dispose();
                }
            }

            _groupStripMenuItems.Clear();

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
                    redrawExecuteTimer.Restart();
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

                        GlobalHelper.Config.Save();
                        UpdateUI();
                        redrawExecuteTimer.Restart();

                    }
                    groupPrefab.Dispose();
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
                    redrawExecuteTimer.Restart();
                };

                item.DropDownItems.Add(groupDelete);

                _groupStripMenuItems.Add(item);
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
            _gimmeCounter++;
            int timeToGimme;
            this.Text = _gimmeCounter.ToString();
            try
            {
                timeToGimme = Convert.ToInt32(gimmeDelayToolStripTextBox.Text) * 60;
            }
            catch
            {
                return;
            }
            if (_gimmeCounter < timeToGimme)
                return;
            SystemSounds.Exclamation.Play();
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

                LoadMapFolder(fbd.SelectedPath);
            }
        }


        private void LoadMapFolder(string path)
        {
            var mapName = Path.GetFileName(path);
            var hostsFile = Path.Combine(path, "hosts.txt");
            var worldDirectory = Path.Combine(path, "World");
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

            GlobalHelper.Config.Map = new Map()
            {
                Name = mapName
            };

            if (!GlobalHelper.Config.Maps.Contains(mapName))
            {                
                var item = new ToolStripMenuItem()
                {
                    Name = $"{mapName}ToolStripMenuItem",
                    Checked = false,
                    Text = mapName
                };
                item.Click += (o, args) =>
                {
                    LoadMapFolder(path);
                };
                loadToolStripMenuItem.DropDownItems.Add(item);
            }

            GlobalHelper.Config.Map.LoadPrefabs(prefabsFile, new XmlPrefabsMapLoader());
            GlobalHelper.Config.Map.LoadMapInfo(mapInfoFile);
            GlobalHelper.Config.Map.Ip = ip;
            GlobalHelper.Config.Map.Port = port;
            GlobalHelper.Config.Map.LoadSpawnPoints(spawnPointsFile);
            GlobalHelper.Config.Map.DirectoryPath = path;

            GlobalHelper.Config.Save();
            UpdateUI();
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
            redrawExecuteTimer.Restart();
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
                redrawExecuteTimer.Restart();
            }
            groupPrefabsForm.Dispose();
        }

        private void spawnPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalHelper.Config.Map.SpawnPoints.IsEnabled = !GlobalHelper.Config.Map.SpawnPoints.IsEnabled;
            spawnPointsToolStripMenuItem.Checked = GlobalHelper.Config.Map.SpawnPoints.IsEnabled;
            GlobalHelper.Config.Save();
            redrawExecuteTimer.Restart();
        }

        private void showBiomesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalHelper.Config.Map.Biomes.IsShown = !GlobalHelper.Config.Map.Biomes.IsShown;
            showBiomesToolStripMenuItem.Checked = GlobalHelper.Config.Map.Biomes.IsShown;
            redrawExecuteTimer.Restart();
        }

        private void showRadiationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalHelper.Config.Map.Radiation.IsShown = !GlobalHelper.Config.Map.Radiation.IsShown;
            showRadiationToolStripMenuItem.Checked = GlobalHelper.Config.Map.Radiation.IsShown;
            redrawExecuteTimer.Restart();
        }


        private void coordsToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GlobalHelper.MyCoordinates.Name = "I AM HERE";
                var text = coordsToolStripTextBox.Text.Split(';');
                var ySN = text[0][text[0].Length - 1];
                var yText = Convert.ToInt32(text[0].Substring(0, text[0].Length - 1));

                var xWE = text[1][text[1].Length - 1];
                var xText = Convert.ToInt32(text[1].Substring(0, text[1].Length - 1));
                if (ySN == 'S')
                {
                    GlobalHelper.MyCoordinates.Y = -1 * yText;
                }
                else if (ySN == 'N')
                {
                    GlobalHelper.MyCoordinates.Y = yText;
                }

                if (xWE == 'W')
                {
                    GlobalHelper.MyCoordinates.X = -1 * xText;
                }
                else if (xWE == 'E')
                {
                    GlobalHelper.MyCoordinates.X = xText;
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

            redrawExecuteTimer.Restart();
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
                redrawExecuteTimer.Restart();
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
            redrawExecuteTimer.Restart();
        }

        private void positionReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectCoordinatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var info = new ProcessStartInfo
            {
                FileName = "regedit.exe",
                Arguments = $"/s ABBYY_FineReader/license.reg",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                Verb = "runas"
            };
            using (var ps = Process.Start(info))
            {
                ps.StartInfo.Verb = "runas";
                ps.WaitForExit();
                var exitCode = ps.ExitCode;
                if (exitCode == 0)
                {
                    var positionReaderForm = new PositionReaderForm();
                    var dlgRes = positionReaderForm.ShowDialog(this);
                    if (dlgRes == DialogResult.OK)
                    {
                        GlobalHelper.Config.CoordinatesRectangle = positionReaderForm.Result;
                    }
                }
                else
                {
                    var stderr = ps.StandardError.ReadToEnd();
                    throw new InvalidOperationException(stderr);
                }
            }
        }


        public string GetTextByScreen()
        {
            var filename = $"crop.png";
            var snapshot = SnapShotService.TakeWindowScreen(0, "7DaysToDie");

            var image = snapshot.CropAtRect(GlobalHelper.Config.CoordinatesRectangle);
            image.Save(filename);
            var service = new FineReaderService(@"ABBYY_FineReader", "english", @"Clipboard");

            var res = service.GetText(filename);
            return res;
        }


        public string GetCoordinatesByText(string text)
        {
            var numberCollection = "0123456789";
            var charsCollection = "snewSNEW";
            var res = "" + new string(text.Where(c => numberCollection.Contains(c) || charsCollection.Contains(c)).ToArray());

            res = res.Replace("s", "S")
                .Replace("n", "N")
                .Replace("e", "E")
                .Replace("w", "W")
                .Replace("E", "E;")
                .Replace("W", "W;");

            var split = res.Split(';');
            if (split.Length < 2 || split[0].Contains("N") || split[0].Contains("D") || split[1].Contains("E") || split[1].Contains("W") || split[0].Length < 2 || split[1].Length < 2)
            {
                return "";
            }

            return $"{split[1]};{split[0]}";
        }

        public void DrawMeOnMap()
        {
            if (GlobalHelper.Config.CoordinatesRectangle.X <= 0 || GlobalHelper.Config.CoordinatesRectangle.Y <= 0)
            {
                return;
            }

            this.WindowState = FormWindowState.Minimized;
            this.TopMost = false;
            var text = GetTextByScreen();
            text = GetCoordinatesByText(text);
            if (text == "")
            {
                return;
            }

            coordsToolStripTextBox.Text = text;
            redrawExecuteTimer.Restart();



            this.TopMost = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void drawOnMapALTMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawMeOnMap();
        }

        private void HelperForm_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.30;
        }

        private void HelperForm_Activated(object sender, EventArgs e)
        {
            this.Opacity = 0.90;

        }

        private Point GetMapCenterGameCoordinates()
        {
            int pictureBoxX0 = mapPictureBox.Width / 2;
            int pictureBoxY0 = mapPictureBox.Height / 2;
            var mapCenter = new Point(pictureBoxX0, pictureBoxY0);
            var formCenter = new Point(bodyPanel.Width / 2, bodyPanel.Height / 2);

            var topLeftPoint = new Point(Math.Abs(bodyPanel.AutoScrollPosition.X),
                Math.Abs(bodyPanel.AutoScrollPosition.Y));


            var centerPoint = new Point(topLeftPoint.X + formCenter.X, topLeftPoint.Y + formCenter.Y);

            var gamePoint = GetGamePosByMapPos(centerPoint, mapCenter);

            return gamePoint;
        }

        private Point GetMapTopLeftGameCoordinates()
        {
            int pictureBoxX0 = mapPictureBox.Width / 2;
            int pictureBoxY0 = mapPictureBox.Height / 2;
            var mapCenter = new Point(pictureBoxX0, pictureBoxY0);

            var topLeftPoint = new Point(Math.Abs(bodyPanel.AutoScrollPosition.X),
                Math.Abs(bodyPanel.AutoScrollPosition.Y));

            var gamePoint = GetGamePosByMapPos(topLeftPoint, mapCenter);

            return gamePoint;
        }

        private void redrawExecuteTimer_Tick(object sender, EventArgs e)
        {
            redrawExecuteTimer.Stop();
            GlobalHelper.Config.CurrentMapCenterGameCoordinates = GetMapCenterGameCoordinates();

            GlobalHelper.Config.Map.Scale = (int)Math.Pow(2, mapSacleTrackBar.Value);
            var scaled = GlobalHelper.Config.Map.Size / GlobalHelper.Config.Map.Scale;
            mapPictureBox.Height = scaled;
            mapPictureBox.Width = scaled;

            RedrawMap();
        }

        private void showCitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalHelper.Config.Map.Cities.IsShown = !GlobalHelper.Config.Map.Cities.IsShown;
            showCitiesToolStripMenuItem.Checked = GlobalHelper.Config.Map.Cities.IsShown;
            redrawExecuteTimer.Restart();
        }

        private void citiesOpacityToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var opacity = Convert.ToInt32(citiesOpacityToolStripTextBox.Text);
                GlobalHelper.Config.Map.Cities.Opacity = opacity;
                redrawExecuteTimer.Restart();
            }
            catch
            {
                // ignored
            }
        }

        private void biomesOpacityToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var opacity = Convert.ToInt32(biomesOpacityToolStripTextBox.Text);
                GlobalHelper.Config.Map.Biomes.Opacity = opacity;
                redrawExecuteTimer.Restart();
            }
            catch
            {
                // ignored
            }
        }

        private void radiationOpacityToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var opacity = Convert.ToInt32(radiationOpacityToolStripTextBox.Text);
                GlobalHelper.Config.Map.Radiation.Opacity = opacity;
                redrawExecuteTimer.Restart();
            }
            catch
            {
                // ignored
            }
        }


        private void lmbDelayToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var lmbDelay = Convert.ToInt32(lmbDelayToolStripTextBox.Text);
                _automationConfig.LmbClick.Delay = lmbDelay;
            }
            catch
            {
                // ignore
            }
        }

        private void rmbDelayToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rmbDelay = Convert.ToInt32(rmbDelayToolStripTextBox.Text);
                _automationConfig.RmbClick.Delay = rmbDelay;
            }
            catch
            {
                // ignore
            }
        }

        private void serverAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a2SInfo = ValveMonitoring.ValveMonitoring.GetA2S_INFO(ipToolStripTextBox.Text, portToolStripTextBox.Text, out var data);
            if (a2SInfo == null)
                return;

            var res = a2SInfo.GetText();

            _logger.Log(res);
        }

        private void serverStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = ValveMonitoring.ValveMonitoring.GetServerStats(ipToolStripTextBox.Text, portToolStripTextBox.Text, out var data);

            _logger.Log(res);
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadToolStripMenuItem.Checked = !loadToolStripMenuItem.Checked;
            logPanel.Visible = loadToolStripMenuItem.Checked;
        }

        private void isClearEveryNewRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isClearEveryNewRequestToolStripMenuItem.Checked = !isClearEveryNewRequestToolStripMenuItem.Checked;

            _logger.IsClearLogForEveryLog = isClearEveryNewRequestToolStripMenuItem.Checked;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logger.Clear();
        }

        private void checkPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkPlayersToolStripMenuItem.Checked = !checkPlayersToolStripMenuItem.Checked;
            checkServerPlayersTimer.Enabled = checkPlayersToolStripMenuItem.Checked;
        }

        private void checkServerPlayersTimer_Tick(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                var a2sInfo = ValveMonitoring.ValveMonitoring.GetA2S_INFO(ipToolStripTextBox.Text, portToolStripTextBox.Text, out var data);
                if (a2sInfo == null)
                    return;

                Invoke(new Action(() =>
                {
                    var res = a2sInfo.GetText();
                    _logger.Log(res);

                    var n = 0;
                    try
                    {
                        n = Convert.ToInt32(checkNToolStripTextBox.Text);
                    }
                    catch { }
                    switch (typeCheckToolStripComboBox.SelectedIndex)
                    {
                        case 0:
                            {
                                if (a2sInfo.Players < a2sInfo.MaxPlayers)
                                    Console.Beep(5000, 300);
                                break;
                            }
                        case 1:
                            {
                                if (a2sInfo.Players < a2sInfo.MaxPlayers - n)
                                    Console.Beep(5000, 300);
                                break;
                            }
                        case 2:
                            {
                                if (a2sInfo.Players < n)
                                    Console.Beep(5000, 300);
                                break;
                            }
                        case 3:
                            {
                                if (a2sInfo.Players > n)
                                    Console.Beep(5000, 300);
                                break;
                            }
                    }
                }));
            }).Start();
        }

        private void checkPlayersDelayToolStripTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                var delay = Convert.ToInt32(checkPlayersDelayToolStripTextBox.Text);
                checkServerPlayersTimer.Interval = delay;
            }
            catch
            {
                // ignore
            }
        }

        private void getDayTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getDayTimeToolStripMenuItem.Checked = !getDayTimeToolStripMenuItem.Checked;
            serverStatsTimer.Enabled = getDayTimeToolStripMenuItem.Checked;
        }

        private void getDayTimeDelayToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var delay = Convert.ToInt32(getDayTimeDelayToolStripTextBox.Text);
                serverStatsTimer.Interval = delay;
            }
            catch
            {
                // ignore
            }
        }

        private void serverStatsTimer_Tick(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                var res = ValveMonitoring.ValveMonitoring.GetServerStats(ipToolStripTextBox.Text, portToolStripTextBox.Text, out _);
                if (res == "ERROR")
                    return;
                var timeStr = res.Replace("\r", "").Split('\n').Single(str => str.Contains("CurrentServerTime"))
                    .Split(':')[1];
                var time = int.Parse(timeStr);
                var day = time / 24000 + 1;
                var hour = (time % 24000) / 1000;
                var mins = ((time % 1000) * 60) / 1000;



                Invoke(new Action(() =>
                {
                    _logger.Log($"{day} {hour} {mins}");


                    if (!beepIfDayToolStripMenuItem.Checked && !beepIfTimeToolStripMenuItem.Checked)
                    {
                        return;
                    }
                    int frequency;
                    int duration;

                    try
                    {
                        frequency = Convert.ToInt32(beepFreqyencyToolStripTextBox.Text);
                    }
                    catch
                    {
                        frequency = 5000;
                        _logger.Log($"Could not parse frequency");
                    }

                    try
                    {
                        duration = Convert.ToInt32(beepDurationToolStripTextBox.Text);
                    }
                    catch
                    {
                        duration = 300;
                        _logger.Log($"Could not parse duration");
                    }

                    try
                    {

                        if (beepIfDayToolStripMenuItem.Checked)
                        {
                            var n = Convert.ToInt32(beepIfDayNToolStripTextBox.Text);
                            switch (beepIfDayToolStripComboBox.SelectedIndex)
                            {
                                // day == N
                                case 0:
                                    {
                                        if (day == n)
                                        {
                                            Console.Beep(frequency, duration);
                                        }

                                        break;
                                    }
                                // day + K % N == 0
                                default:
                                    {
                                        var k = Convert.ToInt32(beepIfDayKToolStripTextBox.Text);

                                        if ((day + k) % n == 0)
                                        {
                                            Console.Beep(frequency, duration);
                                        }

                                        break;
                                    }
                            }
                        }

                        if (beepIfTimeToolStripMenuItem.Checked)
                        {
                            var n = Convert.ToInt32(beepIfTimeNToolStripTextBox.Text);
                            var k = Convert.ToInt32(beepIfTimeKToolStripTextBox.Text);

                            if (n <= hour && hour < k)
                            {
                                Console.Beep(frequency, duration);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Log(ex.ToString(), ex.Message);
                    }

                }));
            }).Start();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int frequency;
            int duration;

            try
            {
                frequency = Convert.ToInt32(beepFreqyencyToolStripTextBox.TextBox);
            }
            catch
            {
                frequency = 5000;
            }

            try
            {
                duration = Convert.ToInt32(beepDurationToolStripTextBox.TextBox);
            }
            catch
            {
                duration = 300;
            }

            Console.Beep(frequency, duration);
        }

        private void beepIfDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beepIfDayToolStripMenuItem.Checked = !beepIfDayToolStripMenuItem.Checked;
        }

        private void beepIfTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beepIfTimeToolStripMenuItem.Checked = !beepIfTimeToolStripMenuItem.Checked;
        }
    }
}
