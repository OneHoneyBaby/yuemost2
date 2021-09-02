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

    public class GClass1 : FlowLayoutPanel, ILayered, IDuiContainer, IDuiDesigner, ILayeredContainer
    {
        private DuiBaseControl duiBaseControl_0;
        private Image image_0 = Resources.smethod_31();
        private ScrollBarHelper scrollBarHelper_0;

        public event EventHandler<InvalidateEventArgs> LayeredInvalidated;

        [Description("层控件需要重绘时发生")]
        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        public GClass1()
        {
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.BackColor = Color.Transparent;
            this.InnerDuiControl.Parent = this;
            this.duiBaseControl_0.method_12(this);
            this.InnerDuiControl.ParentInvalidate = false;
            this.InnerDuiControl.Invalidated += new EventHandler<InvalidateEventArgs>(this.method_4);
            this.InnerDuiControl.Paint += new EventHandler<PaintEventArgs>(this.method_5);
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

        private int method_0()
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

        private void method_1(object sender, EventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                Control control = sender as Control;
                this.Invalidate(control.Bounds);
            }
        }

        private void method_2(object sender, InvalidateEventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                Control control = sender as Control;
                Rectangle invalidRect = e.InvalidRect;
                invalidRect.Offset(control.Location);
                this.Invalidate(invalidRect);
            }
        }

        private void method_3(object sender, EventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                this.Invalidate();
            }
        }

        private void method_4(object sender, InvalidateEventArgs e)
        {
            this.OnLayeredInvalidated(e);
            if (!(base.DesignMode || this.IsLayeredMode))
            {
                base.Invalidate(e.InvalidRect);
            }
        }

        private void method_5(object sender, PaintEventArgs e)
        {
            this.OnLayeredPaint(e);
            if (!base.DesignMode && this.IsLayeredMode)
            {
                Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
                Graphics graphics = e.Graphics;
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

        private void method_6()
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
                    ((ILayeredContainer) e.Control).LayeredInvalidated += new EventHandler<InvalidateEventArgs>(this.method_2);
                }
                else
                {
                    e.Control.Invalidated += new InvalidateEventHandler(this.method_2);
                }
                e.Control.Move += new EventHandler(this.method_3);
                e.Control.VisibleChanged += new EventHandler(this.method_1);
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
                this.method_6();
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

        [Description("位图缓存，位图缓存不适合大尺寸的控件"), Category("DSkin")]
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

        [Category("DSkin"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("控件边框"), TypeConverter(typeof(BordersPropertyOrderConverter))]
        public DSkin.DirectUI.Borders Borders
        {
            get
            {
                return this.InnerDuiControl.Borders;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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

        [Description("DirectUI控件集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin")]
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

        [DefaultValue(false), Description("九宫格方式绘制背景图片"), Category("DSkin")]
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

        [Description("九宫格图片切割宽度"), DefaultValue(typeof(Padding), "5,5,5,5"), Category("DSkin")]
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

