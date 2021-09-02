namespace DSkin.Controls
{
    using DSkin;
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Reflection;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ToolTip))]
    public class DSkinToolTip : ToolTip
    {
        private Color color_0;
        private Color color_1;
        private Color color_2;
        private Color color_3;
        private double double_0;
        private System.Drawing.Font font_0;
        private System.Drawing.Font font_1;
        private System.Drawing.Image image_0;
        private ImageDc imageDc_0;
        private System.Drawing.Text.TextRenderingHint KipPuhxwBm;
        private Size size_0;

        public DSkinToolTip()
        {
            this.double_0 = 1.0;
            this.font_0 = new System.Drawing.Font("宋体", 9f, FontStyle.Bold);
            this.size_0 = SystemInformation.SmallIconSize;
            this.color_0 = Color.Gray;
            this.KipPuhxwBm = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.color_1 = Color.White;
            this.color_2 = Color.Black;
            this.color_3 = Color.Black;
            this.font_1 = new System.Drawing.Font("微软雅黑", 9f);
            this.method_0();
        }

        public DSkinToolTip(IContainer cont) : base(cont)
        {
            this.double_0 = 1.0;
            this.font_0 = new System.Drawing.Font("宋体", 9f, FontStyle.Bold);
            this.size_0 = SystemInformation.SmallIconSize;
            this.color_0 = Color.Gray;
            this.KipPuhxwBm = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.color_1 = Color.White;
            this.color_2 = Color.Black;
            this.color_3 = Color.Black;
            this.font_1 = new System.Drawing.Font("微软雅黑", 9f);
            this.method_0();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (this.imageDc_0 != null)
                {
                    this.imageDc_0.Dispose();
                    this.imageDc_0 = null;
                }
                if (!this.font_0.IsSystemFont)
                {
                    this.font_0.Dispose();
                }
                this.font_0 = null;
                this.image_0 = null;
            }
        }

        private void DSkinToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            int num6;
            Brush brush2;
            Graphics graphics = e.Graphics;
            graphics.TextRenderingHint = this.KipPuhxwBm;
            Rectangle bounds = e.Bounds;
            int alpha = (int) (this.double_0 * 255.0);
            int num2 = 5;
            int height = 20;
            int num4 = 5;
            int num5 = 3;
            if ((this.Handle != IntPtr.Zero) && (this.double_0 < 1.0))
            {
                IntPtr hdc = graphics.GetHdc();
                DSkin.NativeMethods.BitBlt(hdc, 0, 0, bounds.Width, bounds.Height, this.imageDc_0.Hdc, 0, 0, 0xcc0020);
                graphics.ReleaseHdc(hdc);
            }
            Color color3 = Color.FromArgb(alpha, this.BackColor);
            Color color4 = Color.FromArgb(alpha, this.BackColor2);
            Color color = Color.FromArgb(alpha, this.Border);
            using (LinearGradientBrush brush = new LinearGradientBrush(bounds, color3, color4, LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(brush, bounds);
            }
            ControlPaint.DrawBorder(graphics, bounds, color, ButtonBorderStyle.Solid);
            Rectangle empty = Rectangle.Empty;
            if (base.ToolTipIcon != System.Windows.Forms.ToolTipIcon.None)
            {
                num4 = num2;
                num5 = height;
                empty = new Rectangle((bounds.X + num2) - ((this.ImageSize.Width - 0x10) / 2), (bounds.Y + ((height - this.size_0.Height) / 2)) + 2, this.size_0.Width, this.size_0.Height);
                System.Drawing.Image image = this.image_0;
                bool flag = false;
                if (image == null)
                {
                    Icon icon = this.method_2();
                    if (icon != null)
                    {
                        image = icon.ToBitmap();
                        flag = true;
                    }
                }
                if (image != null)
                {
                    using (new InterpolationModeGraphics(graphics))
                    {
                        if (this.double_0 < 1.0)
                        {
                            Class18.smethod_4(graphics, image, empty, (float) this.double_0);
                        }
                        else
                        {
                            graphics.DrawImage(image, empty, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
                        }
                    }
                    if (flag)
                    {
                        image.Dispose();
                    }
                }
            }
            StringFormat genericTypographic = new StringFormat {
                LineAlignment = StringAlignment.Center
            };
            if (!string.IsNullOrEmpty(base.ToolTipTitle))
            {
                num4 = num2;
                num5 = height;
                num6 = empty.IsEmpty ? num2 : (empty.Right + 3);
                Rectangle layoutRectangle = new Rectangle(num6, bounds.Y + 2, bounds.Width - num6, height);
                using (brush2 = new SolidBrush(Color.FromArgb(alpha, this.TitleFore)))
                {
                    graphics.DrawString(base.ToolTipTitle, this.TitleFont, brush2, layoutRectangle, genericTypographic);
                }
            }
            if (!string.IsNullOrEmpty(e.ToolTipText))
            {
                num6 = empty.IsEmpty ? (bounds.X + num4) : (empty.Right + 3);
                Rectangle rectangle3 = new Rectangle(num6, bounds.Y + num5, (bounds.Width - (num4 * 2)) + 3, bounds.Height - num5);
                genericTypographic = StringFormat.GenericTypographic;
                using (brush2 = new SolidBrush(Color.FromArgb(alpha, this.TipFore)))
                {
                    graphics.DrawString(e.ToolTipText, this.font_1, brush2, rectangle3, genericTypographic);
                }
            }
        }

        private void DSkinToolTip_Popup(object sender, PopupEventArgs e)
        {
            if (string.IsNullOrEmpty(base.ToolTipTitle) && (this.ToolTipIcon == System.Windows.Forms.ToolTipIcon.None))
            {
                using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
                {
                    SizeF ef = graphics.MeasureString(base.GetToolTip(e.AssociatedControl), this.font_1);
                    e.ToolTipSize = new Size(((int) ef.Width) + 5, ((int) ef.Height) + 5);
                }
            }
            if (this.double_0 < 1.0)
            {
                this.method_1();
            }
        }

        private void method_0()
        {
            base.OwnerDraw = true;
            base.ReshowDelay = 800;
            base.InitialDelay = 500;
            base.Draw += new DrawToolTipEventHandler(this.DSkinToolTip_Draw);
            base.Popup += new PopupEventHandler(this.DSkinToolTip_Popup);
        }

        private void method_1()
        {
            IntPtr handle = this.Handle;
            if (!(handle == IntPtr.Zero))
            {
                DSkin.RECT lpRect = new DSkin.RECT();
                DSkin.NativeMethods.GetWindowRect(handle, ref lpRect);
                Size size = new Size(lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
                this.imageDc_0 = new ImageDc(size.Width, size.Height);
                IntPtr desktopWindow = DSkin.NativeMethods.GetDesktopWindow();
                IntPtr dC = DSkin.NativeMethods.GetDC(desktopWindow);
                DSkin.NativeMethods.BitBlt(this.imageDc_0.Hdc, 0, 0, size.Width, size.Height, dC, lpRect.Left, lpRect.Top, 0xcc0020);
                DSkin.NativeMethods.ReleaseDC(desktopWindow, dC);
            }
        }

        private Icon method_2()
        {
            switch (base.ToolTipIcon)
            {
                case System.Windows.Forms.ToolTipIcon.Info:
                    return SystemIcons.Information;

                case System.Windows.Forms.ToolTipIcon.Warning:
                    return SystemIcons.Warning;

                case System.Windows.Forms.ToolTipIcon.Error:
                    return SystemIcons.Error;
            }
            return null;
        }

        [Category("Skin"), Description("渐变背景色1")]
        public Color BackColor
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

        [Description("渐变背景色2"), DefaultValue(typeof(Color), "White"), Category("Skin")]
        public Color BackColor2
        {
            get
            {
                return this.color_1;
            }
            set
            {
                if (this.color_1 != value)
                {
                    this.color_1 = value;
                }
            }
        }

        [Description("边框颜色"), Category("Skin"), DefaultValue(typeof(Color), "Gray")]
        public Color Border
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
                }
            }
        }

        [DefaultValue(typeof(System.Drawing.Font), "微软雅黑,9pt"), Description("获取或设置提示文字的字体")]
        public System.Drawing.Font Font
        {
            get
            {
                return this.font_1;
            }
            set
            {
                this.font_1 = value;
            }
        }

        [Browsable(false)]
        public Color ForeColor
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

        protected IntPtr Handle
        {
            get
            {
                if (!base.DesignMode)
                {
                    System.Type type = typeof(ToolTip);
                    return (IntPtr) type.GetProperty("Handle", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this, null);
                }
                return IntPtr.Zero;
            }
        }

        [Category("Skin"), Description("ICon图标"), DefaultValue((string) null)]
        public System.Drawing.Image Image
        {
            get
            {
                return this.image_0;
            }
            set
            {
                this.image_0 = value;
                if (this.image_0 == null)
                {
                    base.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
                }
                else
                {
                    base.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                }
            }
        }

        [DefaultValue(typeof(Size), "16, 16")]
        public Size ImageSize
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
                    if (this.size_0.Width > 0x20)
                    {
                        this.size_0.Width = 0x20;
                    }
                    if (this.size_0.Height > 0x20)
                    {
                        this.size_0.Height = 0x20;
                    }
                }
            }
        }

        [TypeConverter(typeof(OpacityConverter)), DefaultValue((double) 1.0), Description("透明度"), Category("Skin")]
        public double Opacity
        {
            get
            {
                return this.double_0;
            }
            set
            {
                if ((value < 0.0) && (value > 1.0))
                {
                    throw new ArgumentOutOfRangeException("Opacity");
                }
                this.double_0 = value;
            }
        }

        [Category("Skin"), Description("文字渲染模式")]
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get
            {
                return this.KipPuhxwBm;
            }
            set
            {
                this.KipPuhxwBm = value;
            }
        }

        [Description("提示字体色"), Category("Skin"), DefaultValue(typeof(Color), "Black")]
        public Color TipFore
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
                }
            }
        }

        [DefaultValue(typeof(System.Drawing.Font), "宋体, 9pt, style=Bold")]
        public System.Drawing.Font TitleFont
        {
            get
            {
                return this.font_0;
            }
            set
            {
                if (this.font_0 == null)
                {
                    throw new ArgumentNullException("TitleFont");
                }
                if (!this.font_0.IsSystemFont)
                {
                    this.font_0.Dispose();
                }
                this.font_0 = value;
            }
        }

        [DefaultValue(typeof(Color), "Black"), Category("Skin"), Description("标题字体色")]
        public Color TitleFore
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
                }
            }
        }

        [Category("Skin"), Description("ICon图标模式。")]
        public System.Windows.Forms.ToolTipIcon ToolTipIcon
        {
            get
            {
                return base.ToolTipIcon;
            }
            set
            {
                if (this.image_0 != null)
                {
                    base.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                }
                else
                {
                    base.ToolTipIcon = value;
                }
            }
        }
    }
}

