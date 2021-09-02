namespace DSkin.Imaging
{
    using System;
    using System.Drawing;

    public class RGB
    {
        public const short BIndex = 0;
        private byte byte_0;
        private byte byte_1;
        public const short GIndex = 1;
        public const short RIndex = 2;
        private byte xxymgNkSww;

        public RGB()
        {
        }

        public RGB(System.Drawing.Color color)
        {
            this.byte_0 = color.R;
            this.byte_1 = color.G;
            this.xxymgNkSww = color.B;
        }

        public RGB(byte r, byte g, byte b)
        {
            this.byte_0 = r;
            this.byte_1 = g;
            this.xxymgNkSww = b;
        }

        public override string ToString()
        {
            return string.Format("RGB [R={0}, G={1}, B={2}]", this.byte_0, this.byte_1, this.xxymgNkSww);
        }

        public byte B
        {
            get
            {
                return this.xxymgNkSww;
            }
            set
            {
                this.xxymgNkSww = value;
            }
        }

        public System.Drawing.Color Color
        {
            get
            {
                return System.Drawing.Color.FromArgb(this.byte_0, this.byte_1, this.xxymgNkSww);
            }
            set
            {
                this.byte_0 = value.R;
                this.byte_1 = value.G;
                this.xxymgNkSww = value.B;
            }
        }

        public byte G
        {
            get
            {
                return this.byte_1;
            }
            set
            {
                this.byte_1 = value;
            }
        }

        public byte R
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
            }
        }
    }
}

