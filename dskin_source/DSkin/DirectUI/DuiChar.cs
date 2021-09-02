namespace DSkin.DirectUI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class DuiChar : ILayoutElement
    {
        private bool bool_0;
        private bool bool_1;
        private char char_0;
        private Color color_0;
        private System.Drawing.Font font_0;
        private static Graphics graphics_0;
        private Padding padding_0;
        private Point point_0;
        private System.Drawing.Size size_0;
        private static StringFormat stringFormat_0 = StringFormat.GenericTypographic;

        public DuiChar(char myChar)
        {
            this.font_0 = null;
            this.color_0 = Color.Empty;
            this.point_0 = Point.Empty;
            this.size_0 = System.Drawing.Size.Empty;
            this.bool_0 = true;
            this.padding_0 = Padding.Empty;
            this.bool_1 = false;
            this.Char = myChar;
        }

        public DuiChar(char myChar, System.Drawing.Font font, Color foreColor)
        {
            this.font_0 = null;
            this.color_0 = Color.Empty;
            this.point_0 = Point.Empty;
            this.size_0 = System.Drawing.Size.Empty;
            this.bool_0 = true;
            this.padding_0 = Padding.Empty;
            this.bool_1 = false;
            this.Char = myChar;
            this.Font = font;
            this.ForeColor = foreColor;
        }

        public static System.Drawing.Size MeasureChar(char myChar, System.Drawing.Font font)
        {
            if (graphics_0 == null)
            {
                graphics_0 = Graphics.FromHwnd(IntPtr.Zero);
            }
            SizeF ef = graphics_0.MeasureString(myChar.ToString(), font, new PointF(), stringFormat_0);
            if (myChar == '\t')
            {
                return new System.Drawing.Size((int) (font.Size * 4f), Convert.ToInt32(ef.Height));
            }
            return new System.Drawing.Size((myChar != ' ') ? Convert.ToInt32(ef.Width) : ((int) (font.Size / 2f)), Convert.ToInt32(ef.Height));
        }

        internal bool method_0()
        {
            return this.bool_1;
        }

        internal void method_1(bool value)
        {
            this.bool_1 = value;
        }

        public override string ToString()
        {
            return ("DuiChar '" + this.Char + "'");
        }

        public char Char
        {
            get
            {
                return this.char_0;
            }
            set
            {
                if (this.char_0 != value)
                {
                    this.char_0 = value;
                }
            }
        }

        public System.Drawing.Font Font
        {
            get
            {
                return this.font_0;
            }
            set
            {
                if (this.font_0 != value)
                {
                    this.font_0 = value;
                    this.size_0 = System.Drawing.Size.Empty;
                }
            }
        }

        public Color ForeColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
            }
        }

        public int Height
        {
            get
            {
                return this.Size.Height;
            }
        }

        public int Left
        {
            get
            {
                return this.point_0.X;
            }
        }

        public Point Location
        {
            get
            {
                return this.point_0;
            }
            set
            {
                this.point_0 = value;
            }
        }

        public Padding Margin
        {
            get
            {
                return this.padding_0;
            }
            set
            {
                this.padding_0 = value;
            }
        }

        public System.Drawing.Size Size
        {
            get
            {
                if (this.size_0 == System.Drawing.Size.Empty)
                {
                    this.size_0 = MeasureChar(this.char_0, this.font_0);
                }
                return this.size_0;
            }
            set
            {
                this.size_0 = value;
            }
        }

        public int Top
        {
            get
            {
                return this.point_0.Y;
            }
        }

        public bool Visible
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

        public int Width
        {
            get
            {
                return this.Size.Width;
            }
        }
    }
}

