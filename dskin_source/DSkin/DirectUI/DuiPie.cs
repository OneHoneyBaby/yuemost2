namespace DSkin.DirectUI
{
    using DSkin.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class DuiPie : DuiBaseControl
    {
        private Color color_2 = Color.Black;
        private Color color_3 = Color.White;
        private DSkinBrush dskinBrush_0;
        private DuiPieItem[] duiPieItem_0;
        private int int_1 = 0;
        private int int_2 = 1;
        private int int_3 = -90;
        private int int_4 = 0;
        private DSkinPen vxjVqUeowc;

        protected override void OnPrePaint(PaintEventArgs e)
        {
            SolidBrush brush;
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(this.int_1 + this.int_4, this.int_1 + this.int_4, ((base.Width - (this.int_1 * 2)) - (this.int_4 * 2)) - 1, ((base.Height - (this.int_1 * 2)) - (this.int_4 * 2)) - 1);
            if (this.dskinBrush_0 != null)
            {
                graphics.FillEllipse(this.dskinBrush_0.Brush, rect);
            }
            else
            {
                using (brush = new SolidBrush(this.color_3))
                {
                    graphics.FillEllipse(brush, rect);
                }
            }
            int num = this.int_3;
            if (this.duiPieItem_0 != null)
            {
                foreach (DuiPieItem item in this.duiPieItem_0)
                {
                    if (item.Brush != null)
                    {
                        graphics.FillPie(item.Brush, rect, (float) num, (float) item.Angle);
                    }
                    else if ((rect.Width > 0) && (rect.Height > 0))
                    {
                        using (brush = new SolidBrush(item.Color))
                        {
                            graphics.FillPie(brush, rect, (float) num, (float) item.Angle);
                        }
                    }
                    num += item.Angle;
                }
            }
            if ((this.int_2 > 0) && (this.color_2 != Color.Transparent))
            {
                if (this.vxjVqUeowc != null)
                {
                    graphics.DrawEllipse(this.vxjVqUeowc.Pen, this.int_1, this.int_1, (base.Width - (this.int_1 * 2)) - 1, (base.Height - (this.int_1 * 2)) - 1);
                }
                else
                {
                    using (Pen pen = new Pen(this.color_2, (float) this.int_2))
                    {
                        graphics.DrawEllipse(pen, this.int_1, this.int_1, (base.Width - (this.int_1 * 2)) - 1, (base.Height - (this.int_1 * 2)) - 1);
                    }
                }
            }
            base.OnPrePaint(e);
        }

        [Description("圆边框和圆的空白距离")]
        public int BorderAndEllipseGap
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

        [Description("圆边框颜色")]
        public Color EllipseBorderColor
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

        [Description("自定义圆边框画笔")]
        public DSkinPen EllipseBorderPen
        {
            get
            {
                return this.vxjVqUeowc;
            }
            set
            {
                if (this.vxjVqUeowc != value)
                {
                    this.vxjVqUeowc = value;
                    this.Invalidate();
                }
            }
        }

        [Description("圆边框宽度")]
        public int EllipseBorderWidth
        {
            get
            {
                return this.int_2;
            }
            set
            {
                if (this.int_2 != value)
                {
                    this.int_2 = value;
                    if (value < 0)
                    {
                        this.int_2 = 0;
                    }
                    this.Invalidate();
                }
            }
        }

        [Description("自定义圆填充刷")]
        public DSkinBrush EllipseBrush
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

        [Description("圆颜色")]
        public Color EllipseColor
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

        [Description("圆边框与控件边框的距离")]
        public int InnerPadding
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
                    this.Invalidate();
                }
            }
        }

        [Description("圆饼集合")]
        public DuiPieItem[] Items
        {
            get
            {
                return this.duiPieItem_0;
            }
            set
            {
                if (this.duiPieItem_0 != value)
                {
                    this.duiPieItem_0 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("内部扇形开始角度")]
        public int StartAngle
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
                    this.Invalidate();
                }
            }
        }
    }
}

