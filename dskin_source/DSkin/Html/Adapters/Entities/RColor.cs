namespace DSkin.Html.Adapters.Entities
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    [StructLayout(LayoutKind.Sequential)]
    public struct RColor
    {
        public static readonly RColor Empty;
        private readonly long long_0;
        private RColor(long value)
        {
            this.long_0 = value;
        }

        public static RColor Transparent
        {
            get
            {
                return new RColor(0L);
            }
        }
        public static RColor Black
        {
            get
            {
                return FromArgb(0, 0, 0);
            }
        }
        public static RColor White
        {
            get
            {
                return FromArgb(0xff, 0xff, 0xff);
            }
        }
        public static RColor WhiteSmoke
        {
            get
            {
                return FromArgb(0xf5, 0xf5, 0xf5);
            }
        }
        public static RColor LightGray
        {
            get
            {
                return FromArgb(0xd3, 0xd3, 0xd3);
            }
        }
        public byte R
        {
            get
            {
                return (byte) ((this.long_0 >> 0x10) & 0xffL);
            }
        }
        public byte G
        {
            get
            {
                return (byte) ((this.long_0 >> 8) & 0xffL);
            }
        }
        public byte B
        {
            get
            {
                return (byte) (this.long_0 & 0xffL);
            }
        }
        public byte A
        {
            get
            {
                return (byte) ((this.long_0 >> 0x18) & 0xffL);
            }
        }
        public bool IsEmpty
        {
            get
            {
                return (this.long_0 == 0L);
            }
        }
        public static bool operator ==(RColor left, RColor right)
        {
            return (left.long_0 == right.long_0);
        }

        public static bool operator !=(RColor left, RColor right)
        {
            return !(left == right);
        }

        public static RColor FromArgb(int alpha, int red, int green, int blue)
        {
            smethod_0(alpha);
            smethod_0(red);
            smethod_0(green);
            smethod_0(blue);
            return new RColor(((long) ((ulong) ((((red << 0x10) | (green << 8)) | blue) | (alpha << 0x18)))) & 0xffffffffL);
        }

        public static RColor FromArgb(int red, int green, int blue)
        {
            return FromArgb(0xff, red, green, blue);
        }

        public override bool Equals(object obj)
        {
            if (obj is RColor)
            {
                RColor color = (RColor) obj;
                return (this.long_0 == color.long_0);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.long_0.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x20);
            builder.Append(base.GetType().Name);
            builder.Append(" [");
            if (this.long_0 != 0L)
            {
                builder.Append("A=");
                builder.Append(this.A);
                builder.Append(", R=");
                builder.Append(this.R);
                builder.Append(", G=");
                builder.Append(this.G);
                builder.Append(", B=");
                builder.Append(this.B);
            }
            else
            {
                builder.Append("Empty");
            }
            builder.Append("]");
            return builder.ToString();
        }

        private static void smethod_0(int int_0)
        {
            if ((int_0 < 0) || (int_0 > 0xff))
            {
                throw new ArgumentException("InvalidEx2BoundArgument");
            }
        }

        static RColor()
        {
            Empty = new RColor();
        }
    }
}

