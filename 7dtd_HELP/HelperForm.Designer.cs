namespace _7dtd_HELP
{
    partial class HelperForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gimmeTimer = new System.Windows.Forms.Timer(this.components);
            this.infinityTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.automationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gimmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atouseGimmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gimmeDelayToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.pressLeftKeyALTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepRMBALTNUMPAD1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefabsXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.sizeCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeCellToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.updatePerfarbsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawOnMapALTMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBiomesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllPrefabIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spawnPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setIconSpawnPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSpawnPointsBrushColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spawnPointsBrushSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spawnPointsBrushSizeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.delimiterToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.coordinates7dtdToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.coordsToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.subStatusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.subStatusToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.mapSacleTrackBar = new System.Windows.Forms.TrackBar();
            this.toolTipPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerScaleChanged = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.showCitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.bodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapSacleTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // gimmeTimer
            // 
            this.gimmeTimer.Interval = 1000;
            this.gimmeTimer.Tick += new System.EventHandler(this.gimmeTimer_Tick);
            // 
            // infinityTimer
            // 
            this.infinityTimer.Enabled = true;
            this.infinityTimer.Interval = 1;
            this.infinityTimer.Tick += new System.EventHandler(this.timerInfinity_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automationToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.groupsToolStripMenuItem,
            this.coordinates7dtdToolStripTextBox,
            this.coordsToolStripTextBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(645, 31);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // automationToolStripMenuItem
            // 
            this.automationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gimmeToolStripMenuItem,
            this.pressLeftKeyALTToolStripMenuItem,
            this.keepRMBALTNUMPAD1ToolStripMenuItem});
            this.automationToolStripMenuItem.Name = "automationToolStripMenuItem";
            this.automationToolStripMenuItem.Size = new System.Drawing.Size(100, 27);
            this.automationToolStripMenuItem.Text = "Automation";
            // 
            // gimmeToolStripMenuItem
            // 
            this.gimmeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotkeyToolStripMenuItem,
            this.atouseGimmeToolStripMenuItem});
            this.gimmeToolStripMenuItem.Name = "gimmeToolStripMenuItem";
            this.gimmeToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.gimmeToolStripMenuItem.Text = "Gimme";
            // 
            // hotkeyToolStripMenuItem
            // 
            this.hotkeyToolStripMenuItem.Name = "hotkeyToolStripMenuItem";
            this.hotkeyToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.hotkeyToolStripMenuItem.Text = "Hotkey ALT+NumPad0";
            // 
            // atouseGimmeToolStripMenuItem
            // 
            this.atouseGimmeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gimmeDelayToolStripTextBox});
            this.atouseGimmeToolStripMenuItem.Name = "atouseGimmeToolStripMenuItem";
            this.atouseGimmeToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.atouseGimmeToolStripMenuItem.Text = "Delay  ALT+NumPad3";
            // 
            // gimmeDelayToolStripTextBox
            // 
            this.gimmeDelayToolStripTextBox.Name = "gimmeDelayToolStripTextBox";
            this.gimmeDelayToolStripTextBox.Size = new System.Drawing.Size(100, 27);
            this.gimmeDelayToolStripTextBox.Text = "60";
            this.gimmeDelayToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pressLeftKeyALTToolStripMenuItem
            // 
            this.pressLeftKeyALTToolStripMenuItem.Name = "pressLeftKeyALTToolStripMenuItem";
            this.pressLeftKeyALTToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.pressLeftKeyALTToolStripMenuItem.Text = "Keep LMB ALT+NUMPAD1";
            // 
            // keepRMBALTNUMPAD1ToolStripMenuItem
            // 
            this.keepRMBALTNUMPAD1ToolStripMenuItem.Name = "keepRMBALTNUMPAD1ToolStripMenuItem";
            this.keepRMBALTNUMPAD1ToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.keepRMBALTNUMPAD1ToolStripMenuItem.Text = "Keep RMB ALT+NUMPAD1";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.sizeCellToolStripMenuItem,
            this.updatePerfarbsToolStripMenuItem,
            this.positionReaderToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(51, 27);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prefabsXMLToolStripMenuItem,
            this.toolStripMenuItem1});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // prefabsXMLToolStripMenuItem
            // 
            this.prefabsXMLToolStripMenuItem.Name = "prefabsXMLToolStripMenuItem";
            this.prefabsXMLToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.prefabsXMLToolStripMenuItem.Text = "mapFolder";
            this.prefabsXMLToolStripMenuItem.Click += new System.EventHandler(this.mapFolderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripTextBox});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // sizeToolStripTextBox
            // 
            this.sizeToolStripTextBox.Name = "sizeToolStripTextBox";
            this.sizeToolStripTextBox.Size = new System.Drawing.Size(100, 27);
            this.sizeToolStripTextBox.Text = "3072";
            this.sizeToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sizeToolStripTextBox.TextChanged += new System.EventHandler(this.sizeToolStripTextBox_TextChanged);
            // 
            // sizeCellToolStripMenuItem
            // 
            this.sizeCellToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeCellToolStripTextBox});
            this.sizeCellToolStripMenuItem.Name = "sizeCellToolStripMenuItem";
            this.sizeCellToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.sizeCellToolStripMenuItem.Text = "SizeCell";
            // 
            // sizeCellToolStripTextBox
            // 
            this.sizeCellToolStripTextBox.Name = "sizeCellToolStripTextBox";
            this.sizeCellToolStripTextBox.Size = new System.Drawing.Size(100, 27);
            this.sizeCellToolStripTextBox.Text = "50";
            this.sizeCellToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sizeCellToolStripTextBox.TextChanged += new System.EventHandler(this.sizeCellToolStripTextBox_TextChanged);
            // 
            // updatePerfarbsToolStripMenuItem
            // 
            this.updatePerfarbsToolStripMenuItem.Name = "updatePerfarbsToolStripMenuItem";
            this.updatePerfarbsToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.updatePerfarbsToolStripMenuItem.Text = "UpdatePrefabs";
            this.updatePerfarbsToolStripMenuItem.Click += new System.EventHandler(this.updatePrefabsToolStripMenuItem_Click);
            // 
            // positionReaderToolStripMenuItem
            // 
            this.positionReaderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectCoordinatesToolStripMenuItem,
            this.drawOnMapALTMToolStripMenuItem});
            this.positionReaderToolStripMenuItem.Name = "positionReaderToolStripMenuItem";
            this.positionReaderToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.positionReaderToolStripMenuItem.Text = "PositionReader";
            this.positionReaderToolStripMenuItem.Click += new System.EventHandler(this.positionReaderToolStripMenuItem_Click);
            // 
            // selectCoordinatesToolStripMenuItem
            // 
            this.selectCoordinatesToolStripMenuItem.Name = "selectCoordinatesToolStripMenuItem";
            this.selectCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.selectCoordinatesToolStripMenuItem.Text = "SelectCoordinates";
            this.selectCoordinatesToolStripMenuItem.Click += new System.EventHandler(this.selectCoordinatesToolStripMenuItem_Click);
            // 
            // drawOnMapALTMToolStripMenuItem
            // 
            this.drawOnMapALTMToolStripMenuItem.Name = "drawOnMapALTMToolStripMenuItem";
            this.drawOnMapALTMToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.drawOnMapALTMToolStripMenuItem.Text = "DrawOnMap ALT+NUMPAD4";
            this.drawOnMapALTMToolStripMenuItem.Click += new System.EventHandler(this.drawOnMapALTMToolStripMenuItem_Click);
            // 
            // groupsToolStripMenuItem
            // 
            this.groupsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGroupToolStripMenuItem,
            this.showCitiesToolStripMenuItem,
            this.showBiomesToolStripMenuItem,
            this.showAllPrefabIconsToolStripMenuItem,
            this.spawnPointsToolStripMenuItem,
            this.delimiterToolStripMenuItem});
            this.groupsToolStripMenuItem.Name = "groupsToolStripMenuItem";
            this.groupsToolStripMenuItem.Size = new System.Drawing.Size(95, 27);
            this.groupsToolStripMenuItem.Text = "Map shows";
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.addGroupToolStripMenuItem.Text = "Add Group";
            this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.addGroupToolStripMenuItem_Click);
            // 
            // showBiomesToolStripMenuItem
            // 
            this.showBiomesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.showBiomesToolStripMenuItem.Name = "showBiomesToolStripMenuItem";
            this.showBiomesToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.showBiomesToolStripMenuItem.Text = "ShowBiomes";
            this.showBiomesToolStripMenuItem.Click += new System.EventHandler(this.showBiomesToolStripMenuItem_Click);
            // 
            // showAllPrefabIconsToolStripMenuItem
            // 
            this.showAllPrefabIconsToolStripMenuItem.Name = "showAllPrefabIconsToolStripMenuItem";
            this.showAllPrefabIconsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.showAllPrefabIconsToolStripMenuItem.Text = "ShowAllPrefabIcons";
            this.showAllPrefabIconsToolStripMenuItem.Click += new System.EventHandler(this.showAllPrefabIconsToolStripMenuItem_Click);
            // 
            // spawnPointsToolStripMenuItem
            // 
            this.spawnPointsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setIconSpawnPointsToolStripMenuItem,
            this.setSpawnPointsBrushColorToolStripMenuItem,
            this.spawnPointsBrushSizeToolStripMenuItem});
            this.spawnPointsToolStripMenuItem.Name = "spawnPointsToolStripMenuItem";
            this.spawnPointsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.spawnPointsToolStripMenuItem.Text = "Spawn Points";
            this.spawnPointsToolStripMenuItem.Click += new System.EventHandler(this.spawnPointsToolStripMenuItem_Click);
            // 
            // setIconSpawnPointsToolStripMenuItem
            // 
            this.setIconSpawnPointsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setIconSpawnPointsToolStripMenuItem.Name = "setIconSpawnPointsToolStripMenuItem";
            this.setIconSpawnPointsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.setIconSpawnPointsToolStripMenuItem.Text = "SetIcon";
            this.setIconSpawnPointsToolStripMenuItem.Click += new System.EventHandler(this.setIconSpawnPointsToolStripMenuItem_Click);
            // 
            // setSpawnPointsBrushColorToolStripMenuItem
            // 
            this.setSpawnPointsBrushColorToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setSpawnPointsBrushColorToolStripMenuItem.Name = "setSpawnPointsBrushColorToolStripMenuItem";
            this.setSpawnPointsBrushColorToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.setSpawnPointsBrushColorToolStripMenuItem.Text = "SetBrushColor";
            this.setSpawnPointsBrushColorToolStripMenuItem.Click += new System.EventHandler(this.setSpawnPointsBrushColorToolStripMenuItem_Click);
            // 
            // spawnPointsBrushSizeToolStripMenuItem
            // 
            this.spawnPointsBrushSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spawnPointsBrushSizeToolStripTextBox});
            this.spawnPointsBrushSizeToolStripMenuItem.Name = "spawnPointsBrushSizeToolStripMenuItem";
            this.spawnPointsBrushSizeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.spawnPointsBrushSizeToolStripMenuItem.Text = "BrushSize";
            // 
            // spawnPointsBrushSizeToolStripTextBox
            // 
            this.spawnPointsBrushSizeToolStripTextBox.Name = "spawnPointsBrushSizeToolStripTextBox";
            this.spawnPointsBrushSizeToolStripTextBox.Size = new System.Drawing.Size(100, 27);
            this.spawnPointsBrushSizeToolStripTextBox.TextChanged += new System.EventHandler(this.spawnPointsBrushSizeToolStripTextBox_TextChanged);
            // 
            // delimiterToolStripMenuItem
            // 
            this.delimiterToolStripMenuItem.Name = "delimiterToolStripMenuItem";
            this.delimiterToolStripMenuItem.Size = new System.Drawing.Size(213, 6);
            // 
            // coordinates7dtdToolStripTextBox
            // 
            this.coordinates7dtdToolStripTextBox.Name = "coordinates7dtdToolStripTextBox";
            this.coordinates7dtdToolStripTextBox.ReadOnly = true;
            this.coordinates7dtdToolStripTextBox.Size = new System.Drawing.Size(100, 27);
            // 
            // coordsToolStripTextBox
            // 
            this.coordsToolStripTextBox.Name = "coordsToolStripTextBox";
            this.coordsToolStripTextBox.Size = new System.Drawing.Size(100, 27);
            this.coordsToolStripTextBox.TextChanged += new System.EventHandler(this.coordsToolStripTextBox_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.statusToolStripProgressBar,
            this.subStatusToolStripStatusLabel,
            this.subStatusToolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(56, 543);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 24);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusToolStripStatusLabel
            // 
            this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
            this.statusToolStripStatusLabel.Size = new System.Drawing.Size(0, 19);
            // 
            // statusToolStripProgressBar
            // 
            this.statusToolStripProgressBar.Name = "statusToolStripProgressBar";
            this.statusToolStripProgressBar.Size = new System.Drawing.Size(100, 18);
            // 
            // subStatusToolStripStatusLabel
            // 
            this.subStatusToolStripStatusLabel.Name = "subStatusToolStripStatusLabel";
            this.subStatusToolStripStatusLabel.Size = new System.Drawing.Size(0, 19);
            // 
            // subStatusToolStripProgressBar
            // 
            this.subStatusToolStripProgressBar.Name = "subStatusToolStripProgressBar";
            this.subStatusToolStripProgressBar.Size = new System.Drawing.Size(100, 18);
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.mapPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mapPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(6144, 6144);
            this.mapPictureBox.TabIndex = 35;
            this.mapPictureBox.TabStop = false;
            // 
            // bodyPanel
            // 
            this.bodyPanel.AutoScroll = true;
            this.bodyPanel.BackColor = System.Drawing.Color.DimGray;
            this.bodyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bodyPanel.Controls.Add(this.mapPictureBox);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(56, 31);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(589, 512);
            this.bodyPanel.TabIndex = 36;
            // 
            // mapSacleTrackBar
            // 
            this.mapSacleTrackBar.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.mapSacleTrackBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.mapSacleTrackBar.Enabled = false;
            this.mapSacleTrackBar.LargeChange = 1;
            this.mapSacleTrackBar.Location = new System.Drawing.Point(0, 31);
            this.mapSacleTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.mapSacleTrackBar.Maximum = 4;
            this.mapSacleTrackBar.Name = "mapSacleTrackBar";
            this.mapSacleTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.mapSacleTrackBar.Size = new System.Drawing.Size(56, 536);
            this.mapSacleTrackBar.TabIndex = 33;
            this.mapSacleTrackBar.ValueChanged += new System.EventHandler(this.mapSacleTrackBar_ValueChanged);
            // 
            // toolTipPanel
            // 
            this.toolTipPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolTipPanel.AutoScroll = true;
            this.toolTipPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolTipPanel.Location = new System.Drawing.Point(424, 30);
            this.toolTipPanel.Name = "toolTipPanel";
            this.toolTipPanel.Size = new System.Drawing.Size(200, 142);
            this.toolTipPanel.TabIndex = 37;
            this.toolTipPanel.Visible = false;
            // 
            // timerScaleChanged
            // 
            this.timerScaleChanged.Interval = 500;
            this.timerScaleChanged.Tick += new System.EventHandler(this.timerScaleChanged_Tick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(216, 26);
            this.toolStripMenuItem2.Text = "Opacity";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox1.Text = "100";
            // 
            // showCitiesToolStripMenuItem
            // 
            this.showCitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.showCitiesToolStripMenuItem.Name = "showCitiesToolStripMenuItem";
            this.showCitiesToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.showCitiesToolStripMenuItem.Text = "ShowCities";
            this.showCitiesToolStripMenuItem.Click += new System.EventHandler(this.showCitiesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(216, 26);
            this.toolStripMenuItem4.Text = "Opacity";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox2.Text = "100";
            // 
            // HelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(645, 567);
            this.Controls.Add(this.toolTipPanel);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mapSacleTrackBar);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HelperForm";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "3600";
            this.Activated += new System.EventHandler(this.HelperForm_Activated);
            this.Deactivate += new System.EventHandler(this.HelperForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HelperForm_FormClosing);
            this.Load += new System.EventHandler(this.HelperForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HelperForm_MouseDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.bodyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapSacleTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gimmeTimer;
        private System.Windows.Forms.Timer infinityTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox sizeToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem sizeCellToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox sizeCellToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem prefabsXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePerfarbsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gimmeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar statusToolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem hotkeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atouseGimmeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox gimmeDelayToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator delimiterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spawnPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBiomesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel subStatusToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar subStatusToolStripProgressBar;
        private System.Windows.Forms.ToolStripTextBox coordinates7dtdToolStripTextBox;
        private System.Windows.Forms.ToolStripTextBox coordsToolStripTextBox;
        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.TrackBar mapSacleTrackBar;
        private System.Windows.Forms.ToolStripMenuItem setIconSpawnPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setSpawnPointsBrushColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spawnPointsBrushSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox spawnPointsBrushSizeToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem showAllPrefabIconsToolStripMenuItem;
        private System.Windows.Forms.Panel toolTipPanel;
        private System.Windows.Forms.ToolStripMenuItem positionReaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectCoordinatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pressLeftKeyALTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepRMBALTNUMPAD1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawOnMapALTMToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerScaleChanged;
        private System.Windows.Forms.ToolStripMenuItem showCitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}

