namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.Imaging;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ColorDialog))]
    public class DSkinColorSelectPanel : DSkinBaseControl
    {
        private Bitmap bitmap_0;
        private bool bool_0 = true;
        private Color color_0 = Color.White;
        private ColorSelectMode colorSelectMode_0;
        private HSL hsl_0 = new HSL(0, 1.0, 1.0);
        private readonly object object_0 = new object();

        public event EventHandler SelectedColorChanged
        {
            add
            {
                base.Events.AddHandler(this.object_0, value);
            }
            remove
            {
                base.Events.RemoveHandler(this.object_0, value);
            }
        }

        private void method_6(Graphics graphics_0, RectangleF rectangleF_0)
        {
            float num = rectangleF_0.Width / 360f;
            rectangleF_0.Width = num;
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(1, 0), Color.White, Color.White))
            {
                HSL hsl = new HSL(this.hsl_0.Hue, this.hsl_0.Saturation, 0.5);
                ColorBlend blend = new ColorBlend();
                blend.Colors = new Color[] { Color.White, Color.White, Color.Black };
                float[] numArray = new float[3];
                numArray[1] = 0.5f;
                numArray[2] = 1f;
                blend.Positions = numArray;
                brush.Transform = new Matrix(0f, rectangleF_0.Height, 1f, 0f, 0f, 0f);
                for (int i = 0; i < 360; i++)
                {
                    hsl.Hue = i;
                    rectangleF_0.X += num;
                    blend.Colors[1] = ColorConverterEx.smethod_1(hsl);
                    brush.InterpolationColors = blend;
                    graphics_0.FillRectangle(brush, rectangleF_0);
                }
            }
        }

        private void method_7(Graphics graphics_0)
        {
            RectangleF colorSelectorRect = this.ColorSelectorRect;
            using (new SmoothingModeGraphics(graphics_0))
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(160, 0xff, 0xff, 0xff)))
                {
                    graphics_0.FillEllipse(brush, colorSelectorRect);
                }
                using (Pen pen = new Pen(Color.FromArgb(60, 230, 230, 230), 2f))
                {
                    graphics_0.DrawEllipse(pen, colorSelectorRect);
                    colorSelectorRect.Inflate(-2f, -2f);
                    pen.Color = Color.Black;
                    graphics_0.DrawEllipse(pen, colorSelectorRect);
                }
            }
        }

        private void method_8(Point point_0)
        {
            int hue = (int) ((((double) point_0.X) / ((double) base.Width)) * 360.0);
            double saturation = this.hsl_0.Saturation;
            double luminance = 1.0 - (((double) point_0.Y) / ((double) base.Height));
            this.SelectedHsl = new HSL(hue, saturation, luminance);
        }

        private void method_9()
        {
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
        }

        protected override void OnLayeredPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            RectangleF clientRectangle = base.ClientRectangle;
            if (this.bitmap_0 != null)
            {
                graphics.DrawImageUnscaled(this.bitmap_0, 0, 0);
            }
            else
            {
                this.bitmap_0 = new Bitmap(base.Width, base.Height, PixelFormat.Format32bppArgb);
                using (Graphics graphics2 = Graphics.FromImage(this.bitmap_0))
                {
                    this.method_6(graphics2, clientRectangle);
                }
                graphics.DrawImageUnscaled(this.bitmap_0, 0, 0);
            }
            this.method_7(graphics);
            base.OnLayeredPaint(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            base.Focus();
            if (e.Button == MouseButtons.Left)
            {
                this.method_8(e.Location);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point location = e.Location;
            if (this.bool_0 && (e.Button == MouseButtons.Left))
            {
                if (location.X < 0)
                {
                    location.X = 0;
                }
                else if (location.X > base.Width)
                {
                    location.X = base.Width;
                }
                if (location.Y < 0)
                {
                    location.Y = 0;
                }
                else if (location.Y > base.Height)
                {
                    location.Y = base.Height;
                }
                this.method_8(location);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.method_9();
        }

        protected virtual void OnSelectedColorChanged(EventArgs e)
        {
            EventHandler handler = base.Events[this.object_0] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        [Category("DSkin"), DefaultValue(true), Description("选择圈是否按下后跟随移动。")]
        public bool CanDragChangeColor
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        protected RectangleF ColorSelectorRect
        {
            get
            {
                float x = ((float) (this.hsl_0.Hue * base.Width)) / 360f;
                float y = (float) ((1.0 - this.hsl_0.Luminance) * base.Height);
                RectangleF ef = new RectangleF(x, y, 0f, 0f);
                ef.Inflate(5f, 5f);
                return ef;
            }
        }

        [Description("获取或设置选择的颜色。"), DefaultValue(typeof(Color), "White"), Category("DSkin")]
        public Color SelectedColor
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
                    this.hsl_0 = ColorConverterEx.smethod_0(value);
                    this.method_9();
                    base.Invalidate();
                    this.OnSelectedColorChanged(EventArgs.Empty);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public HSL SelectedHsl
        {
            get
            {
                return this.hsl_0;
            }
            set
            {
                if (this.hsl_0 != value)
                {
                    this.hsl_0 = value;
                    this.color_0 = ColorConverterEx.smethod_1(value);
                    this.method_9();
                    base.Invalidate();
                    this.OnSelectedColorChanged(EventArgs.Empty);
                }
            }
        }

        [Description("获取或设置颜色选择模式。"), Category("DSkin"), DefaultValue(typeof(ColorSelectMode), "0")]
        public ColorSelectMode SelectMode
        {
            get
            {
                return this.colorSelectMode_0;
            }
            set
            {
                this.colorSelectMode_0 = value;
            }
        }
    }
}

