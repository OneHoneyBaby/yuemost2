namespace DSkin.Html.Adapters
{
    using System;
    using System.Drawing;

    public sealed class FontAdapter : RFont
    {
        private double double_0 = -1.0;
        private float float_0 = -1f;
        private float float_1 = -1f;
        private readonly System.Drawing.Font font_0;
        private IntPtr intptr_0;

        public FontAdapter(System.Drawing.Font font)
        {
            this.font_0 = font;
        }

        public override double GetWhitespaceWidth(RGraphics graphics)
        {
            if (this.double_0 < 0.0)
            {
                this.double_0 = graphics.MeasureString(" ", this).Width;
            }
            return this.double_0;
        }

        internal void method_0(int int_0, int int_1)
        {
            this.float_1 = int_0;
            this.float_0 = int_1;
        }

        public System.Drawing.Font Font
        {
            get
            {
                return this.font_0;
            }
        }

        public override double Height
        {
            get
            {
                return (double) this.float_1;
            }
        }

        public IntPtr HFont
        {
            get
            {
                if (this.intptr_0 == IntPtr.Zero)
                {
                    this.intptr_0 = this.font_0.ToHfont();
                }
                return this.intptr_0;
            }
        }

        public override double LeftPadding
        {
            get
            {
                return (double) (this.float_1 / 6f);
            }
        }

        public override double Size
        {
            get
            {
                return (double) this.font_0.Size;
            }
        }

        public override double UnderlineOffset
        {
            get
            {
                return (double) this.float_0;
            }
        }
    }
}

