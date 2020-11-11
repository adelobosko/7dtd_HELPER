namespace _7dtd_HELP
{
    partial class SetIconForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.iconHeightLabel = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.iconWidthLabel = new System.Windows.Forms.Label();
            this.clearIconButton = new System.Windows.Forms.Button();
            this.setIconButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.emptyMapPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emptyMapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.heightTextBox);
            this.panel1.Controls.Add(this.iconHeightLabel);
            this.panel1.Controls.Add(this.widthTextBox);
            this.panel1.Controls.Add(this.iconWidthLabel);
            this.panel1.Controls.Add(this.clearIconButton);
            this.panel1.Controls.Add(this.setIconButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(350, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 388);
            this.panel1.TabIndex = 1;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.heightTextBox.Location = new System.Drawing.Point(0, 206);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(257, 34);
            this.heightTextBox.TabIndex = 6;
            this.heightTextBox.Text = "20";
            this.heightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.heightTextBox.TextChanged += new System.EventHandler(this.heightTextBox_TextChanged);
            // 
            // iconHeightLabel
            // 
            this.iconHeightLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconHeightLabel.Location = new System.Drawing.Point(0, 179);
            this.iconHeightLabel.Name = "iconHeightLabel";
            this.iconHeightLabel.Size = new System.Drawing.Size(257, 27);
            this.iconHeightLabel.TabIndex = 5;
            this.iconHeightLabel.Text = "Icon height:";
            this.iconHeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.widthTextBox.Location = new System.Drawing.Point(0, 145);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(257, 34);
            this.widthTextBox.TabIndex = 4;
            this.widthTextBox.Text = "20";
            this.widthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.widthTextBox.TextChanged += new System.EventHandler(this.widthTextBox_TextChanged);
            // 
            // iconWidthLabel
            // 
            this.iconWidthLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconWidthLabel.Location = new System.Drawing.Point(0, 118);
            this.iconWidthLabel.Name = "iconWidthLabel";
            this.iconWidthLabel.Size = new System.Drawing.Size(257, 27);
            this.iconWidthLabel.TabIndex = 3;
            this.iconWidthLabel.Text = "Icon width:";
            this.iconWidthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // clearIconButton
            // 
            this.clearIconButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.clearIconButton.Location = new System.Drawing.Point(0, 59);
            this.clearIconButton.Margin = new System.Windows.Forms.Padding(5);
            this.clearIconButton.Name = "clearIconButton";
            this.clearIconButton.Size = new System.Drawing.Size(257, 59);
            this.clearIconButton.TabIndex = 2;
            this.clearIconButton.Text = "Clear Icon";
            this.clearIconButton.UseVisualStyleBackColor = true;
            this.clearIconButton.Click += new System.EventHandler(this.clearIconButton_Click);
            // 
            // setIconButton
            // 
            this.setIconButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.setIconButton.Location = new System.Drawing.Point(0, 0);
            this.setIconButton.Margin = new System.Windows.Forms.Padding(5);
            this.setIconButton.Name = "setIconButton";
            this.setIconButton.Size = new System.Drawing.Size(257, 59);
            this.setIconButton.TabIndex = 1;
            this.setIconButton.Text = "Set Icon";
            this.setIconButton.UseVisualStyleBackColor = true;
            this.setIconButton.Click += new System.EventHandler(this.setIconButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Controls.Add(this.saveButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 268);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 120);
            this.panel2.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.cancelButton.Location = new System.Drawing.Point(0, 59);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(257, 59);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveButton.Location = new System.Drawing.Point(0, 0);
            this.saveButton.Margin = new System.Windows.Forms.Padding(5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(257, 59);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // emptyMapPictureBox
            // 
            this.emptyMapPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.emptyMapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emptyMapPictureBox.Location = new System.Drawing.Point(0, 0);
            this.emptyMapPictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.emptyMapPictureBox.Name = "emptyMapPictureBox";
            this.emptyMapPictureBox.Size = new System.Drawing.Size(350, 388);
            this.emptyMapPictureBox.TabIndex = 0;
            this.emptyMapPictureBox.TabStop = false;
            // 
            // SetIconForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 388);
            this.Controls.Add(this.emptyMapPictureBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SetIconForm";
            this.Text = "SetIcon";
            this.Load += new System.EventHandler(this.SetIconForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emptyMapPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox emptyMapPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label iconHeightLabel;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label iconWidthLabel;
        private System.Windows.Forms.Button clearIconButton;
        private System.Windows.Forms.Button setIconButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}