namespace DSkin.Controls
{
    using DSkin;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class GClass0 : DateTimePicker, ILayered, IDuiContainer, IDuiDesigner
    {
        private Color color_0;
        private Color color_1;
        private Color color_2;
        private DuiBaseControl duiBaseControl_0;

        [Description("接收到内部虚拟控件发送的任务时发生")]
        public event EventHandler<AcceptTaskEventArgs> AcceptTask;

        [Description("层控件需要重绘时发生")]
        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        public GClass0()
        {
            EventHandler<AcceptTaskEventArgs> handler = null;
            this.color_0 = Color.FromArgb(0, 0xae, 0xdb);
            this.color_1 = Color.Gray;
            this.color_2 = Color.Gray;
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.Selectable, false);
            base.Width = 100;
            base.Height = 100;
            this.InnerDuiControl.Parent = this;
            this.duiBaseControl_0.method_12(this);
            this.InnerDuiControl.PrePaint += new EventHandler<PaintEventArgs>(this.method_1);
            this.InnerDuiControl.SizeChanged += new EventHandler(this.method_0);
            ((DuiLabel) this.InnerDuiControl).TextAlign = ContentAlignment.MiddleLeft;
            ((DuiLabel) this.InnerDuiControl).AutoEllipsis = true;
            ((DuiLabel) this.InnerDuiControl).StringFormat.FormatFlags = StringFormatFlags.LineLimit;
            ((DuiLabel) this.InnerDuiControl).TextInnerPadding = new Padding(2, 0, 15, 0);
            handler = new EventHandler<AcceptTaskEventArgs>(this.method_2);
            this.InnerDuiControl.AcceptTask += handler;
        }

        protected override void Dispose(bool disposing)
        {
            this.InnerDuiControl.Dispose();
            base.Dispose(disposing);
        }

        public virtual void DisposeCanvas()
        {
            this.InnerDuiControl.DisposeCanvas();
        }

        public void Invalidate()
        {
            this.InnerDuiControl.Invalidate();
        }

        public void Invalidate(Rectangle rect)
        {
            this.InnerDuiControl.Invalidate(rect);
        }

        private void method_0(object sender, EventArgs e)
        {
            base.Size = this.InnerDuiControl.Size;
        }

        private void method_1(object sender, PaintEventArgs e)
        {
            this.OnLayeredPaint(e);
        }

        [CompilerGenerated]
        private void method_2(object sender, AcceptTaskEventArgs e)
        {
            this.OnAcceptTask(e);
            if (e.Handled)
            {
                e.object_1 = this;
            }
        }

        protected virtual void OnAcceptTask(AcceptTaskEventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected override void OnCreateControl()
        {
            if (!base.DesignMode)
            {
                Class13.smethod_5();
            }
            else
            {
                Class13.smethod_2();
                if (!Class13.smethod_0())
                {
                    base.Dispose();
                    return;
                }
            }
            base.OnCreateControl();
            this.InnerDuiControl.Text = this.Text;
        }

        protected override void OnFormatChanged(EventArgs e)
        {
            base.OnFormatChanged(e);
            this.InnerDuiControl.Text = this.Text;
        }

        protected virtual void OnLayeredPaint(PaintEventArgs e)
        {
            SolidBrush brush;
            Rectangle rectangle;
            Pen pen;
            Color color = this.color_1;
            if (this.InnerDuiControl.IsMouseEnter)
            {
                color = this.color_0;
            }
            using (pen = new Pen(color))
            {
                rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
                e.Graphics.DrawRectangle(pen, rectangle);
            }
            using (brush = new SolidBrush(this.color_2))
            {
                Point[] pointArray;
                if (base.ShowUpDown)
                {
                    pointArray = new Point[] { new Point(base.Width - 7, (base.Height / 2) - 2), new Point(base.Width - 11, (base.Height / 2) - 7), new Point(base.Width - 15, (base.Height / 2) - 2) };
                    e.Graphics.FillPolygon(brush, pointArray);
                    pointArray = new Point[] { new Point(base.Width - 7, (base.Height / 2) + 2), new Point(base.Width - 11, (base.Height / 2) + 6), new Point(base.Width - 14, (base.Height / 2) + 2) };
                    e.Graphics.FillPolygon(brush, pointArray);
                }
                else
                {
                    pointArray = new Point[] { new Point(base.Width - 0x12, (base.Height / 2) - 2), new Point(base.Width - 7, (base.Height / 2) - 2), new Point(base.Width - 13, (base.Height / 2) + 4) };
                    e.Graphics.FillPolygon(brush, pointArray);
                }
            }
            if (this.ShowCheckBox)
            {
                using (pen = new Pen(color))
                {
                    rectangle = new Rectangle(3, (base.Height / 2) - 6, 12, 12);
                    e.Graphics.DrawRectangle(pen, rectangle);
                }
                if (base.Checked)
                {
                    using (brush = new SolidBrush(Color.Gray))
                    {
                        rectangle = new Rectangle(5, (base.Height / 2) - 4, 9, 9);
                        e.Graphics.FillRectangle(brush, rectangle);
                    }
                }
            }
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (base.DesignMode || !this.IsLayeredMode)
            {
                if (this.BitmapCache)
                {
                    Graphics graphics = e.Graphics;
                    graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    graphics.SetClip(e.ClipRectangle);
                    graphics.DrawImage(this.Canvas, 0, 0);
                }
                else
                {
                    this.PaintControl(e.Graphics, e.ClipRectangle);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            DSkin.RECT r = new DSkin.RECT();
            DSkin.NativeMethods.GetClientRect(base.Handle, ref r);
            Rectangle rectangle = new Rectangle(r.Left, r.Top, r.Right, r.Bottom);
            base.GetType().GetMethod("PaintTransparentBackground", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new System.Type[] { typeof(PaintEventArgs), typeof(Rectangle) }, null).Invoke(this, new object[] { pevent, rectangle });
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.InnerDuiControl.Text = this.Text;
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            this.Invalidate();
        }

        public void PaintControl(Graphics g, Rectangle invalidateRect)
        {
            this.InnerDuiControl.PaintControl(g, invalidateRect);
        }

        [Category("DSKin"), DefaultValue(typeof(Color), "Gray"), Description("箭头颜色")]
        public Color ArrowColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                if (this.color_2 != value)
                {
                    this.color_2 = value;
                    this.Invalidate();
                }
            }
        }

        public override bool AutoSize
        {
            get
            {
                return this.InnerDuiControl.AutoSize;
            }
            set
            {
                this.InnerDuiControl.AutoSize = value;
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override Color BackColor
        {
            get
            {
                return this.InnerDuiControl.BackColor;
            }
            set
            {
                base.BackColor = this.InnerDuiControl.BackColor = value;
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
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

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
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

        [Category("DSkin"), Description("位图缓存，位图缓存不适合大尺寸的控件"), DefaultValue(false)]
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

        [Description("鼠标移入时的边框颜色"), DefaultValue(typeof(Color), "0, 174, 219"), Category("DSKin")]
        public Color BorderHoverColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
            }
        }

        [Description("边框颜色"), DefaultValue(typeof(Color), "Gray"), Category("DSKin")]
        public Color BorderNormalColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                if (this.color_1 != value)
                {
                    this.color_1 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("DSkin"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("控件边框"), TypeConverter(typeof(BordersPropertyOrderConverter))]
        public DSkin.DirectUI.Borders Borders
        {
            get
            {
                return this.InnerDuiControl.Borders;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Bitmap Canvas
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

        public System.Windows.Forms.Cursor Cursor
        {
            get
            {
                return this.InnerDuiControl.Cursor;
            }
            set
            {
                base.Cursor = this.InnerDuiControl.Cursor = value;
            }
        }

        public string CustomFormat
        {
            get
            {
                return base.CustomFormat;
            }
            set
            {
                if (base.CustomFormat != value)
                {
                    base.CustomFormat = value;
                    this.InnerDuiControl.Text = this.Text;
                }
            }
        }

        [Description("背景渲染"), Category("DSkin"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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
                return new DuiLabel();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("DirectUI控件集合"), Category("DSkin")]
        public virtual DuiControlCollection DuiControlCollection_0
        {
            get
            {
                return this.InnerDuiControl.Controls;
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

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        public bool ShowCheckBox
        {
            get
            {
                return base.ShowCheckBox;
            }
            set
            {
                base.ShowCheckBox = value;
                if (base.ShowCheckBox)
                {
                    ((DuiLabel) this.InnerDuiControl).TextInnerPadding = new Padding(0x12, 0, 15, 0);
                }
                else
                {
                    ((DuiLabel) this.InnerDuiControl).TextInnerPadding = new Padding(2, 0, 15, 0);
                }
            }
        }

        [Category("DSkin"), Description("九宫格方式绘制背景图片"), DefaultValue(false)]
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

        [DefaultValue(typeof(Padding), "5,5,5,5"), Description("九宫格图片切割宽度"), Category("DSkin")]
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
    }
}

