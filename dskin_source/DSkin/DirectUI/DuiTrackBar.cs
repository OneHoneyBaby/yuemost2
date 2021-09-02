namespace DSkin.DirectUI
{
    using DSkin.Common;
    using DSkin.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiTrackBar : DuiBaseControl
    {
        private bool bool_27 = false;
        private bool bool_28 = false;
        private Color color_2 = Color.White;
        private Color color_3 = Color.Gray;
        private Color color_4 = Color.Black;
        private Color color_5 = Color.Black;
        private Color color_6 = Color.FromArgb(200, 200, 200);
        private Color color_7 = Color.White;
        private Color color_8 = Color.FromArgb(100, 100, 100);
        private DSkinBrush dskinBrush_0;
        private DSkinBrush dskinBrush_1;
        private ForeImageDrawModes foreImageDrawModes_0 = ForeImageDrawModes.Normal;
        private Image image_1;
        private Image image_2;
        private Image image_3;
        private Image image_4;
        private int int_1 = 10;
        private int int_2 = 0;
        private int int_3 = 0;
        private int int_4 = 5;
        private int int_5 = 1;
        private int int_6 = 8;
        private int int_7 = 1;
        private System.Windows.Forms.Orientation orientation_0 = System.Windows.Forms.Orientation.Horizontal;
        private Padding padding_1 = new Padding(5);
        private Pen pen_0;
        private Size size_0 = new Size(9, 9);

        [Description("value改变之后发生")]
        public event EventHandler ValueChanged;

        public DuiTrackBar()
        {
            this.Size = new Size(100, 20);
        }

        private bool method_29()
        {
            return this.bool_28;
        }

        private void method_30(bool value)
        {
            if (this.bool_28 != value)
            {
                this.bool_28 = value;
                this.Invalidate();
            }
        }

        private Rectangle method_31()
        {
            if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
            {
                return new Rectangle(this.int_6, (base.Height - this.int_4) / 2, base.Width - (2 * this.int_6), this.int_4);
            }
            return new Rectangle(((base.Width - this.int_4) + ((int) 0.5)) / 2, this.int_6, this.int_4, base.Height - (2 * this.int_6));
        }

        private Rectangle method_32()
        {
            double num = (1.0 * (this.int_3 - this.int_2)) / ((double) (this.int_1 - this.int_2));
            if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
            {
                return new Rectangle((((int) ((base.Width - (2 * this.int_6)) * num)) - (this.size_0.Width / 2)) + this.int_6, (base.Height - this.size_0.Height) / 2, this.size_0.Width, this.size_0.Height);
            }
            return new Rectangle((base.Width - this.size_0.Width) / 2, ((base.Height - this.int_6) - ((int) ((base.Height - (2 * this.int_6)) * num))) - (this.size_0.Height / 2), this.size_0.Width, this.size_0.Height);
        }

        private void method_33(Point point_1)
        {
            double num;
            if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
            {
                num = (1.0 * (point_1.X - this.int_6)) / ((double) (base.Width - (this.int_6 * 2)));
                this.Value = (int) Math.Round((double) ((num * (this.int_1 - this.int_2)) + this.int_2));
            }
            else
            {
                num = (1.0 * ((base.Height - this.int_6) - point_1.Y)) / ((double) (base.Height - (this.int_6 * 2)));
                this.Value = (int) Math.Round((double) ((num * (this.int_1 - this.int_2)) + this.int_2));
            }
        }

        protected override void OnMouseDown(DuiMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.method_33(e.Location);
                this.Invalidate(this.method_32());
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.method_30(false);
        }

        protected override void OnMouseMove(DuiMouseEventArgs e)
        {
            if (this.method_32().Contains(e.Location))
            {
                this.method_30(true);
            }
            else
            {
                this.method_30(false);
            }
            if (base.IsMouseDown && (e.Button == MouseButtons.Left))
            {
                this.method_33(e.Location);
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(DuiMouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.Invalidate();
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            double num;
            Rectangle rectangle2;
            Brush brush2;
            Rectangle rectangle3;
            Graphics g = e.Graphics;
            Rectangle rect = this.method_31();
            if (this.dskinBrush_1 == null)
            {
                using (brush2 = new SolidBrush(this.color_2))
                {
                    g.FillRectangle(brush2, rect);
                    goto Label_0055;
                }
            }
            g.FillRectangle(this.dskinBrush_1.Brush, rect);
        Label_0055:
            num = (1.0 * (this.int_3 - this.int_2)) / ((double) (this.int_1 - this.int_2));
            if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
            {
                rectangle2 = new Rectangle(rect.X, rect.Y, (int) (rect.Width * num), rect.Height);
            }
            else
            {
                rectangle2 = new Rectangle(rect.X, rect.Y + (rect.Height - ((int) (rect.Height * num))), rect.Width, (int) (rect.Height * num));
            }
            if (this.image_4 != null)
            {
                switch (this.foreImageDrawModes_0)
                {
                    case ForeImageDrawModes.Stretch:
                        g.DrawImage(this.image_4, rectangle2);
                        break;

                    case ForeImageDrawModes.Sudoku:
                        ControlRender.SudokuDrawImage(g, this.image_4, rectangle2, this.padding_1, e.ClipRectangle);
                        break;

                    case ForeImageDrawModes.Normal:
                        g.DrawImage(this.image_4, rectangle2, new Rectangle(new Point(), rectangle2.Size), GraphicsUnit.Pixel);
                        break;

                    case ForeImageDrawModes.Tile:
                    {
                        using (TextureBrush brush = new TextureBrush(this.image_4, WrapMode.Tile))
                        {
                            g.FillRectangle(brush, rectangle2);
                            break;
                        }
                    }
                    case ForeImageDrawModes.Translate:
                        if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                        {
                            g.DrawImage(this.image_4, rectangle2, new Rectangle(this.image_4.Width - rectangle2.Width, 0, rectangle2.Width, rectangle2.Height), GraphicsUnit.Pixel);
                        }
                        else
                        {
                            g.DrawImage(this.image_4, rectangle2, new Rectangle(0, 0, rectangle2.Width, rectangle2.Height), GraphicsUnit.Pixel);
                        }
                        break;
                }
            }
            else
            {
                if (this.dskinBrush_0 == null)
                {
                    using (brush2 = new SolidBrush(this.color_3))
                    {
                        g.FillRectangle(brush2, rectangle2);
                        goto Label_0266;
                    }
                }
                g.FillRectangle(this.dskinBrush_0.Brush, rectangle2);
            }
        Label_0266:
            if (this.pen_0 == null)
            {
                if (this.int_5 <= 0)
                {
                    goto Label_02B9;
                }
                using (Pen pen = new Pen(this.color_4, (float) this.int_5))
                {
                    g.DrawRectangle(pen, rect);
                    goto Label_02B9;
                }
            }
            g.DrawRectangle(this.pen_0, rect);
        Label_02B9:
            rectangle3 = this.method_32();
            if (this.image_1 == null)
            {
                using (brush2 = new SolidBrush(base.IsMouseDown ? this.color_8 : (this.bool_28 ? this.color_7 : this.color_6)))
                {
                    if (this.bool_27)
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.FillEllipse(brush2, rectangle3);
                    }
                    else
                    {
                        g.FillRectangle(brush2, rectangle3);
                    }
                    goto Label_0372;
                }
            }
            Image image = base.IsMouseDown ? this.image_3 : (this.bool_28 ? this.image_2 : this.image_1);
            image = (image == null) ? this.image_1 : image;
            g.DrawImage(image, rectangle3);
        Label_0372:
            if (((this.int_7 > 0) && (this.color_5 != Color.Transparent)) && (this.color_5 != Color.Empty))
            {
                using (Pen pen2 = new Pen(this.color_5, (float) this.int_7))
                {
                    if (this.bool_27)
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.DrawEllipse(pen2, rectangle3);
                    }
                    else
                    {
                        g.DrawRectangle(pen2, rectangle3);
                    }
                }
            }
            base.OnPrePaint(e);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        [Category("外观"), DefaultValue((string) null), Description("上层图片")]
        public Image ForeImage
        {
            get
            {
                return this.image_4;
            }
            set
            {
                if (this.image_4 != value)
                {
                    this.image_4 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("外观"), DefaultValue(typeof(ForeImageDrawModes), "Normal"), Description("前景图片绘制模式")]
        public ForeImageDrawModes ForeImageDrawMode
        {
            get
            {
                return this.foreImageDrawModes_0;
            }
            set
            {
                if (this.foreImageDrawModes_0 != value)
                {
                    this.foreImageDrawModes_0 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("前景图片九宫格分割宽度"), Category("外观"), DefaultValue(typeof(Padding), "5,5,5,5")]
        public Padding ForeImagePartitionWidth
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
                    this.Invalidate();
                }
            }
        }

        [Description("主线两端到边框的距离")]
        public int InnerPadding
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

        [Description("指示按钮是否为椭圆")]
        public bool IsEllipsePointButton
        {
            get
            {
                return this.bool_27;
            }
            set
            {
                if (this.bool_27 != value)
                {
                    this.bool_27 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("主线边框颜色")]
        public Color MainLineBorderColor
        {
            get
            {
                return this.color_4;
            }
            set
            {
                if (this.color_4 != value)
                {
                    this.color_4 = value;
                    this.Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Pen MainLineBorderPen
        {
            get
            {
                return this.pen_0;
            }
            set
            {
                if (this.pen_0 != value)
                {
                    this.pen_0 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("主线边框宽度")]
        public int MainLineBorderWidth
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
                    this.Invalidate();
                }
            }
        }

        [DefaultValue((string) null), Description("自定义主线填充刷")]
        public DSkinBrush MainLineBrushDown
        {
            get
            {
                return this.dskinBrush_1;
            }
            set
            {
                if (this.dskinBrush_1 != value)
                {
                    this.dskinBrush_1 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue((string) null), Description("自定义主线填充刷")]
        public DSkinBrush MainLineBrushUp
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
                    this.Invalidate();
                }
            }
        }

        [Description("主线填充颜色")]
        public Color MainLineColorDown
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

        [Description("主线填充颜色")]
        public Color MainLineColorUp
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

        [Description("主线宽度")]
        public int MainLineWidth
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
                    this.Invalidate();
                }
            }
        }

        [Category("DuiTrackBar"), Description("最大值")]
        public int Maximum
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

        [Description("最小值"), Category("DuiTrackBar")]
        public int Minimum
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

        [Description("控件方向")]
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

        [Description("指示按钮边框颜色")]
        public Color PointButtonBorderColor
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

        [Description("指示按钮边框宽度")]
        public int PointButtonBorderWidth
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

        [Description("指示按钮填充颜色")]
        public Color PointButtonHoverColor
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

        [Description("指示按钮图片")]
        public Image PointButtonHoverImage
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

        [Description("指示按钮填充颜色")]
        public Color PointButtonNormalColor
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
                    this.Invalidate();
                }
            }
        }

        [Description("指示按钮图片")]
        public Image PointButtonNormalImage
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
                    this.Invalidate();
                }
            }
        }

        [Description("指示按钮填充颜色")]
        public Color PointButtonPressColor
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

        [Description("指示按钮图片")]
        public Image PointButtonPressImage
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

        [Description("指示按钮大小")]
        public Size PointButtonSize
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
                    this.Invalidate();
                }
            }
        }

        [Description("当前指示数值"), Category("DuiTrackBar")]
        public int Value
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
                    if (value > this.int_1)
                    {
                        this.int_3 = this.int_1;
                    }
                    if (value < this.int_2)
                    {
                        this.int_3 = this.int_2;
                    }
                    this.OnValueChanged(EventArgs.Empty);
                    this.Invalidate();
                    base.OnPropertyChanged("Value");
                }
            }
        }
    }
}

