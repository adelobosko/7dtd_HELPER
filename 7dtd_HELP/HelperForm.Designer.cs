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
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefabsXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.sizeCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeCellToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.updatePerfarbsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coordinatesToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.groupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapSacleTrackBar = new System.Windows.Forms.TrackBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapSacleTrackBar)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            this.coordinatesToolStripTextBox,
            this.groupsToolStripMenuItem});
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
            this.gimmeToolStripMenuItem});
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
            this.gimmeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.gimmeToolStripMenuItem.Text = "Gimme";
            // 
            // hotkeyToolStripMenuItem
            // 
            this.hotkeyToolStripMenuItem.Name = "hotkeyToolStripMenuItem";
            this.hotkeyToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.hotkeyToolStripMenuItem.Text = "Hotkey NumPad0";
            // 
            // atouseGimmeToolStripMenuItem
            // 
            this.atouseGimmeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gimmeDelayToolStripTextBox});
            this.atouseGimmeToolStripMenuItem.Name = "atouseGimmeToolStripMenuItem";
            this.atouseGimmeToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.atouseGimmeToolStripMenuItem.Text = "Delay NumPad3";
            // 
            // gimmeDelayToolStripTextBox
            // 
            this.gimmeDelayToolStripTextBox.Name = "gimmeDelayToolStripTextBox";
            this.gimmeDelayToolStripTextBox.Size = new System.Drawing.Size(100, 27);
            this.gimmeDelayToolStripTextBox.Text = "60";
            this.gimmeDelayToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.sizeCellToolStripMenuItem,
            this.updatePerfarbsToolStripMenuItem});
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
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // prefabsXMLToolStripMenuItem
            // 
            this.prefabsXMLToolStripMenuItem.Name = "prefabsXMLToolStripMenuItem";
            this.prefabsXMLToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.prefabsXMLToolStripMenuItem.Text = "mapFolder";
            this.prefabsXMLToolStripMenuItem.Click += new System.EventHandler(this.mapFolderToolStripMenuItem_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleToolStripTextBox});
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.scaleToolStripMenuItem.Text = "Scale";
            // 
            // scaleToolStripTextBox
            // 
            this.scaleToolStripTextBox.Name = "scaleToolStripTextBox";
            this.scaleToolStripTextBox.Size = new System.Drawing.Size(100, 27);
            this.scaleToolStripTextBox.Text = "10";
            this.scaleToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.scaleToolStripTextBox.TextChanged += new System.EventHandler(this.scaleToolStripTextBox_TextChanged);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripTextBox});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
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
            this.sizeCellToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
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
            this.updatePerfarbsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.updatePerfarbsToolStripMenuItem.Text = "UpdatePrefabs";
            this.updatePerfarbsToolStripMenuItem.Click += new System.EventHandler(this.updatePrefabsToolStripMenuItem_Click);
            // 
            // coordinatesToolStripTextBox
            // 
            this.coordinatesToolStripTextBox.Name = "coordinatesToolStripTextBox";
            this.coordinatesToolStripTextBox.ReadOnly = true;
            this.coordinatesToolStripTextBox.Size = new System.Drawing.Size(132, 27);
            // 
            // groupsToolStripMenuItem
            // 
            this.groupsToolStripMenuItem.Name = "groupsToolStripMenuItem";
            this.groupsToolStripMenuItem.Size = new System.Drawing.Size(68, 27);
            this.groupsToolStripMenuItem.Text = "Groups";
            // 
            // mapSacleTrackBar
            // 
            this.mapSacleTrackBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.mapSacleTrackBar.Location = new System.Drawing.Point(0, 31);
            this.mapSacleTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.mapSacleTrackBar.Maximum = 20;
            this.mapSacleTrackBar.Minimum = 1;
            this.mapSacleTrackBar.Name = "mapSacleTrackBar";
            this.mapSacleTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.mapSacleTrackBar.Size = new System.Drawing.Size(56, 536);
            this.mapSacleTrackBar.TabIndex = 33;
            this.mapSacleTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.mapSacleTrackBar.Value = 10;
            this.mapSacleTrackBar.ValueChanged += new System.EventHandler(this.mapSacleTrackBar_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.statusToolStripProgressBar});
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // HelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(645, 567);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mapSacleTrackBar);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HelperForm";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "3600";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HelperForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.HelperForm_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HelperForm_MouseDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapSacleTrackBar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gimmeTimer;
        private System.Windows.Forms.Timer infinityTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox scaleToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox sizeToolStripTextBox;
        private System.Windows.Forms.TrackBar mapSacleTrackBar;
        private System.Windows.Forms.ToolStripMenuItem sizeCellToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox sizeCellToolStripTextBox;
        private System.Windows.Forms.ToolStripTextBox coordinatesToolStripTextBox;
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
    }
}

