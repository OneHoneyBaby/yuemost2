namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class DSkinCode : DSkinBaseControl
    {
        private bool bool_0 = true;
        private Color[] color_0 = new Color[] { Color.FromArgb(0xf7, 0xfe, 0xec), Color.FromArgb(0xea, 0xf8, 0xff), Color.FromArgb(0xf4, 250, 0xf6), Color.FromArgb(0xf8, 0xf8, 0xf8) };
        private IContainer icontainer_0 = null;
        private Image image_0;
        private int int_0 = 4;
        private readonly int int_1 = 130;
        private readonly int int_2 = 0x35;
        private readonly int[] int_3 = new int[] { 20, 0x19, 30 };
        private readonly int int_4 = 60;
        private Random random_0 = new Random();
        private string string_0;
        private string[] string_1 = new string[] { 
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", 
            "H", "J", "K", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
         };
        private readonly string[] string_2 = new string[] { "Arial", "Arial Black", "Arial Italic", "Courier New", "Courier New Bold Italic", "Courier New Italic", "Franklin Gothic Medium", "Franklin Gothic Medium Italic" };
        private StringFormat stringFormat_0 = new StringFormat(StringFormatFlags.NoClip);
        protected bool VCODE_IsEncrypt = true;
        protected bool VCODE_IsIgnore = false;
        protected int VCODE_LENGTH = 4;
        protected string VCODE_SESSION = "vcode";
        protected Types VCODE_TYPE = Types.Number;

        public DSkinCode()
        {
            this.method_9();
            this.Init();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Init()
        {
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }

        private void method_6()
        {
            this.CodeImg = this.method_7(this.CodeStr);
            base.Invalidate();
        }

        private Image method_7(string string_3)
        {
            Bitmap bitmap;
            Graphics graphics;
            if (!string.IsNullOrEmpty(string_3))
            {
                this.stringFormat_0.Alignment = StringAlignment.Center;
                this.stringFormat_0.LineAlignment = StringAlignment.Center;
                long ticks = DateTime.Now.Ticks;
                Random random = new Random(((int) (ticks & 0xffffffffL)) | ((int) (ticks >> 0x20)));
                using (bitmap = new Bitmap(this.int_1, this.int_2))
                {
                    using (graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                        Point point = new Point(20, 20);
                        int num2 = random.Next(this.int_2);
                        int num3 = random.Next(this.int_1);
                        int num4 = random.Next(15) + 5;
                        int num5 = random.Next(20) + 15;
                        int num6 = random.Next(5) + 1;
                        float num7 = 0f;
                        float num8 = Convert.ToSingle((double) ((num4 * Math.Sin(((num6 * num7) * 3.1415926535897931) / 180.0)) + num5));
                        graphics.Clear((this.Color_BackGround.Length == 0) ? this.BackColor : this.Color_BackGround[random.Next(this.Color_BackGround.Length)]);
                        using (Brush brush = new SolidBrush(this.ForeColor))
                        {
                            int num9;
                            for (num9 = 0; num9 < 0x83; num9++)
                            {
                                float num10 = num7 + 1f;
                                float num11 = Convert.ToSingle((double) ((num4 * Math.Sin(((num6 * num10) * 3.1415926535897931) / 180.0)) + num5));
                                if ((num3 >= num9) || (num9 > (num3 + num2)))
                                {
                                    using (Pen pen = new Pen(brush, random.Next(1, 3) + 1.1f))
                                    {
                                        graphics.DrawLine(pen, num7, num8, num10, num11);
                                    }
                                }
                                num7 = num10;
                                num8 = num11;
                            }
                            graphics.TranslateTransform(18f, 4f);
                            for (num9 = 0; num9 < string_3.Length; num9++)
                            {
                                int num12 = random.Next(-this.int_4, this.int_4);
                                graphics.TranslateTransform((float) point.X, (float) point.Y);
                                graphics.RotateTransform((float) num12);
                                using (Font font = new Font(this.string_2[random.Next(0, 8)], (float) this.int_3[random.Next(0, 3)]))
                                {
                                    graphics.DrawString(string_3[num9].ToString(), font, brush, 1f, 1f, this.stringFormat_0);
                                }
                                graphics.RotateTransform((float) -num12);
                                graphics.TranslateTransform(-2f, (float) -point.Y);
                            }
                        }
                    }
                    return (Image) bitmap.Clone();
                }
            }
            using (bitmap = new Bitmap(this.int_1, this.int_2))
            {
                using (graphics = Graphics.FromImage(bitmap))
                {
                    graphics.DrawString("验证码", this.Font, new SolidBrush(this.ForeColor), (PointF) new Point(0, 0));
                }
                return (Image) bitmap.Clone();
            }
        }

        private string method_8(int int_5)
        {
            string str = "";
            int num = -1;
            for (int i = 1; i < (int_5 + 1); i++)
            {
                int index = this.random_0.Next(this.VcArray.Length);
                while (num == index)
                {
                    index = this.random_0.Next(this.VcArray.Length);
                }
                num = index;
                str = str + this.VcArray[index];
            }
            return str;
        }

        private void method_9()
        {
            this.icontainer_0 = new Container();
        }

        public string NewCode()
        {
            this.string_0 = this.method_8(this.CodeCount);
            this.CodeImg = this.method_7(this.CodeStr);
            base.Invalidate();
            return this.CodeStr;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            if (this.Color_BackGround.Length == 0)
            {
                this.method_6();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.ClickNewCode)
            {
                this.NewCode();
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.NewCode();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            this.method_6();
        }

        protected override void OnLayeredPaint(PaintEventArgs e)
        {
            base.OnLayeredPaint(e);
            if (this.CodeImg != null)
            {
                e.Graphics.DrawImage(this.CodeImg, base.ClientRectangle);
            }
        }

        [DefaultValue(true), Description("是否可以点击刷新验证码"), Category("Skin")]
        public bool ClickNewCode
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

        [Category("Skin"), DefaultValue(4), Description("验证码字数")]
        public int CodeCount
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
                    this.NewCode();
                }
            }
        }

        [Description("验证码的图像"), DefaultValue(false), Category("Skin")]
        public Image CodeImg
        {
            get
            {
                return this.image_0;
            }
            set
            {
                this.image_0 = value;
            }
        }

        [Description("验证码的值"), Category("Skin")]
        public string CodeStr
        {
            get
            {
                return this.string_0;
            }
        }

        [Category("Skin"), Description("背景颜色集")]
        public Color[] Color_BackGround
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
                    this.method_6();
                }
            }
        }

        [Category("Skin"), Description("验证码字符集")]
        public string[] VcArray
        {
            get
            {
                return this.string_1;
            }
            set
            {
                if (this.string_1 != value)
                {
                    this.string_1 = value;
                    this.NewCode();
                }
            }
        }

        protected enum Types
        {
            Number,
            Character
        }
    }
}

