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
            this.gimmeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefabsXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.sizeCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeCellToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.coordinatesToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.perfabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settlementtrader01ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settlementtrader02ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settlementtrader03ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settlementtrader04ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armybarracks01ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storebooksm01ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storebooklg01ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapSacleTrackBar = new System.Windows.Forms.TrackBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gimmeToolStripTextBox,
            this.mapToolStripMenuItem,
            this.coordinatesToolStripTextBox,
            this.perfabsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 27);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gimmeToolStripTextBox
            // 
            this.gimmeToolStripTextBox.Name = "gimmeToolStripTextBox";
            this.gimmeToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.gimmeToolStripTextBox.Text = "60";
            this.gimmeToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.sizeCellToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 23);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prefabsXMLToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // prefabsXMLToolStripMenuItem
            // 
            this.prefabsXMLToolStripMenuItem.Name = "prefabsXMLToolStripMenuItem";
            this.prefabsXMLToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.prefabsXMLToolStripMenuItem.Text = "prefabsXML";
            this.prefabsXMLToolStripMenuItem.Click += new System.EventHandler(this.prefabsXMLToolStripMenuItem_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleToolStripTextBox});
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.scaleToolStripMenuItem.Text = "Scale";
            // 
            // scaleToolStripTextBox
            // 
            this.scaleToolStripTextBox.Name = "scaleToolStripTextBox";
            this.scaleToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.scaleToolStripTextBox.Text = "10";
            this.scaleToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.scaleToolStripTextBox.TextChanged += new System.EventHandler(this.scaleToolStripTextBox_TextChanged);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripTextBox});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // sizeToolStripTextBox
            // 
            this.sizeToolStripTextBox.Name = "sizeToolStripTextBox";
            this.sizeToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.sizeToolStripTextBox.Text = "3072";
            this.sizeToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sizeToolStripTextBox.TextChanged += new System.EventHandler(this.sizeToolStripTextBox_TextChanged);
            // 
            // sizeCellToolStripMenuItem
            // 
            this.sizeCellToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeCellToolStripTextBox});
            this.sizeCellToolStripMenuItem.Name = "sizeCellToolStripMenuItem";
            this.sizeCellToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sizeCellToolStripMenuItem.Text = "SizeCell";
            // 
            // sizeCellToolStripTextBox
            // 
            this.sizeCellToolStripTextBox.Name = "sizeCellToolStripTextBox";
            this.sizeCellToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.sizeCellToolStripTextBox.Text = "50";
            this.sizeCellToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sizeCellToolStripTextBox.TextChanged += new System.EventHandler(this.sizeCellToolStripTextBox_TextChanged);
            // 
            // coordinatesToolStripTextBox
            // 
            this.coordinatesToolStripTextBox.Name = "coordinatesToolStripTextBox";
            this.coordinatesToolStripTextBox.ReadOnly = true;
            this.coordinatesToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // perfabsToolStripMenuItem
            // 
            this.perfabsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settlementtrader01ToolStripMenuItem,
            this.settlementtrader02ToolStripMenuItem,
            this.settlementtrader03ToolStripMenuItem,
            this.settlementtrader04ToolStripMenuItem,
            this.armybarracks01ToolStripMenuItem,
            this.storebooksm01ToolStripMenuItem,
            this.storebooklg01ToolStripMenuItem});
            this.perfabsToolStripMenuItem.Name = "perfabsToolStripMenuItem";
            this.perfabsToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.perfabsToolStripMenuItem.Text = "Perfabs";
            // 
            // settlementtrader01ToolStripMenuItem
            // 
            this.settlementtrader01ToolStripMenuItem.Checked = true;
            this.settlementtrader01ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.settlementtrader01ToolStripMenuItem.Name = "settlementtrader01ToolStripMenuItem";
            this.settlementtrader01ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.settlementtrader01ToolStripMenuItem.Text = "settlement_trader_01";
            // 
            // settlementtrader02ToolStripMenuItem
            // 
            this.settlementtrader02ToolStripMenuItem.Checked = true;
            this.settlementtrader02ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.settlementtrader02ToolStripMenuItem.Name = "settlementtrader02ToolStripMenuItem";
            this.settlementtrader02ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.settlementtrader02ToolStripMenuItem.Text = "settlement_trader_02";
            // 
            // settlementtrader03ToolStripMenuItem
            // 
            this.settlementtrader03ToolStripMenuItem.Checked = true;
            this.settlementtrader03ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.settlementtrader03ToolStripMenuItem.Name = "settlementtrader03ToolStripMenuItem";
            this.settlementtrader03ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.settlementtrader03ToolStripMenuItem.Text = "settlement_trader_03";
            // 
            // settlementtrader04ToolStripMenuItem
            // 
            this.settlementtrader04ToolStripMenuItem.Checked = true;
            this.settlementtrader04ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.settlementtrader04ToolStripMenuItem.Name = "settlementtrader04ToolStripMenuItem";
            this.settlementtrader04ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.settlementtrader04ToolStripMenuItem.Text = "settlement_trader_04";
            // 
            // armybarracks01ToolStripMenuItem
            // 
            this.armybarracks01ToolStripMenuItem.Checked = true;
            this.armybarracks01ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.armybarracks01ToolStripMenuItem.Name = "armybarracks01ToolStripMenuItem";
            this.armybarracks01ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.armybarracks01ToolStripMenuItem.Text = "army_barracks_01";
            // 
            // storebooksm01ToolStripMenuItem
            // 
            this.storebooksm01ToolStripMenuItem.Checked = true;
            this.storebooksm01ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.storebooksm01ToolStripMenuItem.Name = "storebooksm01ToolStripMenuItem";
            this.storebooksm01ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.storebooksm01ToolStripMenuItem.Text = "store_book_sm_01";
            // 
            // storebooklg01ToolStripMenuItem
            // 
            this.storebooklg01ToolStripMenuItem.Checked = true;
            this.storebooklg01ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.storebooklg01ToolStripMenuItem.Name = "storebooklg01ToolStripMenuItem";
            this.storebooklg01ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.storebooklg01ToolStripMenuItem.Text = "store_book_lg_01";
            // 
            // mapSacleTrackBar
            // 
            this.mapSacleTrackBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.mapSacleTrackBar.Location = new System.Drawing.Point(0, 27);
            this.mapSacleTrackBar.Maximum = 20;
            this.mapSacleTrackBar.Minimum = 1;
            this.mapSacleTrackBar.Name = "mapSacleTrackBar";
            this.mapSacleTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.mapSacleTrackBar.Size = new System.Drawing.Size(45, 434);
            this.mapSacleTrackBar.TabIndex = 33;
            this.mapSacleTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.mapSacleTrackBar.Value = 10;
            this.mapSacleTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // HelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.mapSacleTrackBar);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.MainMenuStrip = this.menuStrip1;
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gimmeTimer;
        private System.Windows.Forms.Timer infinityTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripTextBox gimmeToolStripTextBox;
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
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem perfabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settlementtrader01ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settlementtrader02ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settlementtrader03ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settlementtrader04ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armybarracks01ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storebooksm01ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storebooklg01ToolStripMenuItem;
    }
}

