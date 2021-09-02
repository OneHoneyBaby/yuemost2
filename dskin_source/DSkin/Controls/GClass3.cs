namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class GClass3
    {
        private Color color_0 = Color.Black;
        private Color color_1 = Color.Black;
        private Color color_2 = Color.Black;
        private Color color_3 = Color.Transparent;
        private Color color_4 = Color.White;
        private Color color_5 = Color.FromArgb(250, 200, 0, 0);
        private DSkinTabControl dskinTabControl_0;
        private Image image_0;
        private Image image_1;
        private Image image_2;
        private int int_0 = 8;
        private Point point_0 = new Point();
        private System.Drawing.Size size_0 = new System.Drawing.Size(15, 15);

        public GClass3(DSkinTabControl owner)
        {
            this.dskinTabControl_0 = owner;
        }

        public void DrawButton(Graphics g, Rectangle rect, ControlStates state)
        {
            Color color = this.color_0;
            Color color2 = this.color_3;
            Image image = this.image_0;
            switch (state)
            {
                case ControlStates.Normal:
                case ControlStates.Focused:
                    color = this.color_0;
                    color2 = this.color_3;
                    image = this.image_0;
                    break;

                case ControlStates.Hover:
                    color = this.color_1;
                    color2 = this.color_4;
                    image = this.image_1;
                    break;

                case ControlStates.Pressed:
                    color = this.color_2;
                    color2 = this.color_5;
                    image = this.image_2;
                    break;
            }
            if (image != null)
            {
                g.DrawImage(image, rect);
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(color2))
                {
                    g.FillRectangle(brush, rect);
                }
                using (Pen pen = new Pen(color, 2f))
                {
                    g.DrawLine(pen, new Point(rect.X + ((this.size_0.Width - this.int_0) / 2), rect.Y + ((this.size_0.Height - this.int_0) / 2)), new Point((rect.X + this.size_0.Width) - ((this.size_0.Width - this.int_0) / 2), (rect.Y + this.size_0.Height) - ((this.size_0.Height - this.int_0) / 2)));
                    g.DrawLine(pen, new Point(rect.X + ((this.size_0.Width - this.int_0) / 2), (rect.Y + this.size_0.Height) - ((this.size_0.Height - this.int_0) / 2)), new Point((rect.X + this.size_0.Width) - ((this.size_0.Width - this.int_0) / 2), rect.Y + ((this.size_0.Height - this.int_0) / 2)));
                }
            }
        }

        [DefaultValue(typeof(Color), "White"), Description("按钮鼠标移入背景色")]
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

        [Description("按钮颜色"), DefaultValue(typeof(Color), "Black")]
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

        [DefaultValue((string) null), Description("按钮鼠标移入图片")]
        public Image HoverImage
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

        [DefaultValue(typeof(Point), "0,0"), Description("按钮位置偏移")]
        public Point LocationOffset
        {
            get
            {
                return this.point_0;
            }
            set
            {
                if (this.point_0 != value)
                {
                    this.point_0 = value;
                    this.dskinTabControl_0.Invalidate();
                }
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
                    this.dskinTabControl_0.Invalidate();
                }
            }
        }

        [Description("按钮颜色"), DefaultValue(typeof(Color), "Black")]
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
                    this.dskinTabControl_0.Invalidate();
                }
            }
        }

        [Description("按钮图片"), DefaultValue((string) null)]
        public Image NormalImage
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
                    this.dskinTabControl_0.Invalidate();
                }
            }
        }

        [Description("按钮鼠标按下背景色"), DefaultValue(typeof(Color), "250, 200, 0, 0")]
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

        [DefaultValue(typeof(Color), "Black"), Description("按钮颜色")]
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
        public Image PressImage
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

        [DefaultValue(typeof(System.Drawing.Size), "15,15"), Description("按钮大小")]
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
                    this.dskinTabControl_0.Invalidate();
                }
            }
        }
    }
}

