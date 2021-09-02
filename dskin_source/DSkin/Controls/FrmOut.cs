namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class FrmOut : Form
    {
        private Bitmap bitmap_0;
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private bool bool_3;
        private bool bool_4;
        private bool bool_5;
        private bool bool_6;
        private ContextMenuStrip contextMenuStrip1;
        private float float_0;
        private IContainer icontainer_0;
        private Point point_0;
        private Rectangle rectangle_0;
        private Rectangle rectangle_1;
        private ToolStripSeparator saveOringinalToolStripMenuItem;
        private Size size_0;
        private ToolStripMenuItem TMenuItem_Close;
        private ToolStripMenuItem TMenuItem_CurrentToClip;
        private ToolStripMenuItem TMenuItem_Help;
        private ToolStripMenuItem TMenuItem_OriginalToClip;
        private ToolStripMenuItem TMenuItem_SaveCurrent;
        private ToolStripMenuItem TMenuItem_SaveOriginal;
        private ToolStripMenuItem TMenuItem_Size;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;

        public FrmOut(Bitmap bmp)
        {
            FormClosingEventHandler handler = null;
            this.icontainer_0 = null;
            this.InitializeComponent();
            base.FormBorderStyle = FormBorderStyle.None;
            base.TopMost = true;
            this.bitmap_0 = bmp;
            handler = new FormClosingEventHandler(this.method_4);
            base.FormClosing += handler;
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.icontainer_0 = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmOut));
            this.contextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
            this.TMenuItem_OriginalToClip = new ToolStripMenuItem();
            this.TMenuItem_CurrentToClip = new ToolStripMenuItem();
            this.saveOringinalToolStripMenuItem = new ToolStripSeparator();
            this.TMenuItem_SaveOriginal = new ToolStripMenuItem();
            this.TMenuItem_SaveCurrent = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.TMenuItem_Size = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.TMenuItem_Help = new ToolStripMenuItem();
            this.TMenuItem_Close = new ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.TMenuItem_OriginalToClip, this.TMenuItem_CurrentToClip, this.saveOringinalToolStripMenuItem, this.TMenuItem_SaveOriginal, this.TMenuItem_SaveCurrent, this.toolStripSeparator1, this.TMenuItem_Size, this.toolStripSeparator2, this.TMenuItem_Help, this.TMenuItem_Close });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0xc9, 0xb0);
            this.TMenuItem_OriginalToClip.Name = "TMenuItem_OriginalToClip";
            this.TMenuItem_OriginalToClip.Size = new Size(200, 0x16);
            this.TMenuItem_OriginalToClip.Text = "Original to ClipBoard";
            this.TMenuItem_OriginalToClip.Click += new EventHandler(this.TMenuItem_OriginalToClip_Click);
            this.TMenuItem_CurrentToClip.Name = "TMenuItem_CurrentToClip";
            this.TMenuItem_CurrentToClip.Size = new Size(200, 0x16);
            this.TMenuItem_CurrentToClip.Text = "Current to ClipBoard";
            this.TMenuItem_CurrentToClip.Click += new EventHandler(this.TMenuItem_CurrentToClip_Click);
            this.saveOringinalToolStripMenuItem.Name = "saveOringinalToolStripMenuItem";
            this.saveOringinalToolStripMenuItem.Size = new Size(0xc5, 6);
            this.TMenuItem_SaveOriginal.Name = "TMenuItem_SaveOriginal";
            this.TMenuItem_SaveOriginal.Size = new Size(200, 0x16);
            this.TMenuItem_SaveOriginal.Text = "Save Original";
            this.TMenuItem_SaveOriginal.Click += new EventHandler(this.TMenuItem_SaveOriginal_Click);
            this.TMenuItem_SaveCurrent.Name = "TMenuItem_SaveCurrent";
            this.TMenuItem_SaveCurrent.Size = new Size(200, 0x16);
            this.TMenuItem_SaveCurrent.Text = "Save Current";
            this.TMenuItem_SaveCurrent.Click += new EventHandler(this.TMenuItem_SaveCurrent_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(0xc5, 6);
            this.TMenuItem_Size.Name = "TMenuItem_Size";
            this.TMenuItem_Size.Size = new Size(200, 0x16);
            this.TMenuItem_Size.Text = "Set Size";
            this.TMenuItem_Size.Click += new EventHandler(this.TMenuItem_Size_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(0xc5, 6);
            this.TMenuItem_Help.Name = "TMenuItem_Help";
            this.TMenuItem_Help.Size = new Size(200, 0x16);
            this.TMenuItem_Help.Text = "Help";
            this.TMenuItem_Help.Click += new EventHandler(this.TMenuItem_Help_Click);
            this.TMenuItem_Close.Name = "TMenuItem_Close";
            this.TMenuItem_Close.Size = new Size(200, 0x16);
            this.TMenuItem_Close.Text = "Close";
            this.TMenuItem_Close.Click += new EventHandler(this.TMenuItem_Close_Click);
            base.AutoScaleMode = AutoScaleMode.None;
            base.ClientSize = new Size(290, 0xf7);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FrmOut";
            this.contextMenuStrip1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void method_0()
        {
            new Thread(new ThreadStart(this.method_5)) { IsBackground = true }.Start();
        }

        private void method_1(bool bool_7)
        {
            if (bool_7)
            {
                Clipboard.SetImage(this.bitmap_0);
            }
            else
            {
                using (Bitmap bitmap = new Bitmap(base.Width - 2, base.Height - 2, PixelFormat.Format24bppRgb))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.DrawImage(this.bitmap_0, 0, 0, bitmap.Width, bitmap.Height);
                        Clipboard.SetImage(bitmap);
                    }
                }
            }
        }

        private void method_2(bool bool_7)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg",
                FilterIndex = 2,
                FileName = "CAPTURE_" + this.method_3()
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap bitmap = bool_7 ? (this.bitmap_0.Clone() as Bitmap) : new Bitmap(base.Width - 2, base.Height - 2, PixelFormat.Format24bppRgb))
                {
                    if (bool_7)
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.DrawImage(this.bitmap_0, 0, 0, (int) (base.Width - 2), (int) (base.Height - 2));
                        }
                    }
                    switch (dialog.FilterIndex)
                    {
                        case 1:
                            bitmap.Save(dialog.FileName, ImageFormat.Bmp);
                            return;

                        case 2:
                            bitmap.Save(dialog.FileName, ImageFormat.Jpeg);
                            return;
                    }
                }
            }
        }

        private string method_3()
        {
            DateTime now = DateTime.Now;
            return (now.Date.ToShortDateString().Replace("/", "") + "_" + now.ToLongTimeString().Replace(":", ""));
        }

        [CompilerGenerated]
        private void method_4(object sender, FormClosingEventArgs e)
        {
            this.bitmap_0.Dispose();
        }

        [CompilerGenerated]
        private void method_5()
        {
            for (int i = 0; i < 4; i++)
            {
                this.bool_1 = !this.bool_1;
                base.Invalidate();
                Thread.Sleep(250);
            }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (base.WindowState == FormWindowState.Normal)
            {
                base.WindowState = FormWindowState.Maximized;
            }
            else
            {
                base.WindowState = FormWindowState.Normal;
                this.method_0();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            int num;
            if (e.KeyChar == 'w')
            {
                base.Top--;
            }
            if (e.KeyChar == 's')
            {
                base.Top++;
            }
            if (e.KeyChar == 'a')
            {
                base.Left--;
            }
            if (e.KeyChar == 'd')
            {
                base.Left++;
            }
            if (e.KeyChar == 't')
            {
                base.Height = num = base.Height - 1;
                this.size_0.Height = (int) (((float) (num - 2)) / this.float_0);
            }
            if (e.KeyChar == 'g')
            {
                base.Height = num = base.Height + 1;
                this.size_0.Height = (int) (((float) (num - 2)) / this.float_0);
            }
            if (e.KeyChar == 'f')
            {
                base.Width = num = base.Width - 1;
                this.size_0.Width = (int) (((float) (num - 2)) / this.float_0);
            }
            if (e.KeyChar == 'h')
            {
                base.Width = num = base.Width + 1;
                this.size_0.Width = (int) (((float) (num - 2)) / this.float_0);
            }
            base.OnKeyPress(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            base.Width = this.bitmap_0.Width + 2;
            base.Height = this.bitmap_0.Height + 2;
            this.size_0 = this.bitmap_0.Size;
            this.float_0 = 1f;
            this.method_0();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                base.Close();
            }
            if ((e.Button == MouseButtons.Left) && ((e.X >= (base.Width - 20)) && (e.Y <= 20)))
            {
                base.Close();
            }
            if (this.bool_5)
            {
                this.method_2(false);
            }
            if (this.bool_4)
            {
                this.method_2(true);
            }
            base.OnMouseClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.point_0 = e.Location;
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.bool_0 = true;
            base.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.bool_0 = false;
            this.bool_4 = false;
            this.bool_5 = false;
            base.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) || (e.Button == MouseButtons.Middle))
            {
                base.Location = (Point) (((Size) Control.MousePosition) - ((Size) this.point_0));
            }
            if (this.rectangle_0.Contains(e.Location))
            {
                if (!this.bool_4)
                {
                    this.bool_4 = true;
                    base.Invalidate(this.bool_4);
                }
            }
            else if (this.bool_4)
            {
                this.bool_4 = false;
                base.Invalidate(this.bool_4);
            }
            if (this.rectangle_1.Contains(e.Location))
            {
                if (!this.bool_5)
                {
                    this.bool_5 = true;
                    base.Invalidate(this.rectangle_1);
                }
            }
            else if (this.bool_5)
            {
                this.bool_5 = false;
                base.Invalidate(this.rectangle_1);
            }
            if ((e.X >= (base.Width - 20)) && (e.Y <= 20))
            {
                if (!this.bool_6)
                {
                    this.bool_6 = true;
                    this.ContextMenuStrip = this.contextMenuStrip1;
                    base.Invalidate(new Rectangle(base.Width - 20, 1, 0x13, 0x13));
                }
            }
            else if (this.bool_6)
            {
                this.bool_6 = false;
                this.ContextMenuStrip = null;
                base.Invalidate(new Rectangle(base.Width - 20, 1, 0x13, 0x13));
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (this.bool_0)
            {
                float num = 0f;
                if (e.Delta > 0)
                {
                    if ((base.Width >= Screen.PrimaryScreen.Bounds.Width) && (base.Height >= Screen.PrimaryScreen.Bounds.Height))
                    {
                        return;
                    }
                    num = 0.1f;
                }
                if (e.Delta < 0)
                {
                    if ((base.Width <= 100) && (base.Height <= 30))
                    {
                        return;
                    }
                    num = -0.1f;
                }
                this.float_0 += num;
                if (!(this.bool_2 || this.bool_3))
                {
                    base.Left = Control.MousePosition.X - ((int) (((int) (((float) e.X) / (this.float_0 - num))) * this.float_0));
                    base.Top = Control.MousePosition.Y - ((int) (((int) (((float) e.Y) / (this.float_0 - num))) * this.float_0));
                }
                base.Width = (int) ((this.size_0.Width * this.float_0) + 2f);
                base.Height = (int) ((this.size_0.Height * this.float_0) + 2f);
            }
            base.OnMouseWheel(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.bitmap_0 == null)
            {
                MessageBox.Show("Bitmap cannot be null!");
                base.Close();
            }
            Graphics graphics = e.Graphics;
            graphics.DrawImage(this.bitmap_0, 1, 1, (int) (base.Width - 2), (int) (base.Height - 2));
            graphics.DrawRectangle(Pens.Cyan, 0, 0, base.Width - 1, base.Height - 1);
            if (this.bool_0 || this.bool_1)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                {
                    graphics.FillRectangle(brush, 1, 1, base.Width - 2, base.Height - 2);
                    brush.Color = Color.FromArgb(150, 0, 0xff, 0xff);
                    StringFormat format = new StringFormat();
                    object[] objArray = new object[13];
                    objArray[0] = "Original:\t[";
                    objArray[1] = this.bitmap_0.Width;
                    objArray[2] = ",";
                    objArray[3] = this.bitmap_0.Height;
                    objArray[4] = "]\tScale:";
                    double num = ((double) (base.Width - 2)) / ((double) this.bitmap_0.Width);
                    objArray[5] = num.ToString("F2");
                    objArray[6] = "[W]\r\nCurrent:\t[";
                    objArray[7] = base.Width - 2;
                    objArray[8] = ",";
                    objArray[9] = base.Height - 2;
                    objArray[10] = "]\tScale:";
                    objArray[11] = (((double) (base.Height - 2)) / ((double) this.bitmap_0.Height)).ToString("F2");
                    objArray[12] = "[H]";
                    string text = string.Concat(objArray);
                    format.SetTabStops(0f, new float[] { 60f, 60f });
                    Rectangle rect = new Rectangle(new Point(1, 1), graphics.MeasureString(text, this.Font, base.Width, format).ToSize());
                    rect.Inflate(1, 1);
                    graphics.FillRectangle(brush, rect);
                    graphics.DrawString(text, this.Font, Brushes.Wheat, rect, format);
                    rect = new Rectangle(0, (base.Height - (2 * this.Font.Height)) - 1, base.Width, this.Font.Height * 2);
                    format.Alignment = StringAlignment.Far;
                    graphics.FillRectangle(brush, rect);
                    graphics.DrawString("Move [W,S,A,D] ReSize [T,G,F,H]\r\nScale [MouseWheel] Exit [MouseRight]", this.Font, Brushes.Wheat, rect, format);
                    graphics.DrawString("SaveOriginal\r\nSaveCurrent", this.Font, Brushes.Wheat, (float) (rect.X + 12), (float) rect.Y);
                    graphics.FillRectangle(brush, base.Width - 0x15, 1, 20, 20);
                    if (this.bool_6)
                    {
                        graphics.FillRectangle(Brushes.Red, base.Width - 20, 1, 0x13, 0x13);
                    }
                    brush.Color = this.bool_4 ? Color.Red : Color.Wheat;
                    this.rectangle_0 = new Rectangle(2, rect.Y + 2, 10, this.Font.Height - 3);
                    graphics.FillRectangle(brush, this.rectangle_0);
                    brush.Color = this.bool_5 ? Color.Red : Color.Wheat;
                    this.rectangle_1 = new Rectangle(2, (rect.Y + this.Font.Height) + 1, 10, this.Font.Height - 2);
                    graphics.FillRectangle(brush, this.rectangle_1);
                }
            }
            base.OnPaint(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            int num = Screen.PrimaryScreen.Bounds.Width;
            int num2 = Screen.PrimaryScreen.Bounds.Height;
            if (width < 100)
            {
                width = 100;
            }
            if (width > Screen.PrimaryScreen.Bounds.Width)
            {
                width = num;
            }
            if (height < 30)
            {
                height = 30;
            }
            if (height > Screen.PrimaryScreen.Bounds.Height)
            {
                height = num2;
            }
            this.bool_2 = (width == 100) || (height == 30);
            this.bool_3 = (width == num) || (height == num2);
            if (this.bool_3)
            {
                y = 0;
                x = 0;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        private void TMenuItem_Close_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void TMenuItem_CurrentToClip_Click(object sender, EventArgs e)
        {
            this.method_1(false);
        }

        private void TMenuItem_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MoveWindow\t[W,A,S,D],[MouseMiddle]\r\n\t\t[MouseDown and move]\r\nReSizeWindow\t[T,F,G,H],[MouseWheel]\r\nWindowState\t[MouseDoubleClick]");
        }

        private void TMenuItem_OriginalToClip_Click(object sender, EventArgs e)
        {
            this.method_1(true);
        }

        private void TMenuItem_SaveCurrent_Click(object sender, EventArgs e)
        {
            this.method_2(false);
        }

        private void TMenuItem_SaveOriginal_Click(object sender, EventArgs e)
        {
            this.method_2(true);
        }

        private void TMenuItem_Size_Click(object sender, EventArgs e)
        {
            FrmSize size = new FrmSize(new Size(base.Width - 2, base.Height - 2));
            if (size.ShowDialog() == DialogResult.OK)
            {
                base.Width = size.ImageSize.Width + 2;
                base.Height = size.ImageSize.Height + 2;
                this.size_0.Width = (int) (((float) (base.Width - 2)) / this.float_0);
                this.size_0.Height = (int) (((float) (base.Height - 2)) / this.float_0);
            }
        }

        public Bitmap Bmp
        {
            get
            {
                return this.bitmap_0;
            }
        }
    }
}

