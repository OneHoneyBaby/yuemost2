namespace DSkin.DirectUI
{
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiScrollBar : DuiBaseControl
    {
        private bool bool_27 = false;
        private bool bool_28 = true;
        private bool bool_29 = true;
        private bool bool_30 = false;
        private Color color_2 = Color.Gray;
        private Color color_3 = Color.FromArgb(0x9e, 0x9e, 0x9e);
        private Color color_4 = Color.FromArgb(80, 80, 80);
        private Color color_5 = Color.Gray;
        private Color color_6 = Color.FromArgb(180, 180, 180);
        private Color color_7 = Color.FromArgb(80, 80, 80);
        private Enum7 EXPYCDIYHA = ((Enum7) 4);
        private Image image_1;
        private Image image_2;
        private Image image_3;
        private int int_1 = 10;
        private int int_10 = 5;
        private int int_11 = 9;
        private int int_2 = 1;
        private int int_3 = 0;
        private int int_4 = 100;
        private int int_5 = 0;
        private int int_6 = 20;
        private int int_7 = 12;
        private int int_8 = 1;
        private int int_9 = 3;
        private System.Windows.Forms.Orientation orientation_0 = System.Windows.Forms.Orientation.Vertical;
        private Padding padding_1 = new Padding(5);
        private Point point_1;
        private Point point_2;

        [Description("Value改变之后发生")]
        public event EventHandler ValueChanged;

        public DuiScrollBar()
        {
            base.Width = 12;
            this.BackColor = Color.FromArgb(200, Color.White);
        }

        private Enum7 method_29()
        {
            return this.EXPYCDIYHA;
        }

        private void method_30(Enum7 value)
        {
            if (this.EXPYCDIYHA != value)
            {
                this.EXPYCDIYHA = value;
                this.Invalidate();
            }
        }

        private Rectangle method_31()
        {
            if (this.int_3 >= this.int_4)
            {
                return new Rectangle(0, 0, 1, 1);
            }
            int num = this.bool_28 ? this.int_7 : this.int_8;
            if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
            {
                return new Rectangle(this.int_8, ((int) (((1.0 * (this.Value - this.Minimum)) / ((double) (this.Maximum - this.Minimum))) * ((base.Height - (num * 2)) - this.ScrollBarLenght))) + num, base.Width - (this.int_8 * 2), this.ScrollBarLenght);
            }
            return new Rectangle(((int) (((1.0 * (this.Value - this.Minimum)) / ((double) (this.Maximum - this.Minimum))) * ((base.Width - (num * 2)) - this.ScrollBarLenght))) + num, this.int_8, this.ScrollBarLenght, base.Height - (this.int_8 * 2));
        }

        private void method_32(MethodInvoker methodInvoker_0)
        {
            <>c__DisplayClassc classc;
            MethodInvoker invoker = methodInvoker_0;
            System.Windows.Forms.Timer sleep = new System.Windows.Forms.Timer {
                Enabled = true,
                Interval = 200
            };
            sleep.Tick += new EventHandler(classc.<ContinuousSetValue>b__a);
        }

        [CompilerGenerated]
        private void method_33()
        {
            this.Value -= this.int_2;
        }

        [CompilerGenerated]
        private void method_34()
        {
            this.Value += this.int_2;
        }

        [CompilerGenerated]
        private void method_35()
        {
            this.Value -= this.int_2;
        }

        [CompilerGenerated]
        private void method_36()
        {
            this.Value += this.int_2;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
            {
                if (e.KeyData == Keys.Left)
                {
                    this.Value -= this.int_1;
                }
                else if (e.KeyData == Keys.Right)
                {
                    this.Value += this.int_1;
                }
            }
            else if (e.KeyData == Keys.Up)
            {
                this.Value -= this.int_1;
            }
            else if (e.KeyData == Keys.Down)
            {
                this.Value += this.int_1;
            }
        }

        protected override void OnMouseDown(DuiMouseEventArgs e)
        {
            MethodInvoker invoker = null;
            MethodInvoker invoker2 = null;
            MethodInvoker invoker3 = null;
            MethodInvoker invoker4 = null;
            base.OnMouseDown(e);
            Rectangle rectangle = this.method_31();
            if (rectangle.Contains(e.Location))
            {
                this.point_1 = e.Location;
                this.point_2 = rectangle.Location;
                this.bool_30 = true;
                this.Invalidate();
            }
            else if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
            {
                if (e.Y < this.ArrowHeight)
                {
                    this.Value -= this.int_2;
                    if (invoker == null)
                    {
                        invoker = new MethodInvoker(this.method_33);
                    }
                    this.method_32(invoker);
                }
                if (e.Y > (base.Height - this.ArrowHeight))
                {
                    this.Value += this.int_2;
                    if (invoker2 == null)
                    {
                        invoker2 = new MethodInvoker(this.method_34);
                    }
                    this.method_32(invoker2);
                }
                else if ((e.Y > this.int_7) && (e.Y < rectangle.Top))
                {
                    this.Value -= this.int_1;
                }
                else if ((e.Y < (base.Height - this.ArrowHeight)) && (e.Y > rectangle.Bottom))
                {
                    this.Value += this.int_1;
                }
            }
            else
            {
                if (e.X < this.ArrowHeight)
                {
                    this.Value -= this.int_2;
                    if (invoker3 == null)
                    {
                        invoker3 = new MethodInvoker(this.method_35);
                    }
                    this.method_32(invoker3);
                }
                if (e.X > (base.Width - this.ArrowHeight))
                {
                    this.Value += this.int_2;
                    if (invoker4 == null)
                    {
                        invoker4 = new MethodInvoker(this.method_36);
                    }
                    this.method_32(invoker4);
                }
                else if ((e.X > this.int_7) && (e.X < rectangle.Left))
                {
                    this.Value -= this.int_1;
                }
                else if ((e.X < (base.Width - this.int_7)) && (e.X > rectangle.Right))
                {
                    this.Value += this.int_1;
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.method_30((Enum7) 4);
        }

        protected override void OnMouseMove(DuiMouseEventArgs e)
        {
            base.OnMouseMove(e);
            Rectangle rectangle = this.method_31();
            if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
            {
                if ((e.Y < this.int_7) && this.bool_28)
                {
                    this.method_30((Enum7) 0);
                }
                else if ((e.Y > (base.Height - this.int_7)) && this.bool_28)
                {
                    this.method_30((Enum7) 1);
                }
                else if (rectangle.Contains(e.Location))
                {
                    this.method_30((Enum7) 2);
                }
                else
                {
                    this.method_30((Enum7) 3);
                }
            }
            else if ((e.X < this.int_7) && this.bool_28)
            {
                this.method_30((Enum7) 0);
            }
            else if ((e.X > (base.Width - this.int_7)) && this.bool_28)
            {
                this.method_30((Enum7) 1);
            }
            else if (rectangle.Contains(e.Location))
            {
                this.method_30((Enum7) 2);
            }
            else
            {
                this.method_30((Enum7) 3);
            }
            if (this.bool_30)
            {
                int num2 = this.bool_28 ? this.int_7 : this.int_8;
                if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
                {
                    int num3 = (this.point_2.Y + e.Y) - this.point_1.Y;
                    this.Value = ((int) (((1.0 * (num3 - num2)) / ((double) ((base.Height - (num2 * 2)) - this.ScrollBarLenght))) * (this.Maximum - this.Minimum))) + this.Minimum;
                }
                else
                {
                    int num = (this.point_2.X + e.X) - this.point_1.X;
                    this.Value = ((int) (((1.0 * (num - num2)) / ((double) ((base.Width - (num2 * 2)) - this.ScrollBarLenght))) * (this.Maximum - this.Minimum))) + this.Minimum;
                }
            }
        }

        protected override void OnMouseUp(DuiMouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.bool_30 = false;
            this.Invalidate();
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            SolidBrush brush;
            base.OnPrePaint(e);
            Graphics g = e.Graphics;
            if (this.bool_28)
            {
                Point[] pointArray;
                Color color2 = this.color_5;
                Color color = this.color_5;
                switch (this.method_29())
                {
                    case ((Enum7) 0):
                        color2 = base.IsMouseDown ? this.color_7 : this.color_6;
                        break;

                    case ((Enum7) 1):
                        color = base.IsMouseDown ? this.color_7 : this.color_6;
                        break;
                }
                if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
                {
                    using (brush = new SolidBrush(color2))
                    {
                        pointArray = new Point[] { new Point(base.Width / 2, ((this.int_7 - this.int_10) - this.int_9) - 1), new Point(((base.Width - this.int_11) / 2) - 1, this.int_7 - this.int_9), new Point(base.Width - ((base.Width - this.int_11) / 2), this.int_7 - this.int_9) };
                        g.FillPolygon(brush, pointArray);
                        brush.Color = color;
                        pointArray = new Point[] { new Point(base.Width / 2, base.Height - ((this.int_7 - this.int_10) - this.int_9)), new Point((base.Width - this.int_11) / 2, (base.Height - this.ArrowHeight) + this.int_9), new Point(base.Width - ((base.Width - this.int_11) / 2), (base.Height - this.ArrowHeight) + this.int_9) };
                        g.FillPolygon(brush, pointArray);
                        goto Label_0393;
                    }
                }
                using (brush = new SolidBrush(color2))
                {
                    pointArray = new Point[] { new Point((this.int_7 - this.int_10) - this.int_9, base.Height / 2), new Point(this.int_7 - this.int_9, ((base.Height - this.int_11) / 2) - 1), new Point(this.int_7 - this.int_9, base.Height - ((base.Height - this.int_11) / 2)) };
                    g.FillPolygon(brush, pointArray);
                    brush.Color = color;
                    pointArray = new Point[] { new Point(base.Width - ((this.int_7 - this.int_10) - this.int_9), base.Height / 2), new Point((base.Width - this.int_7) + this.int_9, ((base.Height - this.int_11) / 2) - 1), new Point((base.Width - this.ArrowHeight) + this.int_9, base.Height - ((base.Height - this.int_11) / 2)) };
                    g.FillPolygon(brush, pointArray);
                }
            }
        Label_0393:
            if (this.image_1 != null)
            {
                Image image = this.bool_30 ? this.image_3 : ((this.EXPYCDIYHA == ((Enum7) 2)) ? this.image_2 : this.image_1);
                if (image == null)
                {
                    image = this.image_1;
                }
                ControlRender.SudokuDrawImage(g, this.image_1, this.method_31(), this.padding_1, e.ClipRectangle);
            }
            else
            {
                using (brush = new SolidBrush(this.bool_30 ? this.ScrollBarPressColor : ((this.EXPYCDIYHA == ((Enum7) 2)) ? this.ScrollBarHoverColor : this.ScrollBarNormalColor)))
                {
                    if (this.bool_27)
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        using (GraphicsPath path = GraphicsPathHelper.CreatePath(this.method_31(), (this.Orientation == System.Windows.Forms.Orientation.Vertical) ? ((base.Width / 5) * 4) : ((base.Height / 5) * 4), RoundStyle.All, true))
                        {
                            g.FillPath(brush, path);
                            return;
                        }
                    }
                    g.FillRectangle(brush, this.method_31());
                }
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                    e.IsInputKey = true;
                    break;
            }
            base.OnPreviewKeyDown(e);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        [DefaultValue(12), Description("箭头范围高度")]
        public int ArrowHeight
        {
            get
            {
                return this.int_7;
            }
            set
            {
                if (this.int_7 != value)
                {
                    this.int_7 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("鼠标移入箭头的颜色"), DefaultValue(typeof(Color), "180, 180, 180")]
        public Color ArrowHoverColor
        {
            get
            {
                return this.color_6;
            }
            set
            {
                this.color_6 = value;
            }
        }

        [DefaultValue(typeof(Color), "Gray"), Description("箭头颜色")]
        public Color ArrowNormalColor
        {
            get
            {
                return this.color_5;
            }
            set
            {
                if (this.color_5 != value)
                {
                    this.color_5 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("鼠标按下箭头的颜色"), DefaultValue(typeof(Color), "80, 80, 80")]
        public Color ArrowPressColor
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

        [Description("箭头和滚动框空白距离"), DefaultValue(3)]
        public int ArrowScrollBarGap
        {
            get
            {
                return this.int_9;
            }
            set
            {
                if (this.int_9 != value)
                {
                    this.int_9 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "200,255,255,255")]
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

        [DefaultValue(false), Description("圆角")]
        public bool Fillet
        {
            get
            {
                return this.bool_27;
            }
            set
            {
                if (this.bool_27 = value)
                {
                    this.bool_27 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("按键是否可以改变滚动值"), DefaultValue(true)]
        public bool KeyChangeValue
        {
            get
            {
                return this.bool_29;
            }
            set
            {
                this.bool_29 = value;
            }
        }

        [DefaultValue(10), Description("当用户点击滚动条或者按Page Up PageDown 键时，滚动框位置变动的幅度")]
        public int LargeChange
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }

        [DefaultValue(100), Description("可滚动的上限值")]
        public int Maximum
        {
            get
            {
                return this.int_4;
            }
            set
            {
                if (this.int_4 != value)
                {
                    this.int_4 = value;
                    if (this.int_5 > this.int_4)
                    {
                        this.Value = this.int_4;
                    }
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(0), Description("可滚动的下限值")]
        public int Minimum
        {
            get
            {
                return this.int_3;
            }
            set
            {
                if (this.int_3 != value)
                {
                    this.int_3 = value;
                    if (this.Value < this.int_3)
                    {
                        this.Value = this.int_3;
                    }
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(System.Windows.Forms.Orientation), "Vertical"), Description("滚动条方向")]
        public System.Windows.Forms.Orientation Orientation
        {
            get
            {
                return this.orientation_0;
            }
            set
            {
                if (this.orientation_0 != value)
                {
                    this.orientation_0 = value;
                    this.Size = new Size(base.Height, base.Width);
                }
            }
        }

        [DefaultValue(typeof(Color), "158, 158, 158"), Description("鼠标移入时候滚动框的颜色")]
        public Color ScrollBarHoverColor
        {
            get
            {
                return this.color_3;
            }
            set
            {
                this.color_3 = value;
            }
        }

        [Description("滚动框图片"), DefaultValue((string) null)]
        public Image ScrollBarHoverImage
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

        [DefaultValue(20), Description("中间滚动框长度")]
        public int ScrollBarLenght
        {
            get
            {
                return this.int_6;
            }
            set
            {
                if (this.int_6 != value)
                {
                    this.int_6 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "Gray"), Description("滚动框颜色")]
        public Color ScrollBarNormalColor
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
                    this.Invalidate(this.method_31());
                }
            }
        }

        [DefaultValue((string) null), Description("滚动框图片")]
        public Image ScrollBarNormalImage
        {
            get
            {
                return this.image_1;
            }
            set
            {
                if (this.image_1 != value)
                {
                    this.image_1 = value;
                    this.Invalidate(this.method_31());
                }
            }
        }

        [Description("滚动条内边距"), DefaultValue(1)]
        public int ScrollBarPadding
        {
            get
            {
                return this.int_8;
            }
            set
            {
                if (this.int_8 != value)
                {
                    this.int_8 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("滚动框九宫格图片切割宽度"), DefaultValue(typeof(Padding), "5")]
        public Padding ScrollBarPartitionWidth
        {
            get
            {
                return this.padding_1;
            }
            set
            {
                if (this.padding_1 != value)
                {
                    this.padding_1 = value;
                    this.Invalidate(this.method_31());
                }
            }
        }

        [Description("鼠标按下时候滚动框的颜色"), DefaultValue(typeof(Color), "80, 80, 80")]
        public Color ScrollBarPressColor
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

        [Description("滚动框图片"), DefaultValue((string) null)]
        public Image ScrollBarPressImage
        {
            get
            {
                return this.image_3;
            }
            set
            {
                this.image_3 = value;
            }
        }

        [DefaultValue(true), Description("显示箭头")]
        public bool ShowArrow
        {
            get
            {
                return this.bool_28;
            }
            set
            {
                if (this.bool_28 != value)
                {
                    this.bool_28 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(1), Description("当用户点击滚动箭头或按箭头键时，滚动框位置变动的幅度")]
        public int SmallChange
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }

        [Description("滚动框位置标示的值"), DefaultValue(0)]
        public int Value
        {
            get
            {
                return this.int_5;
            }
            set
            {
                if (this.int_5 != value)
                {
                    this.int_5 = value;
                    if (value > this.Maximum)
                    {
                        this.int_5 = this.Maximum;
                    }
                    if (value < this.Minimum)
                    {
                        this.int_5 = this.Minimum;
                    }
                    this.OnValueChanged(EventArgs.Empty);
                    this.Invalidate();
                    base.OnPropertyChanged("Value");
                }
            }
        }

        private enum Enum7
        {
        }
    }
}

