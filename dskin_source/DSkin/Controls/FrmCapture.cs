namespace DSkin.Controls
{
    using DSkin;
    using DSkin.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class FrmCapture : Form
    {
        private Bitmap bitmap_0;
        private Bitmap bitmap_1;
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private bool bool_3;
        private ColorBox colorBox1;
        private IContainer icontainer_0;
        private Control0 imageProcessBox1;
        private List<Bitmap> list_0;
        private MouseHook mouseHook_0;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Point point_0;
        private Point point_1;
        private RichTextBox richTextBox_0;
        private Control1 tBtn_Arrow;
        private Control1 tBtn_Brush;
        private Control1 tBtn_Cancel;
        private Control1 tBtn_Close;
        private Control1 tBtn_Ellipse;
        private Control1 tBtn_Finish;
        private Control1 tBtn_Out;
        private Control1 tBtn_Rect;
        private Control1 tBtn_Save;
        private Control1 tBtn_Text;
        private TextBox textBox1;
        private System.Windows.Forms.Timer timer_0;
        private Control1 toolButton1;
        private Control1 toolButton2;
        private Control1 toolButton3;

        public FrmCapture()
        {
            EventHandler handler = null;
            EventHandler handler2 = null;
            this.richTextBox_0 = null;
            this.bool_3 = true;
            this.icontainer_0 = null;
            this.InitializeComponent();
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(0, 0);
            base.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            base.TopMost = true;
            base.ShowInTaskbar = false;
            this.mouseHook_0 = new MouseHook();
            handler = new EventHandler(this.method_9);
            base.Disposed += handler;
            handler2 = new EventHandler(this.method_10);
            this.imageProcessBox1.MouseLeave += handler2;
            this.list_0 = new List<Bitmap>();
        }

        public FrmCapture(RichTextBox RCTxt)
        {
            FormClosingEventHandler handler = null;
            EventHandler handler2 = null;
            this.richTextBox_0 = null;
            this.bool_3 = true;
            this.icontainer_0 = null;
            this.InitializeComponent();
            this.richTextBox_0 = RCTxt;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(0, 0);
            base.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            base.TopMost = true;
            base.ShowInTaskbar = false;
            this.mouseHook_0 = new MouseHook();
            handler = new FormClosingEventHandler(this.method_11);
            base.FormClosing += handler;
            handler2 = new EventHandler(this.method_12);
            this.imageProcessBox1.MouseLeave += handler2;
            this.list_0 = new List<Bitmap>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        public static Rectangle DrawCurToScreen()
        {
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                PCURSORINFO pcursorinfo;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                pcursorinfo.cbSize = Marshal.SizeOf(typeof(PCURSORINFO));
                DSkin.NativeMethods.GetCursorInfo(out pcursorinfo);
                if (pcursorinfo.hCursor != IntPtr.Zero)
                {
                    Cursor cursor = new Cursor(pcursorinfo.hCursor);
                    Rectangle targetRect = new Rectangle((Point) (((Size) Control.MousePosition) - ((Size) cursor.HotSpot)), cursor.Size);
                    graphics.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                    cursor.Draw(graphics, targetRect);
                    return targetRect;
                }
                return Rectangle.Empty;
            }
        }

        private void FrmCapture_Load(object sender, EventArgs e)
        {
            ThreadStart start = null;
            this.method_1();
            this.imageProcessBox1.Image_0 = smethod_0(this.bool_0, this.bool_1);
            this.mouseHook_0.SetHook();
            this.mouseHook_0.Event_0 += new MouseHook.MHookEventHandler(this.method_2);
            this.imageProcessBox1.Boolean_0 = false;
            base.BeginInvoke(new MethodInvoker(this.method_14));
            this.timer_0.Interval = 500;
            this.timer_0.Enabled = true;
            if (this.bool_3)
            {
                this.bool_3 = false;
                if (start == null)
                {
                    start = new ThreadStart(this.method_15);
                }
                new Thread(start).Start();
            }
        }

        private void imageProcessBox1_DoubleClick(object sender, EventArgs e)
        {
            if (this.bitmap_0 != null)
            {
                Clipboard.SetImage(this.bitmap_0);
                if (this.richTextBox_0 != null)
                {
                    this.richTextBox_0.Paste();
                }
            }
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void imageProcessBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((this.imageProcessBox1.Cursor != Cursors.SizeAll) && (this.imageProcessBox1.Cursor != Cursors.Default))
            {
                this.panel1.Visible = false;
            }
            if ((((e.Button == MouseButtons.Left) && this.imageProcessBox1.Boolean_4) && this.method_5()) && this.imageProcessBox1.Rectangle_0.Contains(e.Location))
            {
                if (this.tBtn_Text.IsSelected)
                {
                    this.textBox1.Location = e.Location;
                    this.textBox1.Visible = true;
                    this.textBox1.Focus();
                    return;
                }
                this.bool_2 = true;
                Cursor.Clip = this.imageProcessBox1.Rectangle_0;
            }
            this.point_0 = e.Location;
        }

        private void imageProcessBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.point_1 = e.Location;
            if ((this.imageProcessBox1.Rectangle_0.Contains(e.Location) && this.method_5()) && this.imageProcessBox1.Boolean_4)
            {
                this.Cursor = Cursors.Cross;
            }
            else if (!this.imageProcessBox1.Rectangle_0.Contains(e.Location))
            {
                this.Cursor = Cursors.Default;
            }
            if (this.imageProcessBox1.Boolean_5 && this.panel1.Visible)
            {
                this.method_4();
            }
            if (this.bool_2 && (this.bitmap_1 != null))
            {
                using (Graphics graphics = Graphics.FromImage(this.bitmap_1))
                {
                    int num = 1;
                    if (this.toolButton2.IsSelected)
                    {
                        num = 3;
                    }
                    if (this.toolButton3.IsSelected)
                    {
                        num = 5;
                    }
                    Pen pen = new Pen(this.colorBox1.method_0(), (float) num);
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    if (this.tBtn_Rect.IsSelected)
                    {
                        int num2 = ((e.X - this.point_0.X) > 0) ? this.point_0.X : e.X;
                        int num3 = ((e.Y - this.point_0.Y) > 0) ? this.point_0.Y : e.Y;
                        graphics.Clear(Color.Transparent);
                        graphics.DrawRectangle(pen, num2 - this.imageProcessBox1.Rectangle_0.Left, num3 - this.imageProcessBox1.Rectangle_0.Top, Math.Abs((int) (e.X - this.point_0.X)), Math.Abs((int) (e.Y - this.point_0.Y)));
                        this.imageProcessBox1.Invalidate();
                    }
                    if (this.tBtn_Ellipse.IsSelected)
                    {
                        graphics.DrawLine(Pens.Red, 0, 0, 200, 200);
                        graphics.Clear(Color.Transparent);
                        graphics.DrawEllipse(pen, (int) (this.point_0.X - this.imageProcessBox1.Rectangle_0.Left), (int) (this.point_0.Y - this.imageProcessBox1.Rectangle_0.Top), (int) (e.X - this.point_0.X), (int) (e.Y - this.point_0.Y));
                        this.imageProcessBox1.Invalidate();
                    }
                    if (this.tBtn_Arrow.IsSelected)
                    {
                        graphics.Clear(Color.Transparent);
                        AdjustableArrowCap cap = new AdjustableArrowCap(5f, 5f, true);
                        pen.CustomEndCap = cap;
                        graphics.DrawLine(pen, (Point) (((Size) this.point_0) - ((Size) this.imageProcessBox1.Rectangle_0.Location)), (Point) (((Size) this.point_1) - ((Size) this.imageProcessBox1.Rectangle_0.Location)));
                        this.imageProcessBox1.Invalidate();
                    }
                    if (this.tBtn_Brush.IsSelected)
                    {
                        Point point = (Point) (((Size) this.point_0) - ((Size) this.imageProcessBox1.Rectangle_0.Location));
                        pen.LineJoin = LineJoin.Round;
                        graphics.DrawLine(pen, point, (Point) (((Size) e.Location) - ((Size) this.imageProcessBox1.Rectangle_0.Location)));
                        this.point_0 = e.Location;
                        this.imageProcessBox1.Invalidate();
                    }
                    pen.Dispose();
                }
            }
        }

        private void imageProcessBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!base.IsDisposed)
            {
                if (e.Button == MouseButtons.Right)
                {
                    base.Enabled = false;
                    this.imageProcessBox1.method_5();
                    this.imageProcessBox1.Boolean_7 = true;
                    this.imageProcessBox1.Boolean_0 = false;
                    this.list_0.Clear();
                    this.bitmap_0 = null;
                    this.bitmap_1 = null;
                    this.method_6();
                    this.panel1.Visible = false;
                    this.panel2.Visible = false;
                }
                if (!this.imageProcessBox1.Boolean_4)
                {
                    base.Enabled = false;
                    this.imageProcessBox1.Boolean_0 = false;
                }
                else if (!this.panel1.Visible)
                {
                    this.method_4();
                    this.panel1.Visible = true;
                    this.bitmap_0 = this.imageProcessBox1.method_11();
                    this.bitmap_1 = new Bitmap(this.bitmap_0.Width, this.bitmap_0.Height);
                }
                if ((this.imageProcessBox1.Cursor == Cursors.SizeAll) && (this.point_0 != e.Location))
                {
                    this.bitmap_0.Dispose();
                    this.bitmap_0 = this.imageProcessBox1.method_11();
                }
                if (this.bool_2)
                {
                    Cursor.Clip = Rectangle.Empty;
                    this.bool_2 = false;
                    if (!(e.Location == this.point_0) || this.tBtn_Brush.IsSelected)
                    {
                        this.method_7();
                    }
                }
            }
        }

        private void imageProcessBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (this.list_0.Count > 0)
            {
                graphics.DrawImage(this.list_0[this.list_0.Count - 1], this.imageProcessBox1.Rectangle_0.Location);
            }
            if (((this.bitmap_1 == null) ? 1 : 0) == 0)
            {
                graphics.DrawImage(this.bitmap_1, this.imageProcessBox1.Rectangle_0.Location);
                Console.WriteLine(this.imageProcessBox1.Rectangle_0);
            }
        }

        private void InitializeComponent()
        {
            this.icontainer_0 = new Container();
            this.panel1 = new Panel();
            this.tBtn_Out = new Control1();
            this.pictureBox2 = new PictureBox();
            this.pictureBox1 = new PictureBox();
            this.tBtn_Finish = new Control1();
            this.tBtn_Close = new Control1();
            this.tBtn_Save = new Control1();
            this.tBtn_Cancel = new Control1();
            this.tBtn_Text = new Control1();
            this.tBtn_Brush = new Control1();
            this.tBtn_Arrow = new Control1();
            this.tBtn_Ellipse = new Control1();
            this.tBtn_Rect = new Control1();
            this.panel2 = new Panel();
            this.toolButton1 = new Control1();
            this.toolButton3 = new Control1();
            this.toolButton2 = new Control1();
            this.colorBox1 = new ColorBox();
            this.textBox1 = new TextBox();
            this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
            this.imageProcessBox1 = new Control0();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            this.panel2.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.tBtn_Out);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tBtn_Finish);
            this.panel1.Controls.Add(this.tBtn_Close);
            this.panel1.Controls.Add(this.tBtn_Save);
            this.panel1.Controls.Add(this.tBtn_Cancel);
            this.panel1.Controls.Add(this.tBtn_Text);
            this.panel1.Controls.Add(this.tBtn_Brush);
            this.panel1.Controls.Add(this.tBtn_Arrow);
            this.panel1.Controls.Add(this.tBtn_Ellipse);
            this.panel1.Controls.Add(this.tBtn_Rect);
            this.panel1.Location = new Point(12, 0x53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x141, 0x19);
            this.panel1.TabIndex = 1;
            this.tBtn_Out.method_1(Resources.smethod_0());
            this.tBtn_Out.IsSelected = false;
            this.tBtn_Out.method_3(false);
            this.tBtn_Out.method_5(false);
            this.tBtn_Out.Location = new Point(0xac, 3);
            this.tBtn_Out.Name = "tBtn_Out";
            this.tBtn_Out.Size = new Size(0x15, 0x15);
            this.tBtn_Out.TabIndex = 11;
            this.tBtn_Out.Click += new EventHandler(this.tBtn_Out_Click);
            this.pictureBox2.Image = Resources.smethod_33();
            this.pictureBox2.Location = new Point(0xe2, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(1, 0x11);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox1.Image = Resources.smethod_33();
            this.pictureBox1.Location = new Point(0x8a, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(1, 0x11);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.tBtn_Finish.method_1(Resources.smethod_27());
            this.tBtn_Finish.IsSelected = false;
            this.tBtn_Finish.method_3(false);
            this.tBtn_Finish.method_5(false);
            this.tBtn_Finish.Location = new Point(260, 3);
            this.tBtn_Finish.Name = "tBtn_Finish";
            this.tBtn_Finish.Size = new Size(50, 0x15);
            this.tBtn_Finish.TabIndex = 8;
            this.tBtn_Finish.Text = "完成";
            this.tBtn_Finish.Click += new EventHandler(this.tBtn_Finish_Click);
            this.tBtn_Close.method_1(Resources.smethod_9());
            this.tBtn_Close.IsSelected = false;
            this.tBtn_Close.method_3(false);
            this.tBtn_Close.method_5(false);
            this.tBtn_Close.Location = new Point(0xe9, 3);
            this.tBtn_Close.Name = "tBtn_Close";
            this.tBtn_Close.Size = new Size(0x15, 0x15);
            this.tBtn_Close.TabIndex = 7;
            this.tBtn_Save.method_1(Resources.smethod_32());
            this.tBtn_Save.IsSelected = false;
            this.tBtn_Save.method_3(false);
            this.tBtn_Save.method_5(false);
            this.tBtn_Save.Location = new Point(0xc7, 3);
            this.tBtn_Save.Name = "tBtn_Save";
            this.tBtn_Save.Size = new Size(0x15, 0x15);
            this.tBtn_Save.TabIndex = 6;
            this.tBtn_Save.Click += new EventHandler(this.tBtn_Save_Click);
            this.tBtn_Cancel.method_1(Resources.smethod_6());
            this.tBtn_Cancel.IsSelected = false;
            this.tBtn_Cancel.method_3(false);
            this.tBtn_Cancel.method_5(false);
            this.tBtn_Cancel.Location = new Point(0x91, 3);
            this.tBtn_Cancel.Name = "tBtn_Cancel";
            this.tBtn_Cancel.Size = new Size(0x15, 0x15);
            this.tBtn_Cancel.TabIndex = 5;
            this.tBtn_Cancel.Click += new EventHandler(this.tBtn_Cancel_Click);
            this.tBtn_Text.method_1(Resources.text);
            this.tBtn_Text.IsSelected = false;
            this.tBtn_Text.method_3(true);
            this.tBtn_Text.method_5(false);
            this.tBtn_Text.Location = new Point(0x6f, 3);
            this.tBtn_Text.Name = "tBtn_Text";
            this.tBtn_Text.Size = new Size(0x15, 0x15);
            this.tBtn_Text.TabIndex = 4;
            this.tBtn_Brush.method_1(Resources.smethod_5());
            this.tBtn_Brush.IsSelected = false;
            this.tBtn_Brush.method_3(true);
            this.tBtn_Brush.method_5(false);
            this.tBtn_Brush.Location = new Point(0x54, 3);
            this.tBtn_Brush.Name = "tBtn_Brush";
            this.tBtn_Brush.Size = new Size(0x15, 0x15);
            this.tBtn_Brush.TabIndex = 3;
            this.tBtn_Arrow.method_1(Resources.smethod_4());
            this.tBtn_Arrow.IsSelected = false;
            this.tBtn_Arrow.method_3(true);
            this.tBtn_Arrow.method_5(false);
            this.tBtn_Arrow.Location = new Point(0x39, 3);
            this.tBtn_Arrow.Name = "tBtn_Arrow";
            this.tBtn_Arrow.Size = new Size(0x15, 0x15);
            this.tBtn_Arrow.TabIndex = 2;
            this.tBtn_Ellipse.method_1(Resources.smethod_18());
            this.tBtn_Ellipse.IsSelected = false;
            this.tBtn_Ellipse.method_3(true);
            this.tBtn_Ellipse.method_5(false);
            this.tBtn_Ellipse.Location = new Point(30, 3);
            this.tBtn_Ellipse.Name = "tBtn_Ellipse";
            this.tBtn_Ellipse.Size = new Size(0x15, 0x15);
            this.tBtn_Ellipse.TabIndex = 1;
            this.tBtn_Rect.method_1(Resources.smethod_30());
            this.tBtn_Rect.IsSelected = false;
            this.tBtn_Rect.method_3(true);
            this.tBtn_Rect.method_5(false);
            this.tBtn_Rect.Location = new Point(3, 3);
            this.tBtn_Rect.Name = "tBtn_Rect";
            this.tBtn_Rect.Size = new Size(0x15, 0x15);
            this.tBtn_Rect.TabIndex = 0;
            this.panel2.Controls.Add(this.toolButton1);
            this.panel2.Controls.Add(this.toolButton3);
            this.panel2.Controls.Add(this.toolButton2);
            this.panel2.Controls.Add(this.colorBox1);
            this.panel2.Location = new Point(12, 0x72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(250, 0x20);
            this.panel2.TabIndex = 2;
            this.toolButton1.method_1(Resources.small);
            this.toolButton1.IsSelected = true;
            this.toolButton1.method_3(true);
            this.toolButton1.method_5(true);
            this.toolButton1.Location = new Point(3, 6);
            this.toolButton1.Name = "toolButton1";
            this.toolButton1.Size = new Size(0x15, 0x15);
            this.toolButton1.TabIndex = 4;
            this.toolButton3.method_1(Resources.large);
            this.toolButton3.IsSelected = false;
            this.toolButton3.method_3(true);
            this.toolButton3.method_5(true);
            this.toolButton3.Location = new Point(0x39, 6);
            this.toolButton3.Name = "toolButton3";
            this.toolButton3.Size = new Size(0x15, 0x15);
            this.toolButton3.TabIndex = 3;
            this.toolButton2.method_1(Resources.middle);
            this.toolButton2.IsSelected = false;
            this.toolButton2.method_3(true);
            this.toolButton2.method_5(true);
            this.toolButton2.Location = new Point(30, 6);
            this.toolButton2.Name = "toolButton2";
            this.toolButton2.Size = new Size(0x15, 0x15);
            this.toolButton2.TabIndex = 2;
            this.colorBox1.Location = new Point(0x55, 0);
            this.colorBox1.Name = "colorBox1";
            this.colorBox1.Size = new Size(0xa5, 0x23);
            this.colorBox1.TabIndex = 0;
            this.colorBox1.Text = "colorBox1";
            this.textBox1.Location = new Point(12, 0x18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(100, 0x13);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            this.textBox1.Resize += new EventHandler(this.textBox1_Resize);
            this.textBox1.Validating += new CancelEventHandler(this.textBox1_Validating);
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
            this.imageProcessBox1.BackColor = Color.Black;
            this.imageProcessBox1.Image_0 = null;
            this.imageProcessBox1.Boolean_7 = true;
            this.imageProcessBox1.Cursor = Cursors.Default;
            this.imageProcessBox1.Dock = DockStyle.Fill;
            this.imageProcessBox1.ForeColor = Color.White;
            this.imageProcessBox1.Location = new Point(0, 0);
            this.imageProcessBox1.Name = "imageProcessBox1";
            this.imageProcessBox1.Size = new Size(0x16b, 0xf7);
            this.imageProcessBox1.TabIndex = 0;
            this.imageProcessBox1.Text = "imageProcessBox1";
            this.imageProcessBox1.Paint += new PaintEventHandler(this.imageProcessBox1_Paint);
            this.imageProcessBox1.DoubleClick += new EventHandler(this.imageProcessBox1_DoubleClick);
            this.imageProcessBox1.MouseDown += new MouseEventHandler(this.imageProcessBox1_MouseDown);
            this.imageProcessBox1.MouseMove += new MouseEventHandler(this.imageProcessBox1_MouseMove);
            this.imageProcessBox1.MouseUp += new MouseEventHandler(this.imageProcessBox1_MouseUp);
            base.AutoScaleMode = AutoScaleMode.None;
            base.ClientSize = new Size(0x16b, 0xf7);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.imageProcessBox1);
            base.Name = "FrmCapture";
            this.Text = "FrmCapture";
            base.Load += new EventHandler(this.FrmCapture_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            this.panel2.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void method_0()
        {
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
            }
            if (this.bitmap_1 != null)
            {
                this.bitmap_1.Dispose();
            }
            foreach (Bitmap bitmap in this.list_0)
            {
                bitmap.Dispose();
            }
            this.list_0.Clear();
            this.imageProcessBox1.method_1();
            GC.Collect();
        }

        private void method_1()
        {
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.panel1.BackColor = Color.White;
            this.panel2.BackColor = Color.White;
            this.panel1.Height = this.tBtn_Finish.Bottom + 3;
            this.panel1.Width = this.tBtn_Finish.Right + 3;
            this.panel2.Height = this.colorBox1.Height;
            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);
            this.tBtn_Rect.Click += new EventHandler(this.tBtn_Text_Click);
            this.tBtn_Ellipse.Click += new EventHandler(this.tBtn_Text_Click);
            this.tBtn_Arrow.Click += new EventHandler(this.tBtn_Text_Click);
            this.tBtn_Brush.Click += new EventHandler(this.tBtn_Text_Click);
            this.tBtn_Text.Click += new EventHandler(this.tBtn_Text_Click);
            this.tBtn_Close.Click += new EventHandler(this.tBtn_Close_Click);
            this.textBox1.BorderStyle = BorderStyle.None;
            this.textBox1.Visible = false;
            this.textBox1.ForeColor = Color.Red;
            this.colorBox1.method_1(new ColorBox.Delegate0(this.method_13));
        }

        [CompilerGenerated]
        private void method_10(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        [CompilerGenerated]
        private void method_11(object sender, FormClosingEventArgs e)
        {
            this.mouseHook_0.UnLoadHook();
            this.method_0();
        }

        [CompilerGenerated]
        private void method_12(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        [CompilerGenerated]
        private void method_13(object sender, ColorChangedEventArgs e)
        {
            this.textBox1.ForeColor = e.Color;
        }

        [CompilerGenerated]
        private void method_14()
        {
            base.Enabled = false;
        }

        [CompilerGenerated]
        private void method_15()
        {
            this.method_3();
        }

        [CompilerGenerated]
        private void method_16()
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        [CompilerGenerated]
        private void method_17()
        {
            this.method_3();
        }

        private void method_2(object sender, MHookEventArgs e)
        {
            MethodInvoker method = null;
            ThreadStart start = null;
            if (!base.Enabled)
            {
                this.imageProcessBox1.method_10(Control.MousePosition.X, Control.MousePosition.Y);
            }
            if ((e.MButton == ButtonStatus.LeftDown) || (e.MButton == ButtonStatus.RightDown))
            {
                base.Enabled = true;
                this.imageProcessBox1.Boolean_0 = true;
            }
            if ((e.MButton == ButtonStatus.RightUp) && ((!this.imageProcessBox1.Boolean_4 && !base.IsDisposed) && base.Created))
            {
                if (method == null)
                {
                    method = new MethodInvoker(this.method_16);
                }
                base.BeginInvoke(method);
            }
            if (!base.Enabled && this.bool_3)
            {
                this.bool_3 = false;
                if (start == null)
                {
                    start = new ThreadStart(this.method_17);
                }
                new Thread(start).Start();
            }
        }

        private void method_3()
        {
            // This item is obfuscated and can not be translated.
            DSkin.POINT pt = new DSkin.POINT {
                x = Control.MousePosition.X,
                y = Control.MousePosition.Y
            };
            IntPtr pHwnd = DSkin.NativeMethods.ChildWindowFromPointEx(DSkin.NativeMethods.GetDesktopWindow(), pt, 3);
            if (pHwnd != IntPtr.Zero)
            {
                IntPtr hWnd = pHwnd;
                while (true)
                {
                    DSkin.NativeMethods.ScreenToClient(hWnd, ref pt);
                    hWnd = DSkin.NativeMethods.ChildWindowFromPointEx(pHwnd, pt, 1);
                    if (hWnd == IntPtr.Zero)
                    {
                    }
                    if (0 == 0)
                    {
                        DSkin.RECT lpRect = new DSkin.RECT();
                        DSkin.NativeMethods.GetWindowRect(pHwnd, ref lpRect);
                        this.imageProcessBox1.method_6(new Rectangle(lpRect.Left, lpRect.Top, lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top));
                        break;
                    }
                    pHwnd = hWnd;
                    pt.x = Control.MousePosition.X;
                    pt.y = Control.MousePosition.Y;
                }
            }
            this.bool_3 = true;
        }

        private void method_4()
        {
            int left = this.imageProcessBox1.Rectangle_0.Left;
            int num2 = this.imageProcessBox1.Rectangle_0.Bottom + 5;
            int num3 = this.panel2.Visible ? (this.panel2.Height + 2) : 0;
            if (((num2 + this.panel1.Height) + num3) >= base.Height)
            {
                num2 = ((this.imageProcessBox1.Rectangle_0.Top - this.panel1.Height) - 10) - this.imageProcessBox1.Font.Height;
            }
            if ((num2 - num3) <= 0)
            {
                if (((this.imageProcessBox1.Rectangle_0.Top - 5) - this.imageProcessBox1.Font.Height) >= 0)
                {
                    num2 = this.imageProcessBox1.Rectangle_0.Top + 5;
                }
                else
                {
                    num2 = (this.imageProcessBox1.Rectangle_0.Top + 10) + this.imageProcessBox1.Font.Height;
                }
            }
            if ((left + this.panel1.Width) >= base.Width)
            {
                left = (base.Width - this.panel1.Width) - 5;
            }
            this.panel1.Left = left;
            this.panel2.Left = left;
            this.panel1.Top = num2;
            this.panel2.Top = (this.imageProcessBox1.Rectangle_0.Top > num2) ? (num2 - num3) : (this.panel1.Bottom + 2);
        }

        private bool method_5()
        {
            return (((this.tBtn_Rect.IsSelected || this.tBtn_Ellipse.IsSelected) || (this.tBtn_Arrow.IsSelected || this.tBtn_Brush.IsSelected)) || this.tBtn_Text.IsSelected);
        }

        private void method_6()
        {
            this.tBtn_Text.IsSelected = false;
            this.tBtn_Brush.IsSelected = false;
            this.tBtn_Arrow.IsSelected = false;
            this.tBtn_Ellipse.IsSelected = false;
            this.tBtn_Rect.IsSelected = false;
        }

        private void method_7()
        {
            if (!base.IsDisposed)
            {
                using (Graphics graphics = Graphics.FromImage(this.bitmap_0))
                {
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawImage(this.bitmap_1, 0, 0);
                }
                Bitmap item = this.bitmap_0.Clone() as Bitmap;
                this.list_0.Add(item);
            }
        }

        private string method_8()
        {
            DateTime now = DateTime.Now;
            return (now.Date.ToShortDateString().Replace("/", "") + "_" + now.ToLongTimeString().Replace(":", ""));
        }

        [CompilerGenerated]
        private void method_9(object sender, EventArgs e)
        {
            this.mouseHook_0.UnLoadHook();
            this.method_0();
        }

        [CompilerGenerated]
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.SteelBlue, 0, 0, this.panel1.Width - 1, this.panel1.Height - 1);
        }

        [CompilerGenerated]
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.SteelBlue, 0, 0, this.panel2.Width - 1, this.panel2.Height - 1);
        }

        private static Bitmap smethod_0(bool bool_4, bool bool_5)
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            if (bool_4)
            {
                DrawCurToScreen();
            }
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                if (!bool_5)
                {
                    return bitmap;
                }
                using (Image image = Clipboard.GetImage())
                {
                    if (image != null)
                    {
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                        {
                            graphics.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
                            graphics.DrawImage(image, (bitmap.Width - image.Width) >> 1, (bitmap.Height - image.Height) >> 1, image.Width, image.Height);
                        }
                    }
                }
            }
            return bitmap;
        }

        private void tBtn_Cancel_Click(object sender, EventArgs e)
        {
            using (Graphics graphics = Graphics.FromImage(this.bitmap_1))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.Clear(Color.Transparent);
            }
            if (this.list_0.Count > 0)
            {
                this.list_0.RemoveAt(this.list_0.Count - 1);
                if (this.list_0.Count > 0)
                {
                    this.bitmap_0 = this.list_0[this.list_0.Count - 1].Clone() as Bitmap;
                }
                else
                {
                    this.bitmap_0 = this.imageProcessBox1.method_11();
                }
                this.imageProcessBox1.Invalidate();
                this.imageProcessBox1.Boolean_7 = (this.list_0.Count == 0) && !this.method_5();
            }
            else
            {
                base.Enabled = false;
                this.imageProcessBox1.method_5();
                this.imageProcessBox1.Boolean_0 = false;
                this.panel1.Visible = false;
                this.panel2.Visible = false;
            }
        }

        [CompilerGenerated]
        private void tBtn_Close_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void tBtn_Finish_Click(object sender, EventArgs e)
        {
            if (this.bitmap_0 != null)
            {
                Clipboard.SetImage(this.bitmap_0);
                if (this.richTextBox_0 != null)
                {
                    this.richTextBox_0.Paste();
                }
            }
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void tBtn_Out_Click(object sender, EventArgs e)
        {
            new FrmOut(this.bitmap_0.Clone() as Bitmap).Show();
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void tBtn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg",
                FilterIndex = 2,
                FileName = "CAPTURE_" + this.method_8()
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                switch (dialog.FilterIndex)
                {
                    case 1:
                        this.bitmap_0.Clone(new Rectangle(0, 0, this.bitmap_0.Width, this.bitmap_0.Height), PixelFormat.Format24bppRgb).Save(dialog.FileName, ImageFormat.Bmp);
                        base.DialogResult = DialogResult.OK;
                        base.Close();
                        break;

                    case 2:
                        this.bitmap_0.Save(dialog.FileName, ImageFormat.Jpeg);
                        base.DialogResult = DialogResult.OK;
                        base.Close();
                        break;
                }
            }
        }

        private void tBtn_Text_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = ((Control1) sender).IsSelected;
            if (this.panel2.Visible)
            {
                this.imageProcessBox1.Boolean_7 = false;
            }
            else
            {
                this.imageProcessBox1.Boolean_7 = this.list_0.Count == 0;
            }
            this.method_4();
        }

        private void textBox1_Resize(object sender, EventArgs e)
        {
            int num = 10;
            if (this.toolButton2.IsSelected)
            {
                num = 12;
            }
            if (this.toolButton3.IsSelected)
            {
                num = 14;
            }
            if (this.textBox1.Font.Height != num)
            {
                this.textBox1.Font = new Font(this.Font.FontFamily, (float) num);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(this.textBox1.Text, this.textBox1.Font);
            this.textBox1.Size = size.IsEmpty ? new Size(50, this.textBox1.Font.Height) : size;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            this.textBox1.Visible = false;
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                this.textBox1.Text = "";
            }
            else
            {
                using (Graphics graphics = Graphics.FromImage(this.bitmap_0))
                {
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    SolidBrush brush = new SolidBrush(this.colorBox1.method_0());
                    graphics.DrawString(this.textBox1.Text, this.textBox1.Font, brush, (float) (this.textBox1.Left - this.imageProcessBox1.Rectangle_0.Left), (float) (this.textBox1.Top - this.imageProcessBox1.Rectangle_0.Top));
                    brush.Dispose();
                    this.textBox1.Text = "";
                    this.method_7();
                    this.imageProcessBox1.Invalidate();
                }
            }
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            if (!base.Enabled)
            {
                this.imageProcessBox1.method_10(Control.MousePosition.X, Control.MousePosition.Y);
            }
        }

        public Bitmap BmpLayerCurrent
        {
            get
            {
                return this.bitmap_0;
            }
            set
            {
                this.bitmap_0 = value;
            }
        }

        public Color ImgProcessBoxDotColor
        {
            get
            {
                return this.imageProcessBox1.Color_0;
            }
            set
            {
                this.imageProcessBox1.Color_0 = value;
            }
        }

        public bool ImgProcessBoxIsShowInfo
        {
            get
            {
                return this.imageProcessBox1.Boolean_2;
            }
            set
            {
                this.imageProcessBox1.Boolean_2 = value;
            }
        }

        public Color ImgProcessBoxLineColor
        {
            get
            {
                return this.imageProcessBox1.Color_1;
            }
            set
            {
                this.imageProcessBox1.Color_1 = value;
            }
        }

        public Size ImgProcessBoxMagnifySize
        {
            get
            {
                return this.imageProcessBox1.Size_0;
            }
            set
            {
                this.imageProcessBox1.Size_0 = value;
            }
        }

        public int ImgProcessBoxMagnifyTimes
        {
            get
            {
                return this.imageProcessBox1.Int32_0;
            }
            set
            {
                this.imageProcessBox1.Int32_0 = value;
            }
        }

        public bool IsCaptureCursor
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public bool IsFromClipBoard
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }
    }
}

