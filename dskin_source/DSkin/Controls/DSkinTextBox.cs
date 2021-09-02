namespace DSkin.Controls
{
    using DSkin;
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxItem(true), ToolboxBitmap(typeof(TextBox))]
    public class DSkinTextBox : TextBox, ILayered, IDuiContainer, IDuiDesigner
    {
        private bool bool_0 = false;
        private bool bool_1 = true;
        private bool bool_2 = false;
        private bool bool_3 = true;
        private Color color_0 = Color.Empty;
        private Color color_1 = Color.Gray;
        private Color color_2 = Color.FromArgb(0x15, 0x83, 0xdd);
        private Color color_3 = Color.Gray;
        private Color color_4 = Color.FromArgb(0x15, 0x83, 0xdd);
        private DuiBaseControl duiBaseControl_0;
        private DuiScrollBar duiScrollBar_0;
        private DuiScrollBar duiScrollBar_1;
        private System.Drawing.Font font_0 = Control.DefaultFont;
        private Point point_0;
        private Point point_1 = new Point();
        private string string_0 = string.Empty;
        private TextRenderingHint textRenderingHint_0 = TextRenderingHint.SystemDefault;
        private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timer_1 = new System.Windows.Forms.Timer();

        [Description("层控件需要重绘时发生")]
        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        public DSkinTextBox()
        {
            DuiScrollBar bar = new DuiScrollBar {
                Orientation = Orientation.Vertical,
                Width = 0x11,
                ArrowHeight = 0x11,
                ArrowScrollBarGap = 7,
                BitmapCache = true,
                BackColor = Color.White
            };
            this.duiScrollBar_0 = bar;
            DuiScrollBar bar2 = new DuiScrollBar {
                Orientation = Orientation.Horizontal,
                Height = 0x11,
                ArrowHeight = 0x11,
                ArrowScrollBarGap = 7,
                BackColor = Color.White
            };
            this.duiScrollBar_1 = bar2;
            this.InnerDuiControl.Parent = this;
            this.duiBaseControl_0.method_12(this);
            this.InnerDuiControl.Cursor = Cursors.IBeam;
            this.InnerDuiControl.PrePaint += new EventHandler<PaintEventArgs>(this.method_1);
            this.InnerDuiControl.Invalidated += new EventHandler<InvalidateEventArgs>(this.method_0);
            this.timer_1 = new System.Windows.Forms.Timer();
            this.timer_1.Interval = 500;
            this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
            this.timer_0.Interval = 50;
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
        }

        public Point CaretPoint()
        {
            Point point = new Point(0);
            int selectionStart = base.SelectionStart;
            IntPtr ptr = new IntPtr(selectionStart);
            int dw = DSkin.NativeMethods.SendMessage(base.Handle, 0xd6, (int) ptr, IntPtr.Zero);
            point = new Point(dw);
            if ((selectionStart == 0) && (base.TextAlign == HorizontalAlignment.Left))
            {
                point = new Point(0);
            }
            else if ((selectionStart >= this.Text.Length) && (selectionStart != 0))
            {
                ptr = new IntPtr(selectionStart - 1);
                dw = DSkin.NativeMethods.SendMessage(base.Handle, 0xd6, (int) ptr, IntPtr.Zero);
                point = new Point(dw);
                Graphics graphics = base.CreateGraphics();
                string text = this.Text.Substring(this.Text.Length - 1, 1) + "X";
                SizeF ef = graphics.MeasureString(text, this.Font);
                SizeF ef2 = graphics.MeasureString("X", this.Font);
                graphics.Dispose();
                int num3 = (int) (ef.Width - ef2.Width);
                point.X += num3;
                if ((selectionStart == this.Text.Length) && (this.Text.Substring(this.Text.Length - 1, 1) == "\n"))
                {
                    point.X = 1;
                    point.Y += base.FontHeight;
                }
            }
            if (base.BorderStyle != BorderStyle.None)
            {
                point.Offset(2, 2);
            }
            else if (base.TextAlign != HorizontalAlignment.Right)
            {
                point.Offset(1, 1);
            }
            if (((base.TextAlign == HorizontalAlignment.Right) && !this.Multiline) && string.IsNullOrEmpty(this.Text))
            {
                return new Point(base.Width - 2, 2);
            }
            if (((base.TextAlign == HorizontalAlignment.Center) && !this.Multiline) && string.IsNullOrEmpty(this.Text))
            {
                point = new Point(base.Width / 2, 2);
            }
            return point;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.timer_0 != null)
            {
                this.timer_0.Dispose();
                this.timer_0 = null;
            }
            if (this.timer_1 != null)
            {
                this.timer_1.Dispose();
                this.timer_1 = null;
            }
            this.InnerDuiControl.Dispose();
            base.Dispose(disposing);
        }

        public void DisposeCanvas()
        {
            this.InnerDuiControl.DisposeCanvas();
        }

        public bool HasHorizontal()
        {
            return ((DSkin.NativeMethods.GetWindowLong(base.Handle, -16) & 0x100000) == 0x100000);
        }

        public bool HasVertical()
        {
            return ((DSkin.NativeMethods.GetWindowLong(base.Handle, -16) & 0x200000) == 0x200000);
        }

        public void Invalidate()
        {
            this.InnerDuiControl.Invalidate();
        }

        public void Invalidate(Rectangle rect)
        {
            this.InnerDuiControl.Invalidate(rect);
        }

        private void method_0(object sender, InvalidateEventArgs e)
        {
            this.OnInvalidated(e);
        }

        private void method_1(object sender, PaintEventArgs e)
        {
            Pen pen;
            Graphics g = e.Graphics;
            if (base.Created && this.IsLayeredMode)
            {
                DSkin.SCROLLINFO scrollinfo;
                SCROLLBARINFO scrollbarinfo;
                GraphicsState state;
                Region clip = g.Clip;
                int num3 = (base.BorderStyle == BorderStyle.None) ? 0 : 4;
                Rectangle rectangle2 = new Rectangle((base.BorderStyle == BorderStyle.None) ? 0 : 2, (base.BorderStyle == BorderStyle.None) ? 0 : 3, base.Width - num3, base.Height - num3);
                rectangle2.Intersect(e.ClipRectangle);
                g.SetClip(rectangle2);
                this.DrawToBitmap(g, new Rectangle(0, 0, base.Width, base.Height), this.color_0);
                g.Clip = clip;
                this.method_2();
                DSkin.RECT lpRect = new DSkin.RECT();
                scrollbarinfo = new SCROLLBARINFO {
                    cbSize = Marshal.SizeOf(scrollbarinfo)
                };
                int systemMetrics = DSkin.NativeMethods.GetSystemMetrics(SYSTEM_METRICS.SM_CXVSCROLL);
                int num = DSkin.NativeMethods.GetSystemMetrics(SYSTEM_METRICS.SM_CYVSCROLL);
                Point point2 = base.PointToScreen(new Point());
                if (this.duiScrollBar_0.Visible)
                {
                    scrollinfo = new DSkin.SCROLLINFO {
                        fMask = 0x17
                    };
                    DSkin.NativeMethods.GetScrollInfo(new HandleRef(this, base.Handle), 1, ref scrollinfo);
                    DSkin.NativeMethods.GetScrollBarInfo(base.Handle, 0xfffffffb, ref scrollbarinfo);
                    lpRect = scrollbarinfo.rcScrollBar;
                    this.duiScrollBar_0.Location = new Point((lpRect.Left + 1) - point2.X, lpRect.Top - point2.Y);
                    DSkin.NativeMethods.OffsetRect(ref lpRect, -lpRect.Left, -lpRect.Top);
                    this.duiScrollBar_0.ScrollBarLenght = scrollbarinfo.xyThumbBottom - scrollbarinfo.xyThumbTop;
                    this.duiScrollBar_0.Maximum = ((int) (scrollinfo.nMax * (1.0 - ((1.0 * this.duiScrollBar_0.ScrollBarLenght) / ((double) (lpRect.Bottom - (num * 2))))))) + 1;
                    this.duiScrollBar_0.Minimum = 0;
                    this.duiScrollBar_0.Value = scrollinfo.nPos;
                    this.duiScrollBar_0.ArrowHeight = num;
                    this.duiScrollBar_0.Size = new Size(lpRect.Right, lpRect.Bottom + 1);
                    state = g.Save();
                    g.SetClip(this.duiScrollBar_0.ClientRectangle);
                    g.Clear(this.BackColor);
                    g.DrawImage(this.duiScrollBar_0.Canvas, this.duiScrollBar_0.Left, this.duiScrollBar_0.Top);
                    g.Restore(state);
                }
                if (this.duiScrollBar_1.Visible)
                {
                    scrollinfo = new DSkin.SCROLLINFO {
                        fMask = 0x17
                    };
                    DSkin.NativeMethods.GetScrollInfo(new HandleRef(this, base.Handle), 0, ref scrollinfo);
                    DSkin.NativeMethods.GetScrollBarInfo(base.Handle, 0xfffffffa, ref scrollbarinfo);
                    lpRect = scrollbarinfo.rcScrollBar;
                    this.duiScrollBar_1.Location = new Point(lpRect.Left - point2.X, lpRect.Top - point2.Y);
                    DSkin.NativeMethods.OffsetRect(ref lpRect, -lpRect.Left, -lpRect.Top);
                    this.duiScrollBar_1.ScrollBarLenght = scrollbarinfo.xyThumbBottom - scrollbarinfo.xyThumbTop;
                    this.duiScrollBar_1.Maximum = ((int) (scrollinfo.nMax * (1.0 - ((1.0 * this.duiScrollBar_1.ScrollBarLenght) / ((double) (lpRect.Right - (systemMetrics * 2))))))) + 1;
                    this.duiScrollBar_1.Minimum = 0;
                    this.duiScrollBar_1.Value = scrollinfo.nPos;
                    this.duiScrollBar_1.ArrowHeight = systemMetrics;
                    this.duiScrollBar_1.Size = new Size(lpRect.Right, lpRect.Bottom);
                    state = g.Save();
                    g.SetClip(this.duiScrollBar_0.ClientRectangle);
                    g.Clear(this.BackColor);
                    g.TranslateTransform((float) this.duiScrollBar_1.Left, (float) this.duiScrollBar_1.Top);
                    Rectangle clientRectangle = this.duiScrollBar_1.ClientRectangle;
                    clientRectangle.Intersect(e.ClipRectangle);
                    clientRectangle.Offset(-this.duiScrollBar_1.Left, -this.duiScrollBar_1.Top);
                    this.duiScrollBar_1.PaintControl(g, clientRectangle);
                    g.Restore(state);
                }
            }
            if ((base.BorderStyle != BorderStyle.None) && (this.color_0 != this.BackColor))
            {
                using (pen = new Pen(this.BackColor, 2f))
                {
                    g.DrawRectangle(pen, new Rectangle(2, 2, base.Width - 4, base.Height - 4));
                }
            }
            if ((string.IsNullOrEmpty(this.Text) && !string.IsNullOrEmpty(this.string_0)) && (!this.bool_2 || (this.bool_2 && this.Focused)))
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb((this.color_1.A == 0xff) ? 0xfe : this.color_1.A, this.color_1)))
                {
                    g.TextRenderingHint = this.textRenderingHint_0;
                    g.DrawString(this.string_0, this.font_0, brush, (PointF) this.WaterTextOffset);
                }
            }
            if (base.BorderStyle != BorderStyle.None)
            {
                if (this.Focused)
                {
                    using (pen = new Pen(this.color_4))
                    {
                        g.DrawRectangle(pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
                        if (this.bool_3)
                        {
                            pen.Color = Color.FromArgb(150, this.color_4);
                            g.DrawRectangle(pen, new Rectangle(1, 1, base.Width - 3, base.Height - 3));
                        }
                        goto Label_0648;
                    }
                }
                using (pen = new Pen(this.InnerDuiControl.IsMouseEnter ? this.color_2 : this.color_3))
                {
                    g.DrawRectangle(pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
                }
            }
        Label_0648:
            if (((base.Created && this.IsLayeredMode) && (this.Focused && (this.SelectionLength == 0))) && this.bool_1)
            {
                Point point = this.CaretPoint();
                Pen pen2 = new Pen(this.ForeColor, 1f);
                g.DrawLine(pen2, point.X, point.Y, point.X, point.Y + base.FontHeight);
            }
            this.OnLayeredPaint(new PaintEventArgs(g, new Rectangle(0, 0, base.Width, base.Height)));
        }

        private void method_2()
        {
            if ((DSkin.NativeMethods.GetWindowLong(base.Handle, -16) & 0x10000000) == 0x10000000)
            {
                this.duiScrollBar_1.Visible = this.HasHorizontal();
                this.duiScrollBar_0.Visible = this.HasVertical();
            }
            else
            {
                this.duiScrollBar_1.Visible = false;
                this.duiScrollBar_0.Visible = false;
            }
        }

        private bool method_3()
        {
            return (this.HasHorizontal() && this.HasVertical());
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.timer_1.Start();
            this.Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            this.bool_1 = true;
            this.Invalidate();
        }

        protected virtual void OnLayeredPaint(PaintEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.bool_0 = false;
            this.timer_0.Stop();
            this.timer_1.Stop();
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.Invalidate();
            this.bool_0 = true;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (((this.bool_0 && (this.point_0 != e.Location)) && !base.DesignMode) && this.IsLayeredMode)
            {
                this.timer_0.Start();
            }
            this.point_0 = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.bool_0 = false;
            this.timer_0.Stop();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (this.Multiline && this.IsLayeredMode)
            {
                this.Invalidate();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        public void PaintControl(Graphics g, Rectangle invalidateRect)
        {
            this.InnerDuiControl.PaintControl(g, invalidateRect);
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void timer_1_Tick(object sender, EventArgs e)
        {
            this.bool_1 = !this.bool_1;
            this.Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (!((((m.Msg == 0x85) || (m.Msg == 15)) || ((m.Msg == 20) || (m.Msg == 0x133))) ? (!base.DesignMode && this.IsLayeredMode) : true))
            {
                IntPtr windowDC = DSkin.NativeMethods.GetWindowDC(m.HWnd);
                if (windowDC.ToInt32() == 0)
                {
                    return;
                }
                using (Graphics graphics = Graphics.FromHdc(windowDC))
                {
                    if (this.BitmapCache)
                    {
                        graphics.SetClip(new Rectangle(0, 0, base.Width, base.Height));
                        graphics.DrawImage(this.InnerDuiControl.Canvas, 0, 0);
                    }
                    else
                    {
                        this.PaintControl(graphics, new Rectangle(0, 0, base.Width, base.Height));
                    }
                    DSkin.NativeMethods.ReleaseDC(m.HWnd, windowDC);
                }
                m.Result = IntPtr.Zero;
            }
            switch (m.Msg)
            {
                case 0x114:
                case 0x115:
                    this.Invalidate();
                    break;
            }
        }

        public override Image BackgroundImage
        {
            get
            {
                return this.InnerDuiControl.BackgroundImage;
            }
            set
            {
                this.InnerDuiControl.BackgroundImage = value;
            }
        }

        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.InnerDuiControl.BackgroundImageLayout;
            }
            set
            {
                this.InnerDuiControl.BackgroundImageLayout = value;
            }
        }

        [Category("DSkin"), Description("位图缓存，位图缓存不适合大尺寸的控件")]
        public bool BitmapCache
        {
            get
            {
                return this.InnerDuiControl.BitmapCache;
            }
            set
            {
                this.InnerDuiControl.BitmapCache = value;
            }
        }

        [Category("DSkin"), DefaultValue(typeof(Color), "Gray"), Description("文本框边框颜色")]
        public Color BorderColor
        {
            get
            {
                return this.color_3;
            }
            set
            {
                if (this.color_3 != value)
                {
                    this.color_3 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("控件边框"), Category("DSkin"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), TypeConverter(typeof(BordersPropertyOrderConverter))]
        public DSkin.DirectUI.Borders Borders
        {
            get
            {
                return this.InnerDuiControl.Borders;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Bitmap Canvas
        {
            get
            {
                return this.InnerDuiControl.Canvas;
            }
            set
            {
                this.InnerDuiControl.Canvas = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("背景渲染"), Category("DSkin")]
        public DSkin.DirectUI.DuiBackgroundRender DuiBackgroundRender
        {
            get
            {
                return this.InnerDuiControl.BackgroundRender;
            }
        }

        protected virtual DuiBaseControl DuiControl
        {
            get
            {
                return new DuiBaseControl();
            }
        }

        [Description("DirectUI控件集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin")]
        public DuiControlCollection DuiControlCollection_0
        {
            get
            {
                return this.InnerDuiControl.Controls;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DuiScrollBar DuiScrollBar_0
        {
            get
            {
                return this.duiScrollBar_0;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DuiScrollBar DuiScrollBar_1
        {
            get
            {
                return this.duiScrollBar_1;
            }
        }

        [Description("获取焦点的时候边框是否加粗"), DefaultValue(true)]
        public bool FocusBorderBold
        {
            get
            {
                return this.bool_3;
            }
            set
            {
                this.bool_3 = value;
            }
        }

        [DefaultValue(typeof(Color), "21, 131, 221"), Category("DSkin"), Description("文本框获得焦点时边框颜色")]
        public Color FocusedBorderColor
        {
            get
            {
                return this.color_4;
            }
            set
            {
                this.color_4 = value;
            }
        }

        [Description("获取焦点隐藏水印"), DefaultValue(false)]
        public bool FocusHideWaterText
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
            }
        }

        public override System.Drawing.Font Font
        {
            get
            {
                return this.InnerDuiControl.Font;
            }
            set
            {
                this.InnerDuiControl.Font = base.Font = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return this.InnerDuiControl.ForeColor;
            }
            set
            {
                this.InnerDuiControl.ForeColor = base.ForeColor = value;
            }
        }

        [Category("DSkin"), Description("鼠标移入时边框的颜色"), DefaultValue(typeof(Color), "21, 131, 221")]
        public Color HoverBorderColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                this.color_2 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ImageAttributes ImageAttribute
        {
            get
            {
                return this.InnerDuiControl.ImageAttribute;
            }
            set
            {
                this.InnerDuiControl.ImageAttribute = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IImageEffect ImageEffect
        {
            get
            {
                return this.InnerDuiControl.ImageEffect;
            }
            set
            {
                this.InnerDuiControl.ImageEffect = value;
            }
        }

        [Browsable(false)]
        public DuiBaseControl InnerDuiControl
        {
            get
            {
                if (this.duiBaseControl_0 == null)
                {
                    this.duiBaseControl_0 = this.DuiControl;
                }
                return this.duiBaseControl_0;
            }
        }

        [Browsable(false)]
        public bool IsLayeredMode
        {
            get
            {
                return DSkinBaseControl.ControlLayeredMode(this);
            }
        }

        [DefaultValue(false), Category("DSkin"), Description("九宫格方式绘制背景图片")]
        public bool SudokuDrawBackImage
        {
            get
            {
                return this.InnerDuiControl.SudokuDrawBackImage;
            }
            set
            {
                this.InnerDuiControl.SudokuDrawBackImage = value;
            }
        }

        [Category("DSkin"), DefaultValue(typeof(Padding), "5,5,5,5"), Description("九宫格图片切割宽度")]
        public Padding SudokuPartitionWidth
        {
            get
            {
                return this.InnerDuiControl.SudokuPartitionWidth;
            }
            set
            {
                this.InnerDuiControl.SudokuPartitionWidth = value;
            }
        }

        [Category("DSkin"), DefaultValue(typeof(Color), "Empty"), Description("定义透明色")]
        public Color TransparencyKey
        {
            get
            {
                return this.color_0;
            }
            set
            {
                if (this.color_0 != value)
                {
                    this.color_0 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "Gray"), Category("DSkin"), Description("水印文字颜色")]
        public Color WaterColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
            }
        }

        [Category("DSkin"), Description("水印文字字体")]
        public System.Drawing.Font WaterFont
        {
            get
            {
                return this.font_0;
            }
            set
            {
                this.font_0 = value;
            }
        }

        [Description("水印文字"), Category("DSkin")]
        public string WaterText
        {
            get
            {
                return this.string_0;
            }
            set
            {
                if (this.string_0 != value)
                {
                    this.string_0 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("DSkin"), Description("水印文字偏移位置")]
        public Point WaterTextOffset
        {
            get
            {
                return this.point_1;
            }
            set
            {
                this.point_1 = value;
            }
        }

        [DefaultValue(typeof(TextRenderingHint), "SystemDefault"), Description("水印文本渲染模式"), Category("DSkin")]
        public TextRenderingHint WaterTextTextRenderMode
        {
            get
            {
                return this.textRenderingHint_0;
            }
            set
            {
                this.textRenderingHint_0 = value;
            }
        }
    }
}

