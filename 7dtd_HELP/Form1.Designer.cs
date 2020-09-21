namespace _7dtd_HELP
{
    partial class Form1
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
            this.gimmeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.gimmeGroupBox = new System.Windows.Forms.GroupBox();
            this.traderGroupBox = new System.Windows.Forms.GroupBox();
            this.traderButton = new System.Windows.Forms.Button();
            this.vtsMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.vtmMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.vthMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.vtLabel = new System.Windows.Forms.Label();
            this.rtsMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.rtmMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.rthMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.rtLabel = new System.Windows.Forms.Label();
            this.loopMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.secsTextBox = new System.Windows.Forms.TextBox();
            this.gimmeGroupBox.SuspendLayout();
            this.traderGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gimmeTimer
            // 
            this.gimmeTimer.Interval = 20;
            this.gimmeTimer.Tick += new System.EventHandler(this.gimmeTimer_Tick);
            // 
            // infinityTimer
            // 
            this.infinityTimer.Enabled = true;
            this.infinityTimer.Interval = 1;
            this.infinityTimer.Tick += new System.EventHandler(this.timerInfinity_Tick);
            // 
            // gimmeMaskedTextBox
            // 
            this.gimmeMaskedTextBox.Location = new System.Drawing.Point(6, 51);
            this.gimmeMaskedTextBox.Mask = "00";
            this.gimmeMaskedTextBox.Name = "gimmeMaskedTextBox";
            this.gimmeMaskedTextBox.Size = new System.Drawing.Size(45, 20);
            this.gimmeMaskedTextBox.TabIndex = 30;
            this.gimmeMaskedTextBox.Text = "60";
            this.gimmeMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gimmeMaskedTextBox.ValidatingType = typeof(int);
            // 
            // gimmeGroupBox
            // 
            this.gimmeGroupBox.AutoSize = true;
            this.gimmeGroupBox.Controls.Add(this.gimmeMaskedTextBox);
            this.gimmeGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.gimmeGroupBox.Location = new System.Drawing.Point(0, 0);
            this.gimmeGroupBox.Name = "gimmeGroupBox";
            this.gimmeGroupBox.Size = new System.Drawing.Size(57, 284);
            this.gimmeGroupBox.TabIndex = 31;
            this.gimmeGroupBox.TabStop = false;
            this.gimmeGroupBox.Text = "GIMME NUM0 NUM3";
            // 
            // traderGroupBox
            // 
            this.traderGroupBox.Controls.Add(this.secsTextBox);
            this.traderGroupBox.Controls.Add(this.traderButton);
            this.traderGroupBox.Controls.Add(this.vtsMaskedTextBox);
            this.traderGroupBox.Controls.Add(this.vtmMaskedTextBox);
            this.traderGroupBox.Controls.Add(this.vthMaskedTextBox);
            this.traderGroupBox.Controls.Add(this.vtLabel);
            this.traderGroupBox.Controls.Add(this.rtsMaskedTextBox);
            this.traderGroupBox.Controls.Add(this.rtmMaskedTextBox);
            this.traderGroupBox.Controls.Add(this.rthMaskedTextBox);
            this.traderGroupBox.Controls.Add(this.rtLabel);
            this.traderGroupBox.Controls.Add(this.loopMaskedTextBox);
            this.traderGroupBox.Controls.Add(this.label1);
            this.traderGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.traderGroupBox.Location = new System.Drawing.Point(57, 0);
            this.traderGroupBox.Name = "traderGroupBox";
            this.traderGroupBox.Size = new System.Drawing.Size(94, 284);
            this.traderGroupBox.TabIndex = 32;
            this.traderGroupBox.TabStop = false;
            this.traderGroupBox.Text = "TRADER";
            // 
            // traderButton
            // 
            this.traderButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.traderButton.Location = new System.Drawing.Point(3, 195);
            this.traderButton.Name = "traderButton";
            this.traderButton.Size = new System.Drawing.Size(88, 23);
            this.traderButton.TabIndex = 33;
            this.traderButton.Text = "GetK";
            this.traderButton.UseVisualStyleBackColor = true;
            // 
            // vtsMaskedTextBox
            // 
            this.vtsMaskedTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.vtsMaskedTextBox.Location = new System.Drawing.Point(3, 175);
            this.vtsMaskedTextBox.Mask = "00";
            this.vtsMaskedTextBox.Name = "vtsMaskedTextBox";
            this.vtsMaskedTextBox.Size = new System.Drawing.Size(88, 20);
            this.vtsMaskedTextBox.TabIndex = 43;
            this.vtsMaskedTextBox.Text = "00";
            this.vtsMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // vtmMaskedTextBox
            // 
            this.vtmMaskedTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.vtmMaskedTextBox.Location = new System.Drawing.Point(3, 155);
            this.vtmMaskedTextBox.Mask = "00";
            this.vtmMaskedTextBox.Name = "vtmMaskedTextBox";
            this.vtmMaskedTextBox.Size = new System.Drawing.Size(88, 20);
            this.vtmMaskedTextBox.TabIndex = 42;
            this.vtmMaskedTextBox.Text = "00";
            this.vtmMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // vthMaskedTextBox
            // 
            this.vthMaskedTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.vthMaskedTextBox.Location = new System.Drawing.Point(3, 135);
            this.vthMaskedTextBox.Mask = "00";
            this.vthMaskedTextBox.Name = "vthMaskedTextBox";
            this.vthMaskedTextBox.Size = new System.Drawing.Size(88, 20);
            this.vthMaskedTextBox.TabIndex = 41;
            this.vthMaskedTextBox.Text = "12";
            this.vthMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // vtLabel
            // 
            this.vtLabel.AutoSize = true;
            this.vtLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.vtLabel.Location = new System.Drawing.Point(3, 122);
            this.vtLabel.Name = "vtLabel";
            this.vtLabel.Size = new System.Drawing.Size(85, 13);
            this.vtLabel.TabIndex = 40;
            this.vtLabel.Text = "VIRTUAL TIME:";
            // 
            // rtsMaskedTextBox
            // 
            this.rtsMaskedTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtsMaskedTextBox.Location = new System.Drawing.Point(3, 102);
            this.rtsMaskedTextBox.Mask = "00";
            this.rtsMaskedTextBox.Name = "rtsMaskedTextBox";
            this.rtsMaskedTextBox.Size = new System.Drawing.Size(88, 20);
            this.rtsMaskedTextBox.TabIndex = 39;
            this.rtsMaskedTextBox.Text = "00";
            this.rtsMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rtmMaskedTextBox
            // 
            this.rtmMaskedTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtmMaskedTextBox.Location = new System.Drawing.Point(3, 82);
            this.rtmMaskedTextBox.Mask = "00";
            this.rtmMaskedTextBox.Name = "rtmMaskedTextBox";
            this.rtmMaskedTextBox.Size = new System.Drawing.Size(88, 20);
            this.rtmMaskedTextBox.TabIndex = 38;
            this.rtmMaskedTextBox.Text = "00";
            this.rtmMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rthMaskedTextBox
            // 
            this.rthMaskedTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.rthMaskedTextBox.Location = new System.Drawing.Point(3, 62);
            this.rthMaskedTextBox.Mask = "00";
            this.rthMaskedTextBox.Name = "rthMaskedTextBox";
            this.rthMaskedTextBox.Size = new System.Drawing.Size(88, 20);
            this.rthMaskedTextBox.TabIndex = 37;
            this.rthMaskedTextBox.Text = "12";
            this.rthMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rtLabel
            // 
            this.rtLabel.AutoSize = true;
            this.rtLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtLabel.Location = new System.Drawing.Point(3, 49);
            this.rtLabel.Name = "rtLabel";
            this.rtLabel.Size = new System.Drawing.Size(67, 13);
            this.rtLabel.TabIndex = 35;
            this.rtLabel.Text = "REAL TIME:";
            // 
            // loopMaskedTextBox
            // 
            this.loopMaskedTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.loopMaskedTextBox.Location = new System.Drawing.Point(3, 29);
            this.loopMaskedTextBox.Mask = "000";
            this.loopMaskedTextBox.Name = "loopMaskedTextBox";
            this.loopMaskedTextBox.Size = new System.Drawing.Size(88, 20);
            this.loopMaskedTextBox.TabIndex = 30;
            this.loopMaskedTextBox.Text = "120";
            this.loopMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "LOOP:";
            // 
            // secsTextBox
            // 
            this.secsTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.secsTextBox.Location = new System.Drawing.Point(3, 218);
            this.secsTextBox.Name = "secsTextBox";
            this.secsTextBox.Size = new System.Drawing.Size(88, 20);
            this.secsTextBox.TabIndex = 33;
            this.secsTextBox.Text = "0";
            this.secsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(583, 284);
            this.Controls.Add(this.traderGroupBox);
            this.Controls.Add(this.gimmeGroupBox);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.gimmeGroupBox.ResumeLayout(false);
            this.gimmeGroupBox.PerformLayout();
            this.traderGroupBox.ResumeLayout(false);
            this.traderGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gimmeTimer;
        private System.Windows.Forms.Timer infinityTimer;
        private System.Windows.Forms.MaskedTextBox gimmeMaskedTextBox;
        private System.Windows.Forms.GroupBox gimmeGroupBox;
        private System.Windows.Forms.GroupBox traderGroupBox;
        private System.Windows.Forms.MaskedTextBox loopMaskedTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox vtsMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox vtmMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox vthMaskedTextBox;
        private System.Windows.Forms.Label vtLabel;
        private System.Windows.Forms.MaskedTextBox rtsMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox rtmMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox rthMaskedTextBox;
        private System.Windows.Forms.Label rtLabel;
        private System.Windows.Forms.Button traderButton;
        private System.Windows.Forms.TextBox secsTextBox;
    }
}

