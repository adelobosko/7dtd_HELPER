﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7dtd_HELP
{
    public partial class SetIconForm : Form
    {
        public Icon Icon = null;

        public SetIconForm()
        {
            InitializeComponent();
        }

        public void PreviewIcon()
        {
            if (Icon == null)
            {
                emptyMapPictureBox.Image = new Bitmap(1,1);
                widthTextBox.Text = "-1";
                heightTextBox.Text = "-1";
            }
            else
            {
                if (Icon.Width != -1 && Icon.Height != -1)
                {
                    emptyMapPictureBox.Image = Image.FromFile(Icon.FullName).ResizeImage(Icon.Width, Icon.Height);
                }
                else
                {
                    emptyMapPictureBox.Image = Image.FromFile(Icon.FullName);
                }

                widthTextBox.Text = Icon.Width.ToString();
                heightTextBox.Text = Icon.Height.ToString();
            }
        }

        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Icon == null)
                {
                    return;
                }

                var width = int.Parse(widthTextBox.Text);
                if (width <= 0 && width != -1)
                {
                    return;
                }
                Icon.Width = width;

                PreviewIcon();
            }
            catch { }
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Icon == null)
                {
                    return;
                }
                var height = int.Parse(heightTextBox.Text);
                if (height <= 0 && height != -1)
                {
                    return;
                }
                Icon.Height = height;
                PreviewIcon();
            }
            catch { }
        }

        private void setIconButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Icon = new Icon()
                    {
                        FullName = openFileDialog.FileName,
                        Width = 20,
                        Height = 20,
                        IsShow = true
                    };
                    PreviewIcon();
                }
                catch
                {
                }
            }
        }

        private void clearIconButton_Click(object sender, EventArgs e)
        {
            Icon = null;
            PreviewIcon();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SetIconForm_Load(object sender, EventArgs e)
        {

        }
    }
}
