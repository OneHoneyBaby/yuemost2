namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class DSkinPen : Component
    {
        private System.Drawing.Color color_0;
        private DSkinBrush dskinBrush_0;
        private float[] float_0;
        private System.Drawing.Pen pen_0;

        public DSkinPen()
        {
            this.color_0 = System.Drawing.Color.Black;
            this.float_0 = new float[0];
        }

        public DSkinPen(IContainer container) : this()
        {
            container.Add(this);
        }

        public DSkinPen(System.Drawing.Pen pen)
        {
            this.color_0 = System.Drawing.Color.Black;
            this.float_0 = new float[0];
            this.pen_0 = pen;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.pen_0 != null)
            {
                this.pen_0.Dispose();
                this.pen_0 = null;
            }
            base.Dispose(disposing);
        }

        [Description("获取或设置此 System.Drawing.Pen 的对齐方式。"), DefaultValue(0)]
        public PenAlignment Alignment
        {
            get
            {
                return this.Pen.Alignment;
            }
            set
            {
                this.Pen.Alignment = value;
            }
        }

        [Description("画笔的画刷"), DefaultValue((string) null)]
        public DSkinBrush Brush
        {
            get
            {
                return this.dskinBrush_0;
            }
            set
            {
                if (this.dskinBrush_0 != value)
                {
                    this.dskinBrush_0 = value;
                    if (this.dskinBrush_0 == null)
                    {
                        this.Pen.Color = System.Drawing.Color.Black;
                        this.Pen.Color = System.Drawing.Color.White;
                        this.Pen.Color = this.color_0;
                    }
                    else
                    {
                        this.Pen.Brush = this.dskinBrush_0.Brush;
                    }
                }
            }
        }

        [DefaultValue(typeof(System.Drawing.Color), "Black"), Description("获取或设置此 System.Drawing.Pen 的颜色。")]
        public System.Drawing.Color Color
        {
            get
            {
                return this.Pen.Color;
            }
            set
            {
                this.color_0 = value;
                if (this.dskinBrush_0 == null)
                {
                    this.Pen.Color = value;
                }
            }
        }

        [Description("获取或设置用于指定复合钢笔的值数组。复合钢笔绘制由平行直线和空白区域组成的复合直线。")]
        public float[] CompoundArray
        {
            get
            {
                return this.Pen.CompoundArray;
            }
            set
            {
                if ((value != null) && (value.Length > 0))
                {
                    this.Pen.CompoundArray = value;
                }
            }
        }

        [Description("获取或设置用在短划线终点的线帽样式，这些短划线构成通过此 System.Drawing.Pen 绘制的虚线。"), DefaultValue(0)]
        public System.Drawing.Drawing2D.DashCap DashCap
        {
            get
            {
                return this.Pen.DashCap;
            }
            set
            {
                this.Pen.DashCap = value;
            }
        }

        [DefaultValue((float) 0f), Description("获取或设置直线的起点到短划线图案起始处的距离。")]
        public float DashOffset
        {
            get
            {
                return this.Pen.DashOffset;
            }
            set
            {
                this.Pen.DashOffset = value;
            }
        }

        [Description("获取或设置自定义的短划线和空白区域的数组。")]
        public float[] DashPattern
        {
            get
            {
                return this.float_0;
            }
            set
            {
                if (((this.float_0 != value) && (value != null)) && (value.Length > 0))
                {
                    this.float_0 = value;
                    this.Pen.DashPattern = value;
                }
            }
        }

        [DefaultValue(0), Description("获取或设置用于通过此 System.Drawing.Pen 绘制的虚线的样式。")]
        public System.Drawing.Drawing2D.DashStyle DashStyle
        {
            get
            {
                return this.Pen.DashStyle;
            }
            set
            {
                this.Pen.DashStyle = value;
            }
        }

        [DefaultValue(0), Description("获取或设置要在通过此 System.Drawing.Pen 绘制的直线终点使用的线帽样式。")]
        public LineCap EndCap
        {
            get
            {
                return this.Pen.EndCap;
            }
            set
            {
                this.Pen.EndCap = value;
            }
        }

        [DefaultValue(0), Description("获取或设置通过此 System.Drawing.Pen 绘制的两条连续直线的端点的联接样式。")]
        public System.Drawing.Drawing2D.LineJoin LineJoin
        {
            get
            {
                return this.Pen.LineJoin;
            }
            set
            {
                this.Pen.LineJoin = value;
            }
        }

        [DefaultValue((float) 10f), Description("获取或设置斜接角上联接宽度的限制。")]
        public float MiterLimit
        {
            get
            {
                return this.Pen.MiterLimit;
            }
            set
            {
                this.Pen.MiterLimit = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Drawing.Pen Pen
        {
            get
            {
                if (this.pen_0 == null)
                {
                    this.pen_0 = new System.Drawing.Pen(System.Drawing.Color.Black);
                }
                return this.pen_0;
            }
            set
            {
                this.pen_0 = value;
            }
        }

        [DefaultValue(0), Description("获取或设置在通过此 System.Drawing.Pen 绘制的直线起点使用的线帽样式。")]
        public LineCap StartCap
        {
            get
            {
                return this.Pen.StartCap;
            }
            set
            {
                this.Pen.StartCap = value;
            }
        }

        [DefaultValue((float) 1f), Description("获取或设置此 System.Drawing.Pen 的宽度，以用于绘图的 System.Drawing.Graphics 对象为单位。")]
        public float Width
        {
            get
            {
                return this.Pen.Width;
            }
            set
            {
                this.Pen.Width = value;
            }
        }
    }
}

