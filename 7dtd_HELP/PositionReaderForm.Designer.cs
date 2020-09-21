namespace _7dtd_HELP
{
    partial class PositionReaderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.screenPictureBox = new System.Windows.Forms.PictureBox();
            this.confirmPanel = new System.Windows.Forms.Panel();
            this.rightTopPanel = new System.Windows.Forms.Panel();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.laftTopPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.hintLabel = new System.Windows.Forms.Label();
            this.openFormTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.screenPictureBox)).BeginInit();
            this.confirmPanel.SuspendLayout();
            this.rightTopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.laftTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // screenPictureBox
            // 
            this.screenPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.screenPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.screenPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenPictureBox.Location = new System.Drawing.Point(0, 0);
            this.screenPictureBox.Name = "screenPictureBox";
            this.screenPictureBox.Size = new System.Drawing.Size(545, 450);
            this.screenPictureBox.TabIndex = 0;
            this.screenPictureBox.TabStop = false;
            this.screenPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.screenPictureBox_MouseDown);
            this.screenPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.screenPictureBox_MouseMove);
            this.screenPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.screenPictureBox_MouseUp);
            // 
            // confirmPanel
            // 
            this.confirmPanel.AutoSize = true;
            this.confirmPanel.BackColor = System.Drawing.Color.Transparent;
            this.confirmPanel.Controls.Add(this.rightTopPanel);
            this.confirmPanel.Controls.Add(this.label1);
            this.confirmPanel.Controls.Add(this.laftTopPanel);
            this.confirmPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.confirmPanel.Location = new System.Drawing.Point(0, 102);
            this.confirmPanel.Name = "confirmPanel";
            this.confirmPanel.Size = new System.Drawing.Size(545, 108);
            this.confirmPanel.TabIndex = 1;
            this.confirmPanel.Click += new System.EventHandler(this.confirmPanel_Click);
            // 
            // rightTopPanel
            // 
            this.rightTopPanel.AutoScroll = true;
            this.rightTopPanel.AutoSize = true;
            this.rightTopPanel.BackColor = System.Drawing.Color.White;
            this.rightTopPanel.Controls.Add(this.previewPictureBox);
            this.rightTopPanel.Location = new System.Drawing.Point(185, 0);
            this.rightTopPanel.MaximumSize = new System.Drawing.Size(400, 400);
            this.rightTopPanel.MinimumSize = new System.Drawing.Size(104, 104);
            this.rightTopPanel.Name = "rightTopPanel";
            this.rightTopPanel.Size = new System.Drawing.Size(178, 105);
            this.rightTopPanel.TabIndex = 3;
            this.rightTopPanel.Click += new System.EventHandler(this.confirmPanel_Click);
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.Location = new System.Drawing.Point(0, 0);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(60, 52);
            this.previewPictureBox.TabIndex = 2;
            this.previewPictureBox.TabStop = false;
            this.previewPictureBox.Click += new System.EventHandler(this.confirmPanel_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(178, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 102);
            this.label1.TabIndex = 4;
            this.label1.Text = "Click here to close this panel\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.confirmPanel_Click);
            // 
            // laftTopPanel
            // 
            this.laftTopPanel.BackColor = System.Drawing.Color.Black;
            this.laftTopPanel.Controls.Add(this.cancelButton);
            this.laftTopPanel.Controls.Add(this.saveButton);
            this.laftTopPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.laftTopPanel.Location = new System.Drawing.Point(0, 0);
            this.laftTopPanel.Name = "laftTopPanel";
            this.laftTopPanel.Size = new System.Drawing.Size(178, 108);
            this.laftTopPanel.TabIndex = 1;
            this.laftTopPanel.Click += new System.EventHandler(this.confirmPanel_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.ForeColor = System.Drawing.Color.Red;
            this.cancelButton.Location = new System.Drawing.Point(0, 57);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(178, 51);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.ForeColor = System.Drawing.Color.Lime;
            this.saveButton.Location = new System.Drawing.Point(0, 0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(178, 52);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // hintLabel
            // 
            this.hintLabel.BackColor = System.Drawing.Color.Transparent;
            this.hintLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hintLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.hintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hintLabel.ForeColor = System.Drawing.Color.White;
            this.hintLabel.Location = new System.Drawing.Point(0, 0);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(545, 102);
            this.hintLabel.TabIndex = 2;
            this.hintLabel.Text = "Select coordinates by press and move the mouse. \r\nClick here to close this hint.";
            this.hintLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hintLabel.Click += new System.EventHandler(this.hintLabel_Click);
            // 
            // openFormTimer
            // 
            this.openFormTimer.Interval = 1000;
            this.openFormTimer.Tick += new System.EventHandler(this.openFormTimer_Tick);
            // 
            // PositionReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(545, 450);
            this.Controls.Add(this.confirmPanel);
            this.Controls.Add(this.hintLabel);
            this.Controls.Add(this.screenPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PositionReaderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PositionReader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PositionReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.screenPictureBox)).EndInit();
            this.confirmPanel.ResumeLayout(false);
            this.confirmPanel.PerformLayout();
            this.rightTopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.laftTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox screenPictureBox;
        private System.Windows.Forms.Panel confirmPanel;
        private System.Windows.Forms.Panel rightTopPanel;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.Panel laftTopPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer openFormTimer;
    }
}