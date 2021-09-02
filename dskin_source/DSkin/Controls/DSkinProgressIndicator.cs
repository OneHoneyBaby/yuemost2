namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Globalization;
    using System.Windows.Forms;

    public class DSkinProgressIndicator : DSkinBaseControl
    {
        private bool bool_0;
        private bool bool_1 = true;
        private bool bool_2;
        private bool bool_3;
        private Color color_0 = Color.FromArgb(20, 20, 20);
        private float float_0 = 1f;
        private float float_1;
        private int int_0 = 1;
        private int int_1 = 100;
        private int int_2 = 8;
        private int int_3 = 8;
        private RotationType rotationType_0 = RotationType.Clockwise;
        private TextDisplayModes textDisplayModes_0 = TextDisplayModes.None;
        private TextRenderingHint textRenderingHint_0 = TextRenderingHint.SystemDefault;
        private Timer timer_0 = new Timer();

        public DSkinProgressIndicator()
        {
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
            if (this.AutoStart)
            {
                this.timer_0.Start();
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.timer_0.Dispose();
            base.Dispose(disposing);
        }

        private string method_6()
        {
            string str = string.Format(CultureInfo.CurrentCulture, "{0:0.##} %", new object[] { this.float_1 });
            if (this.bool_3 && this.bool_2)
            {
                return string.Format("{0}{1}{2}", str, Environment.NewLine, this.Text);
            }
            if (this.bool_3)
            {
                return this.Text;
            }
            if (this.bool_2)
            {
                return str;
            }
            return string.Empty;
        }

        private void method_7()
        {
            int width = Math.Max(base.Width, base.Height);
            base.Size = new Size(width, width);
        }

        private void method_8()
        {
            if ((this.int_0 + 1) <= this.int_2)
            {
                this.int_0++;
            }
            else
            {
                this.int_0 = 1;
            }
        }

        protected override void OnLayeredPaint(PaintEventArgs e)
        {
            float num = 360f / ((float) this.int_2);
            GraphicsState gstate = e.Graphics.Save();
            e.Graphics.TranslateTransform(((float) base.Width) / 2f, ((float) base.Height) / 2f);
            e.Graphics.RotateTransform((num * this.int_0) * ((float) this.rotationType_0));
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 1; i <= this.int_2; i++)
            {
                int num11 = ((255f * (((float) i) / ((float) this.int_3))) > 255.0) ? 0 : ((int) (255f * (((float) i) / ((float) this.int_3))));
                int alpha = this.bool_1 ? 0x1f : num11;
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, this.color_0)))
                {
                    float num6 = 4.5f / this.float_0;
                    float width = ((float) base.Width) / num6;
                    float num8 = (((float) base.Width) / 4.5f) - width;
                    float x = (((float) base.Width) / 9f) + num8;
                    float y = (((float) base.Height) / 9f) + num8;
                    e.Graphics.FillEllipse(brush, x, y, width, width);
                    e.Graphics.RotateTransform(num * ((float) this.rotationType_0));
                }
            }
            e.Graphics.Restore(gstate);
            string str = this.method_6();
            if (!string.IsNullOrEmpty(str))
            {
                e.Graphics.TextRenderingHint = this.textRenderingHint_0;
                SizeF ef = e.Graphics.MeasureString(str, this.Font);
                float num3 = (((float) base.Width) / 2f) - (ef.Width / 2f);
                float num4 = (((float) base.Height) / 2f) - (ef.Height / 2f);
                StringFormat format2 = new StringFormat {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                RectangleF layoutRectangle = new RectangleF(num3, num4, ef.Width, ef.Height);
                using (SolidBrush brush2 = new SolidBrush(Color.FromArgb((this.ForeColor.A == 0xff) ? 0xfe : this.ForeColor.A, this.ForeColor)))
                {
                    e.Graphics.DrawString(str, this.Font, brush2, layoutRectangle, format2);
                }
            }
            base.OnLayeredPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            this.method_7();
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.method_7();
            base.OnSizeChanged(e);
        }

        public void Start()
        {
            this.timer_0.Interval = this.int_1;
            this.bool_1 = false;
            this.timer_0.Start();
        }

        public void Stop()
        {
            this.timer_0.Stop();
            this.int_0 = 1;
            this.bool_1 = true;
            base.Invalidate();
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            if (!base.DesignMode)
            {
                this.method_8();
                base.Invalidate();
            }
        }

        [Category("Skin"), DefaultValue(0x4b), Description("获取或设置动画速度。")]
        public int AnimationSpeed
        {
            get
            {
                return ((-this.int_1 + 400) / 4);
            }
            set
            {
                int num = 400 - (value * 4);
                if (num < 10)
                {
                    this.int_1 = 10;
                }
                else
                {
                    this.int_1 = (num > 400) ? 400 : num;
                }
                this.timer_0.Interval = this.int_1;
            }
        }

        [DefaultValue(false), Description("获取或设置一个值，指示是否应自动启动动画。"), Category("Skin")]
        public bool AutoStart
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
                if (!(!this.bool_0 || base.DesignMode))
                {
                    this.Start();
                }
                else
                {
                    this.Stop();
                }
            }
        }

        [DefaultValue(typeof(Color), "20, 20, 20"), Category("Skin"), Description("获取或设置圆形进度条的颜色")]
        public Color CircleColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                base.Invalidate();
            }
        }

        [DefaultValue((float) 1f), Description("获取或设置小圆形的大小，从0.1到1。"), Category("Skin")]
        public float CircleSize
        {
            get
            {
                return this.float_0;
            }
            set
            {
                if (value <= 0f)
                {
                    this.float_0 = 0.1f;
                }
                else
                {
                    this.float_0 = (value > 1f) ? 1f : value;
                }
                base.Invalidate();
            }
        }

        [Category("Skin"), DefaultValue(8), Description("获取或设置用于在动画圈里的速率圈数。")]
        public int NumberOfCircles
        {
            get
            {
                return this.int_2;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "圈数必须是一个正整数。");
                }
                this.int_2 = value;
                base.Invalidate();
            }
        }

        [Description("获取或设置用于在动画圈的残影数量。"), DefaultValue(8), Category("Skin")]
        public int NumberOfVisibleCircles
        {
            get
            {
                return this.int_3;
            }
            set
            {
                if ((value <= 0) || (value > this.int_2))
                {
                    throw new ArgumentOutOfRangeException("value", "圈数必须是一个正整数，且小于或等于圆的数目。");
                }
                this.int_3 = value;
                base.Invalidate();
            }
        }

        [Category("Skin"), DefaultValue(0), Description("获取或设置百分比值。")]
        public float Percentage
        {
            get
            {
                return this.float_1;
            }
            set
            {
                if ((value < 0f) || (value > 100f))
                {
                    throw new ArgumentOutOfRangeException("value", "Percentage must be a positive integer between 0 and 100.");
                }
                this.float_1 = value;
            }
        }

        [DefaultValue(1), Category("Skin"), Description("获取或设置一个值，指示是否应顺时针或逆时针旋转。")]
        public RotationType Rotation
        {
            get
            {
                return this.rotationType_0;
            }
            set
            {
                this.rotationType_0 = value;
            }
        }

        [Description("获取或设置一个值，指示是否应显示百分比值。"), DefaultValue(false), Category("Skin")]
        public bool ShowPercentage
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
                this.textDisplayModes_0 = this.bool_2 ? (this.textDisplayModes_0 | TextDisplayModes.Percentage) : (this.textDisplayModes_0 & ~TextDisplayModes.Percentage);
                base.Invalidate();
            }
        }

        [Description("获取或设置一个值，指示是否控制要显示的文字。"), Category("Skin"), DefaultValue(false)]
        public bool ShowText
        {
            get
            {
                return this.bool_3;
            }
            set
            {
                this.bool_3 = value;
                this.textDisplayModes_0 = this.bool_3 ? (this.textDisplayModes_0 | TextDisplayModes.Text) : (this.textDisplayModes_0 & ~TextDisplayModes.Text);
                base.Invalidate();
            }
        }

        [Category("Skin"), Description("获取或设置将在控件显示的文本显示模式。"), DefaultValue(0)]
        public TextDisplayModes TextDisplay
        {
            get
            {
                return this.textDisplayModes_0;
            }
            set
            {
                this.textDisplayModes_0 = value;
                this.bool_3 = (this.textDisplayModes_0 & TextDisplayModes.Text) == TextDisplayModes.Text;
                this.bool_2 = (this.textDisplayModes_0 & TextDisplayModes.Percentage) == TextDisplayModes.Percentage;
                base.Invalidate();
            }
        }

        [Category("外观"), Description("文本渲染模式"), DefaultValue(0)]
        public TextRenderingHint TextRenderMode
        {
            get
            {
                return this.textRenderingHint_0;
            }
            set
            {
                if (this.textRenderingHint_0 != value)
                {
                    this.textRenderingHint_0 = value;
                    base.Invalidate();
                }
            }
        }
    }
}

