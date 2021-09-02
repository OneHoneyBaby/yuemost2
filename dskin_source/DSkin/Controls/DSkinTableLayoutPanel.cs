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
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;

    public class DSkinTableLayoutPanel : TableLayoutPanel, ILayered, IDuiContainer, IDuiDesigner, ILayeredContainer
    {
        private DSkinPen dskinPen_0 = null;
        private DuiBaseControl duiBaseControl_0;
        private Image image_0 = Resources.smethod_31();
        private ScrollBarHelper scrollBarHelper_0;

        public event EventHandler<InvalidateEventArgs> LayeredInvalidated;

        [Description("层控件需要重绘时发生")]
        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        public DSkinTableLayoutPanel()
        {
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.BackColor = Color.Transparent;
            this.InnerDuiControl.Parent = this;
            this.duiBaseControl_0.method_12(this);
            this.InnerDuiControl.ParentInvalidate = false;
            this.InnerDuiControl.Invalidated += new EventHandler<InvalidateEventArgs>(this.method_5);
            this.InnerDuiControl.Paint += new EventHandler<PaintEventArgs>(this.method_6);
            this.InnerDuiControl.PrePaint += new EventHandler<PaintEventArgs>(this.method_0);
        }

        protected override void Dispose(bool disposing)
        {
            this.InnerDuiControl.Dispose();
            base.Dispose(disposing);
        }

        public void DisposeCanvas()
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

        private void method_0(object sender, PaintEventArgs e)
        {
            if (this.dskinPen_0 != null)
            {
                int num4;
                Pen pen = this.dskinPen_0.Pen;
                Graphics graphics = e.Graphics;
                graphics.DrawLine(pen, new Point((int) (pen.Width / 2f), 0), new Point((int) (pen.Width / 2f), base.Height));
                graphics.DrawLine(pen, new Point(0, (int) (pen.Width / 2f)), new Point(base.Width, (int) (pen.Width / 2f)));
                float num = 0f;
                float width = base.Width;
                for (num4 = 0; num4 < base.ColumnStyles.Count; num4++)
                {
                    ColumnStyle style = base.ColumnStyles[num4];
                    if (style.SizeType == SizeType.Absolute)
                    {
                        num += style.Width;
                        width -= style.Width;
                    }
                    else
                    {
                        num += (style.Width * width) / 100f;
                    }
                    if (num4 == (base.ColumnStyles.Count - 1))
                    {
                        num -= pen.Width / 2f;
                    }
                    graphics.DrawLine(pen, new Point((int) num, 0), new Point((int) num, base.Height));
                }
                float num3 = 0f;
                width = base.Height;
                for (num4 = 0; num4 < base.RowStyles.Count; num4++)
                {
                    RowStyle style2 = base.RowStyles[num4];
                    if (style2.SizeType == SizeType.Absolute)
                    {
                        num3 += style2.Height;
                        width -= style2.Height;
                    }
                    else
                    {
                        num3 += (style2.Height * width) / 100f;
                    }
                    if (num4 == (base.RowStyles.Count - 1))
                    {
                        num3 -= pen.Width / 2f;
                    }
                    graphics.DrawLine(pen, new Point(0, (int) num3), new Point(base.Width, (int) num3));
                }
            }
        }

        private int method_1()
        {
            int num = 0x11;
            if (base.BorderStyle == BorderStyle.Fixed3D)
            {
                return (num + 2);
            }
            if (base.BorderStyle == BorderStyle.FixedSingle)
            {
                num++;
            }
            return num;
        }

        private void method_2(object sender, EventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                Control control = sender as Control;
                this.Invalidate(control.Bounds);
            }
        }

        private void method_3(object sender, InvalidateEventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                Control control = sender as Control;
                Rectangle invalidRect = e.InvalidRect;
                invalidRect.Offset(control.Location);
                this.Invalidate(invalidRect);
            }
        }

        private void method_4(object sender, EventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                this.Invalidate();
            }
        }

        private void method_5(object sender, InvalidateEventArgs e)
        {
            this.OnLayeredInvalidated(e);
            if (!(base.DesignMode || this.IsLayeredMode))
            {
                base.Invalidate(e.InvalidRect);
            }
        }

        private void method_6(object sender, PaintEventArgs e)
        {
            this.OnLayeredPaint(e);
            if (!base.DesignMode && this.IsLayeredMode)
            {
                Graphics graphics = e.Graphics;
                Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
                for (int i = base.Controls.Count - 1; i >= 0; i--)
                {
                    Control control = base.Controls[i];
                    ControlRender.smethod_0(control, control.Bounds, graphics, e.ClipRectangle, rectangle);
                }
                if (((base.VScroll && base.HScroll) && ((this.DuiScrollBar_1 != null) && (this.DuiScrollBar_0 != null))) && (this.image_0 != null))
                {
                    graphics.DrawImage(this.image_0, base.Width - this.DuiScrollBar_0.Width, base.Height - this.DuiScrollBar_1.Height, this.DuiScrollBar_0.Width, this.DuiScrollBar_1.Height);
                }
            }
        }

        private void method_7()
        {
            this.scrollBarHelper_0 = new ScrollBarHelper(this);
            this.scrollBarHelper_0.RightBottom = this.image_0;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!base.DesignMode)
            {
                if (e.Control is ILayeredContainer)
                {
                    ((ILayeredContainer) e.Control).LayeredInvalidated += new EventHandler<InvalidateEventArgs>(this.method_3);
                }
                else
                {
                    e.Control.Invalidated += new InvalidateEventHandler(this.method_3);
                }
                e.Control.Move += new EventHandler(this.method_4);
                e.Control.VisibleChanged += new EventHandler(this.method_2);
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
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!base.DesignMode)
            {
                this.method_7();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (this.scrollBarHelper_0 != null)
            {
                this.scrollBarHelper_0.Dispose();
                this.scrollBarHelper_0 = null;
            }
            base.OnHandleDestroyed(e);
        }

        protected virtual void OnLayeredInvalidated(InvalidateEventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected virtual void OnLayeredPaint(PaintEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (!this.IsLayeredMode)
            {
                this.Invalidate();
            }
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
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.Clip = new Region(e.ClipRectangle);
                    graphics.DrawImage(this.Canvas, new Rectangle(0, 0, base.Width, base.Height), 0, 0, base.Width, base.Height, GraphicsUnit.Pixel, this.ImageAttribute);
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

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            if (!this.IsLayeredMode)
            {
                this.Invalidate();
            }
        }

        public void PaintControl(Graphics g, Rectangle invalidateRect)
        {
            this.InnerDuiControl.PaintControl(g, invalidateRect);
        }

        private static void smethod_0(TableLayoutPanelCellBorderStyle tableLayoutPanelCellBorderStyle_0, Graphics graphics_0, Rectangle rectangle_0)
        {
            Pen pen;
            switch (tableLayoutPanelCellBorderStyle_0)
            {
                case TableLayoutPanelCellBorderStyle.Single:
                    graphics_0.DrawRectangle(SystemPens.ControlDark, rectangle_0);
                    break;

                case TableLayoutPanelCellBorderStyle.Inset:
                    using (pen = new Pen(SystemColors.Window))
                    {
                        graphics_0.DrawLine(pen, rectangle_0.X, rectangle_0.Y, (rectangle_0.X + rectangle_0.Width) - 1, rectangle_0.Y);
                        graphics_0.DrawLine(pen, rectangle_0.X, rectangle_0.Y, rectangle_0.X, (rectangle_0.Y + rectangle_0.Height) - 1);
                    }
                    graphics_0.DrawLine(SystemPens.ControlDark, (rectangle_0.X + rectangle_0.Width) - 1, rectangle_0.Y, (rectangle_0.X + rectangle_0.Width) - 1, (rectangle_0.Y + rectangle_0.Height) - 1);
                    graphics_0.DrawLine(SystemPens.ControlDark, rectangle_0.X, (rectangle_0.Y + rectangle_0.Height) - 1, (rectangle_0.X + rectangle_0.Width) - 1, (rectangle_0.Y + rectangle_0.Height) - 1);
                    break;

                case TableLayoutPanelCellBorderStyle.InsetDouble:
                    graphics_0.DrawRectangle(SystemPens.Control, rectangle_0);
                    rectangle_0 = new Rectangle(rectangle_0.X + 1, rectangle_0.Y + 1, rectangle_0.Width - 1, rectangle_0.Height - 1);
                    using (pen = new Pen(SystemColors.Window))
                    {
                        graphics_0.DrawLine(pen, rectangle_0.X, rectangle_0.Y, (rectangle_0.X + rectangle_0.Width) - 1, rectangle_0.Y);
                        graphics_0.DrawLine(pen, rectangle_0.X, rectangle_0.Y, rectangle_0.X, (rectangle_0.Y + rectangle_0.Height) - 1);
                    }
                    graphics_0.DrawLine(SystemPens.ControlDark, (rectangle_0.X + rectangle_0.Width) - 1, rectangle_0.Y, (rectangle_0.X + rectangle_0.Width) - 1, (rectangle_0.Y + rectangle_0.Height) - 1);
                    graphics_0.DrawLine(SystemPens.ControlDark, rectangle_0.X, (rectangle_0.Y + rectangle_0.Height) - 1, (rectangle_0.X + rectangle_0.Width) - 1, (rectangle_0.Y + rectangle_0.Height) - 1);
                    break;

                case TableLayoutPanelCellBorderStyle.Outset:
                {
                    graphics_0.DrawLine(SystemPens.ControlDark, rectangle_0.X, rectangle_0.Y, (rectangle_0.X + rectangle_0.Width) - 1, rectangle_0.Y);
                    graphics_0.DrawLine(SystemPens.ControlDark, rectangle_0.X, rectangle_0.Y, rectangle_0.X, (rectangle_0.Y + rectangle_0.Height) - 1);
                    using (pen = new Pen(SystemColors.Window))
                    {
                        graphics_0.DrawLine(pen, (rectangle_0.X + rectangle_0.Width) - 1, rectangle_0.Y, (rectangle_0.X + rectangle_0.Width) - 1, (rectangle_0.Y + rectangle_0.Height) - 1);
                        graphics_0.DrawLine(pen, rectangle_0.X, (rectangle_0.Y + rectangle_0.Height) - 1, (rectangle_0.X + rectangle_0.Width) - 1, (rectangle_0.Y + rectangle_0.Height) - 1);
                        break;
                    }
                }
                case TableLayoutPanelCellBorderStyle.OutsetDouble:
                case TableLayoutPanelCellBorderStyle.OutsetPartial:
                    graphics_0.DrawRectangle(SystemPens.Control, rectangle_0);
                    rectangle_0 = new Rectangle(rectangle_0.X + 1, rectangle_0.Y + 1, rectangle_0.Width - 1, rectangle_0.Height - 1);
                    graphics_0.DrawLine(SystemPens.ControlDark, rectangle_0.X, rectangle_0.Y, (rectangle_0.X + rectangle_0.Width) - 1, rectangle_0.Y);
                    graphics_0.DrawLine(SystemPens.ControlDark, rectangle_0.X, rectangle_0.Y, rectangle_0.X, (rectangle_0.Y + rectangle_0.Height) - 1);
                    using (pen = new Pen(SystemColors.Window))
                    {
                        graphics_0.DrawLine(pen, (rectangle_0.X + rectangle_0.Width) - 1, rectangle_0.Y, (rectangle_0.X + rectangle_0.Width) - 1, (rectangle_0.Y + rectangle_0.Height) - 1);
                        graphics_0.DrawLine(pen, rectangle_0.X, (rectangle_0.Y + rectangle_0.Height) - 1, (rectangle_0.X + rectangle_0.Width) - 1, (rectangle_0.Y + rectangle_0.Height) - 1);
                    }
                    break;
            }
        }

        private static void smethod_1(TableLayoutPanelCellBorderStyle tableLayoutPanelCellBorderStyle_0, Graphics graphics_0, Rectangle rectangle_0)
        {
            Pen pen;
            int x = rectangle_0.X;
            int y = rectangle_0.Y;
            int right = rectangle_0.Right;
            int bottom = rectangle_0.Bottom;
            switch (tableLayoutPanelCellBorderStyle_0)
            {
                case TableLayoutPanelCellBorderStyle.Inset:
                case TableLayoutPanelCellBorderStyle.InsetDouble:
                {
                    graphics_0.DrawLine(SystemPens.ControlDark, x, y, right - 1, y);
                    graphics_0.DrawLine(SystemPens.ControlDark, x, y, x, bottom - 1);
                    using (pen = new Pen(SystemColors.Window))
                    {
                        graphics_0.DrawLine(pen, right - 1, y, right - 1, bottom - 1);
                        graphics_0.DrawLine(pen, x, bottom - 1, right - 1, bottom - 1);
                        break;
                    }
                }
                case TableLayoutPanelCellBorderStyle.Outset:
                case TableLayoutPanelCellBorderStyle.OutsetDouble:
                case TableLayoutPanelCellBorderStyle.OutsetPartial:
                    using (pen = new Pen(SystemColors.Window))
                    {
                        graphics_0.DrawLine(pen, x, y, right - 1, y);
                        graphics_0.DrawLine(pen, x, y, x, bottom - 1);
                    }
                    graphics_0.DrawLine(SystemPens.ControlDark, right - 1, y, right - 1, bottom - 1);
                    graphics_0.DrawLine(SystemPens.ControlDark, x, bottom - 1, right - 1, bottom - 1);
                    break;
            }
        }

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

        [TypeConverter(typeof(BordersPropertyOrderConverter)), Category("DSkin"), Description("控件边框"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

        [Description("表格边框画笔"), DefaultValue((string) null)]
        public DSkinPen CellBorderPen
        {
            get
            {
                return this.dskinPen_0;
            }
            set
            {
                if (this.dskinPen_0 != value)
                {
                    this.dskinPen_0 = value;
                    this.Invalidate();
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TableLayoutPanelCellBorderStyle CellBorderStyle
        {
            get
            {
                return base.CellBorderStyle;
            }
            set
            {
                base.CellBorderStyle = value;
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

        [Description("是否绘制禁用效果，如果为true，控件将会设置位图缓存BitmapCache为true"), DefaultValue(false)]
        public bool DrawDisabled
        {
            get
            {
                return this.InnerDuiControl.DrawDisabled;
            }
            set
            {
                this.InnerDuiControl.DrawDisabled = value;
            }
        }

        [Description("背景渲染"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin")]
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

        [Category("DSkin"), Description("DirectUI控件集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DuiControlCollection DuiControlCollection_0
        {
            get
            {
                return this.InnerDuiControl.Controls;
            }
        }

        [Browsable(false)]
        public DuiScrollBar DuiScrollBar_0
        {
            get
            {
                return this.scrollBarHelper_0.DuiScrollBar_0;
            }
        }

        [Browsable(false)]
        public DuiScrollBar DuiScrollBar_1
        {
            get
            {
                return this.scrollBarHelper_0.DuiScrollBar_1;
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
                this.InnerDuiControl.Font = value;
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
                this.InnerDuiControl.ForeColor = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [Description("右下角图片，左右滚动条显示之后才有显示")]
        public Image RightBottom
        {
            get
            {
                return this.image_0;
            }
            set
            {
                this.image_0 = value;
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

