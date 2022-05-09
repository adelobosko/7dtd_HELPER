using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace _7dtd_HELP
{
    public partial class PositionReaderForm : Form
    {
        public Rectangle Result { get; set; }
        private Point previewMousePosition;
        private bool isClipped;
        private Image screenShot;

        public PositionReaderForm()
        {
            InitializeComponent();
        }


        private void PositionReader_Load(object sender, EventArgs e)
        {
            screenShot = SnapShotService.TakeWindowScreen();
            this.Width = screenShot.Width;
            this.Height = screenShot.Height;
            this.AllowTransparency = true;
            this.BackgroundImage = screenShot;
            openFormTimer.Enabled = false;
            openFormTimer.Enabled = true;
        }


        



        private void screenPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            previewMousePosition = e.Location;
            isClipped = true;
        }

        private void DrawScreen(Point p1, Point p2)
        {
            if (screenShot == null)
                return;



            var transparentImage = new Bitmap(screenShot.Width, screenShot.Height, PixelFormat.Format32bppArgb);
            using (var tg = Graphics.FromImage(transparentImage))
            {
                tg.Clear(Color.Transparent);
            }
            screenPictureBox.Image = transparentImage;

            var g = Graphics.FromImage(transparentImage);
            g.DrawLine(
                Pens.Red,
                p1.X,
                p1.Y,
                p2.X,
                p1.Y
            );

            g.DrawLine(
                Pens.Red,
                p2.X,
                p1.Y,
                p2.X,
                p2.Y
            );

            g.DrawLine(
                Pens.Red,
                p2.X,
                p2.Y,
                p1.X,
                p2.Y
            );

            g.DrawLine(
                Pens.Red,
                p1.X,
                p2.Y,
                p1.X,
                p1.Y
            );

            screenPictureBox.Image = transparentImage;
        }


        private void screenPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            var tmpPoint = previewMousePosition;
            isClipped = false;
            DrawScreen(tmpPoint, e.Location);

            int top;
            int left;
            int right;
            int bottom;
            if (previewMousePosition.Y < e.Location.Y)
            {
                top = previewMousePosition.Y;
                bottom = e.Location.Y;
            }
            else
            {
                top = e.Location.Y;
                bottom = previewMousePosition.Y;
            }

            if (previewMousePosition.X < e.Location.X)
            {
                left = previewMousePosition.X;
                right = e.Location.X;
            }
            else
            {
                left = e.Location.X;
                right = previewMousePosition.X;
            }

            top = top < 0 ? 0 : top;
            left = left < 0 ? 0 : left;

            var kx = (double)screenShot.Width / this.Width;
            var ky = (double)screenShot.Height / this.Height;

            var resLeft = (int) (kx * left);
            var resTop = (int) (kx * top);
            var resWidth = (int) (kx * right) - resLeft;
            var resHeight = (int)(kx * bottom) - resTop;

            ShowControl(confirmPanel);
            if (resWidth <= 0 || resHeight <= 0)
            {
                return;
            }
            Result = new Rectangle(resLeft, resTop, resWidth, resHeight);
            var previewImage = screenShot.CropAtRect(Result);
            previewPictureBox.Image = previewImage;
            previewPictureBox.Width = previewImage.Width;
            previewPictureBox.Height = previewImage.Height;
            previewPictureBox.Top = 0;

            ShowConfirmResult(Result);
        }

        private void ShowConfirmResult(Rectangle rectangle)
        {
            var confirmForm = new Form();
            confirmForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            confirmForm.Text = $"Save positin: {rectangle}";
            this.IsMdiContainer = true;
            confirmForm.MdiParent = this;
            confirmForm.Width = 400;
            confirmForm.Height = 600;
            confirmForm.TopLevel = true;
            confirmForm.ShowDialog();
        }

        private void screenPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClipped)
            {
                DrawScreen(previewMousePosition, e.Location);
            }
        }


        private void HideControl(Control control)
        {
            control.Hide();
        }


        private void ShowControl(Control control)
        {
            control.Show();
        }

        private void confirmPanel_Click(object sender, EventArgs e)
        {
            HideControl(confirmPanel);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void openFormTimer_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Show();
            openFormTimer.Enabled = false;
        }
    }
}
