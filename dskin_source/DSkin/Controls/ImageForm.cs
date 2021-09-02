namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ImageForm : Form
    {
        private bool bool_0 = false;
        private GifBox DrQntodeNb;
        private IContainer icontainer_0 = null;
        private Panel panel1;
        private Point point_0;

        public ImageForm(Image img)
        {
            this.InitializeComponent();
            if (img != null)
            {
                int width = (img.Width > img.Height) ? img.Width : img.Height;
                width += 40;
                if ((width > Screen.PrimaryScreen.Bounds.Width) || (width > Screen.PrimaryScreen.Bounds.Height))
                {
                    base.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    base.Size = new Size(width, width);
                }
                this.DrQntodeNb.Image = img;
                base.MouseDown += new MouseEventHandler(this.ImageForm_MouseDown);
                base.MouseUp += new MouseEventHandler(this.ImageForm_MouseUp);
                base.MouseMove += new MouseEventHandler(this.ImageForm_MouseMove);
                base.KeyUp += new KeyEventHandler(this.ImageForm_KeyUp);
                this.DrQntodeNb.MouseDown += new MouseEventHandler(this.ImageForm_MouseDown);
                this.DrQntodeNb.MouseUp += new MouseEventHandler(this.ImageForm_MouseUp);
                this.DrQntodeNb.MouseMove += new MouseEventHandler(this.ImageForm_MouseMove);
                this.DrQntodeNb.KeyUp += new KeyEventHandler(this.ImageForm_KeyUp);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ImageForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                base.Close();
            }
        }

        private void ImageForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (base.WindowState != FormWindowState.Maximized))
            {
                this.bool_0 = true;
                this.point_0 = e.Location;
                this.Cursor = Cursors.Hand;
            }
        }

        private void ImageForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.bool_0)
            {
                int num = Math.Abs((int) (e.Location.X - this.point_0.X)) + Math.Abs((int) (e.Location.Y - this.point_0.Y));
                if (num >= 4)
                {
                    base.Location = new Point((base.Location.X + e.Location.X) - this.point_0.X, (base.Location.Y + e.Location.Y) - this.point_0.Y);
                }
            }
        }

        private void ImageForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.bool_0 = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ImageForm));
            this.panel1 = new Panel();
            this.DrQntodeNb = new GifBox();
            base.SuspendLayout();
            this.panel1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.panel1.BackgroundImage = (Image) manager.GetObject("panel1.BackgroundImage");
            this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Location = new Point(0x17b, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(12, 12);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new EventHandler(this.panel1_Click);
            this.DrQntodeNb.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.DrQntodeNb.BorderColor = Color.Transparent;
            this.DrQntodeNb.Image = null;
            this.DrQntodeNb.Location = new Point(12, 12);
            this.DrQntodeNb.Name = "gifBox1";
            this.DrQntodeNb.Size = new Size(0x171, 0x13d);
            this.DrQntodeNb.TabIndex = 2;
            this.DrQntodeNb.Text = "gifBox1";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x189, 0x155);
            base.ControlBox = false;
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.DrQntodeNb);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ImageForm";
            base.Opacity = 0.95;
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            base.ResumeLayout(false);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

