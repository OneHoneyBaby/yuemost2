namespace DSkin.Forms
{
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class SystemButton
    {
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private Color color_0;
        private Color color_1;
        private Color color_2;
        private Color color_3;
        private Color color_4;
        private Color color_5;
        private Color color_6;
        private Color color_7;
        private Color color_8;
        private DSkinForm dskinForm_0;
        private System.Drawing.Image image_0;
        private System.Drawing.Image image_1;
        private System.Drawing.Image image_2;
        private System.Drawing.Image image_3;
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;
        private DSkin.Common.RoundStyle roundStyle_0;
        private System.Drawing.Size size_0;
        private System.Drawing.Size size_1;
        private string string_0;
        private string string_1;
        private SystemButtonTypes systemButtonTypes_0;
        private Point zrrrscRkIs;

        [Browsable(false)]
        public event EventHandler<SystemButtonMouseClickEventArgs> MouseClick;

        public SystemButton()
        {
            this.size_0 = new System.Drawing.Size(30, 30);
            this.zrrrscRkIs = new Point();
            this.color_0 = Color.Black;
            this.color_1 = Color.Empty;
            this.color_2 = Color.Empty;
            this.color_3 = Color.Transparent;
            this.color_4 = Color.FromArgb(100, 200, 200, 200);
            this.color_5 = Color.FromArgb(250, 200, 0, 0);
            this.bool_0 = false;
            this.bool_1 = false;
            this.int_0 = 1;
            this.color_6 = Color.Empty;
            this.color_7 = Color.Empty;
            this.color_8 = Color.Empty;
            this.int_1 = 0;
            this.roundStyle_0 = DSkin.Common.RoundStyle.All;
            this.string_1 = string.Empty;
            this.bool_2 = true;
            this.image_3 = null;
            this.size_1 = new System.Drawing.Size();
            this.int_2 = 10;
            this.int_3 = 10;
            this.systemButtonTypes_0 = SystemButtonTypes.None;
        }

        public SystemButton(DSkinForm owner)
        {
            this.size_0 = new System.Drawing.Size(30, 30);
            this.zrrrscRkIs = new Point();
            this.color_0 = Color.Black;
            this.color_1 = Color.Empty;
            this.color_2 = Color.Empty;
            this.color_3 = Color.Transparent;
            this.color_4 = Color.FromArgb(100, 200, 200, 200);
            this.color_5 = Color.FromArgb(250, 200, 0, 0);
            this.bool_0 = false;
            this.bool_1 = false;
            this.int_0 = 1;
            this.color_6 = Color.Empty;
            this.color_7 = Color.Empty;
            this.color_8 = Color.Empty;
            this.int_1 = 0;
            this.roundStyle_0 = DSkin.Common.RoundStyle.All;
            this.string_1 = string.Empty;
            this.bool_2 = true;
            this.image_3 = null;
            this.size_1 = new System.Drawing.Size();
            this.int_2 = 10;
            this.int_3 = 10;
            this.systemButtonTypes_0 = SystemButtonTypes.None;
            this.dskinForm_0 = owner;
            owner.MouseMove += new MouseEventHandler(this.dskinForm_0_MouseMove);
            owner.MouseLeave += new EventHandler(this.dskinForm_0_MouseLeave);
            owner.MouseDown += new MouseEventHandler(this.dskinForm_0_MouseDown);
            owner.MouseUp += new MouseEventHandler(this.dskinForm_0_MouseUp);
        }

        public void DrawButton(Graphics g, Rectangle invalidateRect)
        {
            Pen pen;
            Color color2;
            if (this.image_0 != null)
            {
                System.Drawing.Image image = (!this.IsMouseDown || (this.image_2 == null)) ? ((!this.IsMouseEnter || (this.image_1 == null)) ? this.image_0 : this.image_1) : this.image_2;
                g.DrawImage(image, this.Bounds);
                return;
            }
            Color color3 = (!this.IsMouseDown || !(this.color_5 != Color.Empty)) ? ((!this.IsMouseEnter || !(this.color_4 != Color.Empty)) ? this.color_3 : this.color_4) : this.color_5;
            GraphicsPath path = null;
            Color color = (!this.IsMouseDown || !(this.color_2 != Color.Empty)) ? ((!this.IsMouseEnter || !(this.color_1 != Color.Empty)) ? this.color_0 : this.color_1) : this.color_2;
            if ((color != Color.Empty) && (color != Color.Transparent))
            {
                SolidBrush brush;
                if (this.int_1 > 0)
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    path = GraphicsPathHelper.CreatePath(this.Bounds, this.int_1, this.roundStyle_0, true);
                    using (brush = new SolidBrush(color3))
                    {
                        g.FillPath(brush, path);
                        goto Label_0188;
                    }
                }
                using (brush = new SolidBrush(color3))
                {
                    g.FillRectangle(brush, this.Bounds);
                }
            }
        Label_0188:
            g.SmoothingMode = SmoothingMode.Default;
            if (this.image_3 != null)
            {
                Point location = new Point(this.Location.X + ((this.Size.Width - this.Image.Width) / 2), this.Location.Y + ((this.Size.Height - this.Image.Height) / 2));
                System.Drawing.Size size = this.image_3.Size;
                if (this.size_1 != System.Drawing.Size.Empty)
                {
                    size = this.size_1;
                }
                g.DrawImage(this.image_3, new Rectangle(location, size));
            }
            else
            {
                switch (this.systemButtonTypes_0)
                {
                    case SystemButtonTypes.Close:
                    {
                        using (pen = new Pen(color, 2f))
                        {
                            g.DrawLine(pen, new Point(this.zrrrscRkIs.X + ((this.size_0.Width - this.int_3) / 2), this.zrrrscRkIs.Y + ((this.size_0.Height - this.int_3) / 2)), new Point((this.zrrrscRkIs.X + this.size_0.Width) - ((this.size_0.Width - this.int_3) / 2), (this.zrrrscRkIs.Y + this.size_0.Height) - ((this.size_0.Height - this.int_3) / 2)));
                            g.DrawLine(pen, new Point(this.zrrrscRkIs.X + ((this.size_0.Width - this.int_3) / 2), (this.zrrrscRkIs.Y + this.size_0.Height) - ((this.size_0.Height - this.int_3) / 2)), new Point((this.zrrrscRkIs.X + this.size_0.Width) - ((this.size_0.Width - this.int_3) / 2), this.zrrrscRkIs.Y + ((this.size_0.Height - this.int_3) / 2)));
                            break;
                        }
                    }
                    case SystemButtonTypes.Minimized:
                    {
                        using (pen = new Pen(color, 3f))
                        {
                            g.DrawLine(pen, new Point(this.zrrrscRkIs.X + ((this.size_0.Width - this.int_2) / 2), (this.zrrrscRkIs.Y + (this.size_0.Height / 2)) + 3), new Point((this.zrrrscRkIs.X + this.size_0.Width) - ((this.size_0.Width - this.int_2) / 2), (this.zrrrscRkIs.Y + (this.size_0.Height / 2)) + 3));
                            break;
                        }
                    }
                    case SystemButtonTypes.Maximized:
                        using (pen = new Pen(color, 2f))
                        {
                            g.DrawRectangle(pen, new Rectangle(this.zrrrscRkIs.X + ((this.size_0.Width - this.int_3) / 2), (this.zrrrscRkIs.Y + ((this.size_0.Height - this.int_3) / 2)) + 2, this.int_3, this.int_3 - 2));
                            break;
                        }
                        goto Label_0501;

                    case SystemButtonTypes.Normal:
                        goto Label_0501;
                }
            }
            goto Label_073A;
        Label_0501:
            using (pen = new Pen(color, 2f))
            {
                using (GraphicsPath path2 = new GraphicsPath())
                {
                    Point[] points = new Point[] { new Point((this.zrrrscRkIs.X + (this.size_0.Width / 2)) - 1, (this.zrrrscRkIs.Y + ((this.size_0.Height - this.int_3) / 2)) + 4), new Point((this.zrrrscRkIs.X + (this.size_0.Width / 2)) - 1, this.zrrrscRkIs.Y + ((this.size_0.Height - this.int_3) / 2)), new Point(((this.zrrrscRkIs.X + ((this.size_0.Width - this.int_3) / 2)) + this.int_3) + 1, this.zrrrscRkIs.Y + ((this.size_0.Height - this.int_3) / 2)), new Point(((this.zrrrscRkIs.X + ((this.size_0.Width - this.int_3) / 2)) + this.int_3) + 1, (this.zrrrscRkIs.Y + (this.size_0.Height / 2)) + 2), new Point((this.zrrrscRkIs.X + ((this.size_0.Width - this.int_3) / 2)) + 7, (this.zrrrscRkIs.Y + (this.size_0.Height / 2)) + 2) };
                    path2.AddLines(points);
                    path2.AddRectangle(new Rectangle(this.zrrrscRkIs.X + ((this.size_0.Width - this.int_3) / 2), (this.zrrrscRkIs.Y + ((this.size_0.Height - this.int_3) / 2)) + 4, 7, 6));
                    g.DrawPath(pen, path2);
                }
            }
        Label_073A:
            color2 = (!this.IsMouseDown || !(this.color_8 != Color.Empty)) ? ((!this.IsMouseEnter || !(this.color_7 != Color.Empty)) ? this.color_6 : this.color_7) : this.color_8;
            if (((color2 != Color.Empty) && (color2 != Color.Transparent)) && (this.int_0 > 0))
            {
                if (path == null)
                {
                    path = GraphicsPathHelper.CreatePath(this.Bounds, this.int_1, this.roundStyle_0, true);
                }
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (pen = new Pen(color2, (float) this.int_0))
                {
                    g.DrawPath(pen, path);
                }
            }
            if (path != null)
            {
                path.Dispose();
                path = null;
            }
        }

        private void dskinForm_0_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.bool_1)
            {
                this.IsMouseDown = true;
            }
        }

        private void dskinForm_0_MouseLeave(object sender, EventArgs e)
        {
            this.IsMouseEnter = false;
        }

        private void dskinForm_0_MouseMove(object sender, MouseEventArgs e)
        {
            if (((this.dskinForm_0.ShowSystemButtons && this.dskinForm_0.ControlBox) && this.bool_2) && this.Bounds.Contains(e.Location))
            {
                this.IsMouseEnter = true;
            }
            else
            {
                this.IsMouseEnter = false;
            }
        }

        private void dskinForm_0_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsMouseDown = false;
            if (((this.bool_1 && this.dskinForm_0.ShowSystemButtons) && this.dskinForm_0.Visible) && this.dskinForm_0.ControlBox)
            {
                SystemButtonMouseClickEventArgs args = new SystemButtonMouseClickEventArgs(this, false);
                this.OnMouseClick(args);
                switch (this.systemButtonTypes_0)
                {
                    case SystemButtonTypes.Close:
                        if (!args.Handled)
                        {
                            this.dskinForm_0.Close();
                        }
                        break;

                    case SystemButtonTypes.Minimized:
                        if (!args.Handled && this.dskinForm_0.MinimizeBox)
                        {
                            this.dskinForm_0.WindowState = FormWindowState.Minimized;
                        }
                        break;

                    case SystemButtonTypes.Maximized:
                        if (!args.Handled && (this.dskinForm_0.MaximizeBox && (this.dskinForm_0.WindowState == FormWindowState.Normal)))
                        {
                            this.dskinForm_0.WindowState = FormWindowState.Maximized;
                        }
                        break;

                    case SystemButtonTypes.Normal:
                        if (!args.Handled && (this.dskinForm_0.MaximizeBox && (this.dskinForm_0.WindowState == FormWindowState.Maximized)))
                        {
                            this.dskinForm_0.WindowState = FormWindowState.Normal;
                        }
                        break;
                }
            }
        }

        [CompilerGenerated]
        private void method_0()
        {
            this.dskinForm_0.ToolTip.SetToolTip(this.dskinForm_0, this.string_0);
        }

        protected virtual void OnMouseClick(SystemButtonMouseClickEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        [Description("边框鼠标移入颜色"), DefaultValue(typeof(Color), "")]
        public Color BorderHoverColor
        {
            get
            {
                return this.color_7;
            }
            set
            {
                this.color_7 = value;
            }
        }

        [DefaultValue(typeof(Color), ""), Description("边框颜色")]
        public Color BorderNormalColor
        {
            get
            {
                return this.color_6;
            }
            set
            {
                if (this.color_6 != value)
                {
                    this.color_6 = value;
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate(this.Bounds);
                    }
                }
            }
        }

        [Description("边框鼠标按下颜色"), DefaultValue(typeof(Color), "")]
        public Color BorderPressColor
        {
            get
            {
                return this.color_8;
            }
            set
            {
                this.color_8 = value;
            }
        }

        [Description("边框宽度"), DefaultValue(1)]
        public int BorderWidth
        {
            get
            {
                return this.int_0;
            }
            set
            {
                if (this.int_0 != value)
                {
                    this.int_0 = value;
                    if (value < 0)
                    {
                        this.int_0 = 0;
                    }
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate(this.Bounds);
                    }
                }
            }
        }

        [Browsable(false)]
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(this.zrrrscRkIs, this.size_0);
            }
        }

        [Description("按钮鼠标移入背景色"), DefaultValue(typeof(Color), "100, 200, 200, 200")]
        public Color HoverBackColor
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

        [Description("按钮颜色"), DefaultValue(typeof(Color), "")]
        public Color HoverColor
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

        [Description("按钮鼠标移入图片"), DefaultValue((string) null)]
        public System.Drawing.Image HoverImage
        {
            get
            {
                return this.image_1;
            }
            set
            {
                this.image_1 = value;
            }
        }

        [Description("显示的图标"), DefaultValue((string) null)]
        public System.Drawing.Image Image
        {
            get
            {
                return this.image_3;
            }
            set
            {
                if (this.image_3 != value)
                {
                    this.image_3 = value;
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate();
                    }
                }
            }
        }

        [Description("图标尺寸"), DefaultValue(typeof(System.Drawing.Size), "0,0")]
        public System.Drawing.Size ImageSize
        {
            get
            {
                return this.size_1;
            }
            set
            {
                if (this.size_1 != value)
                {
                    this.size_1 = value;
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate();
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsMouseDown
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                if (this.bool_0 != value)
                {
                    this.bool_0 = value;
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate(this.Bounds);
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsMouseEnter
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                MethodInvoker method = null;
                if (this.bool_1 != value)
                {
                    this.bool_1 = value;
                    if (this.dskinForm_0 != null)
                    {
                        if (value && !string.IsNullOrEmpty(this.string_0))
                        {
                            if (method == null)
                            {
                                method = new MethodInvoker(this.method_0);
                            }
                            this.dskinForm_0.BeginInvoke(method);
                        }
                        else
                        {
                            this.dskinForm_0.ToolTip.RemoveAll();
                        }
                        this.dskinForm_0.Invalidate(this.Bounds);
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Point Location
        {
            get
            {
                return this.zrrrscRkIs;
            }
            set
            {
                this.zrrrscRkIs = value;
            }
        }

        [Category("按钮名称"), DefaultValue("")]
        public string Name
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }

        [Description("按钮背景色"), DefaultValue(typeof(Color), "Transparent")]
        public Color NormalBackColor
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
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate(this.Bounds);
                    }
                }
            }
        }

        [DefaultValue(typeof(Color), "Black"), Description("按钮颜色")]
        public Color NormalColor
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
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate(this.Bounds);
                    }
                }
            }
        }

        [Description("按钮图片"), DefaultValue((string) null)]
        public System.Drawing.Image NormalImage
        {
            get
            {
                return this.image_0;
            }
            set
            {
                if (this.image_0 != value)
                {
                    this.image_0 = value;
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate(this.Bounds);
                    }
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DSkinForm Owner
        {
            get
            {
                return this.dskinForm_0;
            }
            set
            {
                if (this.dskinForm_0 != value)
                {
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.MouseMove -= new MouseEventHandler(this.dskinForm_0_MouseMove);
                        this.dskinForm_0.MouseLeave -= new EventHandler(this.dskinForm_0_MouseLeave);
                        this.dskinForm_0.MouseDown -= new MouseEventHandler(this.dskinForm_0_MouseDown);
                        this.dskinForm_0.MouseUp -= new MouseEventHandler(this.dskinForm_0_MouseUp);
                    }
                    this.dskinForm_0 = value;
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.MouseMove += new MouseEventHandler(this.dskinForm_0_MouseMove);
                        this.dskinForm_0.MouseLeave += new EventHandler(this.dskinForm_0_MouseLeave);
                        this.dskinForm_0.MouseDown += new MouseEventHandler(this.dskinForm_0_MouseDown);
                        this.dskinForm_0.MouseUp += new MouseEventHandler(this.dskinForm_0_MouseUp);
                        this.dskinForm_0.Invalidate();
                    }
                }
            }
        }

        [DefaultValue(typeof(Color), "250, 200, 0, 0"), Description("按钮鼠标按下背景色")]
        public Color PressBackColor
        {
            get
            {
                return this.color_5;
            }
            set
            {
                this.color_5 = value;
            }
        }

        [DefaultValue(typeof(Color), ""), Description("按钮颜色")]
        public Color PressColor
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

        [Description("按钮鼠标按下时的图片"), DefaultValue((string) null)]
        public System.Drawing.Image PressImage
        {
            get
            {
                return this.image_2;
            }
            set
            {
                this.image_2 = value;
            }
        }

        [Description("边框圆角宽度"), DefaultValue(0)]
        public int Radius
        {
            get
            {
                return this.int_1;
            }
            set
            {
                if (this.int_1 != value)
                {
                    this.int_1 = value;
                    if (value < 0)
                    {
                        this.int_1 = 0;
                    }
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate(this.Bounds);
                    }
                }
            }
        }

        [DefaultValue(typeof(DSkin.Common.RoundStyle), "All"), Description("边框圆角类型")]
        public DSkin.Common.RoundStyle RoundStyle
        {
            get
            {
                return this.roundStyle_0;
            }
            set
            {
                if (this.roundStyle_0 != value)
                {
                    this.roundStyle_0 = value;
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate(this.Bounds);
                    }
                }
            }
        }

        [DefaultValue(typeof(System.Drawing.Size), "30,30"), Description("按钮大小")]
        public System.Drawing.Size Size
        {
            get
            {
                return this.size_0;
            }
            set
            {
                if (this.size_0 != value)
                {
                    this.size_0 = value;
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate();
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("按钮类型"), Browsable(false)]
        public SystemButtonTypes SystemButtonType
        {
            get
            {
                return this.systemButtonTypes_0;
            }
            set
            {
                if (this.systemButtonTypes_0 != value)
                {
                    this.systemButtonTypes_0 = value;
                }
            }
        }

        [DefaultValue((string) null), Description("提示文字")]
        public string ToolTip
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool Visible
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                if (this.bool_2 != value)
                {
                    this.bool_2 = value;
                    if (this.dskinForm_0 != null)
                    {
                        this.dskinForm_0.Invalidate();
                    }
                }
            }
        }
    }
}

