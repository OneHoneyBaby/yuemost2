namespace DSkin.Controls
{
    using DSkin;
    using DSkin.DirectUI;
    using DSkin.Forms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    [ComVisible(true), Description("支持添加DuiControl"), Designer("DSkin.Design.DuiControlDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null")]
    public class DSkinBaseControl : Control, ILayered, IDuiContainer, IDuiDesigner
    {
        private DuiBaseControl duiBaseControl_0;
        private Padding padding_0;

        [Description("接收到内部虚拟控件发送的任务时发生")]
        public event EventHandler<AcceptTaskEventArgs> AcceptTask;

        [Description("层控件需要重绘时发生")]
        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        public DSkinBaseControl()
        {
            EventHandler handler = null;
            EventHandler<AcceptTaskEventArgs> handler2 = null;
            this.padding_0 = Padding.Empty;
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.Selectable, false);
            this.BackColor = Color.Transparent;
            base.Size = this.InnerDuiControl.Size;
            this.InnerDuiControl.Parent = this;
            this.duiBaseControl_0.method_12(this);
            this.InnerDuiControl.PrePaint += new EventHandler<PaintEventArgs>(this.method_1);
            this.InnerDuiControl.SizeChanged += new EventHandler(this.method_0);
            handler = new EventHandler(this.method_4);
            this.InnerDuiControl.TextChanged += handler;
            handler2 = new EventHandler<AcceptTaskEventArgs>(this.method_5);
            this.InnerDuiControl.AcceptTask += handler2;
        }

        public static bool ControlLayeredMode(Control control)
        {
            object obj2;
            return ((((obj2 = control.TopLevelControl) != null) && (obj2 is DSkinForm)) && (obj2 as DSkinForm).IsLayeredWindowForm);
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
        private string method_2()
        {
            return base.Text;
        }

        [CompilerGenerated]
        private void method_3(string string_0)
        {
            base.Text = string_0;
        }

        [CompilerGenerated]
        private void method_4(object sender, EventArgs e)
        {
            if (this.method_2() != this.InnerDuiControl.Text)
            {
                this.method_3(this.InnerDuiControl.Text);
            }
        }

        [CompilerGenerated]
        private void method_5(object sender, AcceptTaskEventArgs e)
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

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            this.InnerDuiControl.AutoSize = base.AutoSize;
            base.OnAutoSizeChanged(e);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            this.InnerDuiControl.BackColor = base.BackColor;
            base.OnBackColorChanged(e);
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            this.InnerDuiControl.BackgroundImage = base.BackgroundImage;
            base.OnBackgroundImageChanged(e);
        }

        protected override void OnBackgroundImageLayoutChanged(EventArgs e)
        {
            this.InnerDuiControl.BackgroundImageLayout = base.BackgroundImageLayout;
            base.OnBackgroundImageLayoutChanged(e);
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
            this.InnerDuiControl.TriggerLoad();
            base.OnCreateControl();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            this.InnerDuiControl.Font = base.Font;
            base.OnFontChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            this.InnerDuiControl.ForeColor = base.ForeColor;
            base.OnForeColorChanged(e);
        }

        protected virtual void OnLayeredPaint(PaintEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
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
                    graphics.SetClip(e.ClipRectangle);
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

        protected override void OnTextChanged(EventArgs e)
        {
            this.InnerDuiControl.Text = base.Text;
            base.OnTextChanged(e);
        }

        public void PaintControl(Graphics g, Rectangle invalidateRect)
        {
            this.InnerDuiControl.PaintControl(g, invalidateRect);
        }

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg != 0x20) || this.InnerDuiControl.AutoChangedCursor)
            {
                base.WndProc(ref m);
            }
        }

        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [Category("DSkin"), DefaultValue(false), Description("位图缓存，位图缓存不适合大尺寸的控件")]
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

        [Description("控件边框"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), TypeConverter(typeof(BordersPropertyOrderConverter)), Category("DSkin")]
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

        [DefaultValue(typeof(SizeF), "0,0"), Description("虚拟容器继承父级的尺寸百分比"), Category("DSkin")]
        public SizeF DInheritanceSize
        {
            get
            {
                return this.InnerDuiControl.InheritanceSize;
            }
            set
            {
                if (this.InnerDuiControl.InheritanceSize != value)
                {
                    this.InnerDuiControl.InheritanceSize = value;
                }
            }
        }

        [DefaultValue(typeof(Padding), "0,0,0,0"), Description("虚拟容器外边距"), Category("DSkin")]
        public Padding DMargin
        {
            get
            {
                return this.InnerDuiControl.Margin;
            }
            set
            {
                if (this.InnerDuiControl.Margin != value)
                {
                    this.InnerDuiControl.Margin = value;
                }
            }
        }

        [DefaultValue(false), Description("是否绘制禁用效果，如果为true，控件将会设置位图缓存BitmapCache为true")]
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

        [Category("DSkin"), Description("是否绘制焦点框"), DefaultValue(false)]
        public bool DrawFocusRectangle
        {
            get
            {
                return this.InnerDuiControl.DrawFocusRectangle;
            }
            set
            {
                this.InnerDuiControl.DrawFocusRectangle = value;
            }
        }

        [Category("DSkin"), Description("背景渲染"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
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
                return ControlLayeredMode(this);
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

        [Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor))]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
}

