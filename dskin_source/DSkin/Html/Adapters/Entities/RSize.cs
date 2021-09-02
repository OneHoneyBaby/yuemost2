namespace DSkin.Html.Adapters.Entities
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RSize
    {
        public static readonly RSize Empty;
        private double double_0;
        private double double_1;
        public RSize(RSize size)
        {
            this.double_1 = size.double_1;
            this.double_0 = size.double_0;
        }

        public RSize(RPoint pt)
        {
            this.double_1 = pt.X;
            this.double_0 = pt.Y;
        }

        public RSize(double width, double height)
        {
            this.double_1 = width;
            this.double_0 = height;
        }

        public bool IsEmpty
        {
            get
            {
                return ((Math.Abs(this.double_1) < 0.0001) && (Math.Abs(this.double_0) < 0.0001));
            }
        }
        public double Width
        {
            get
            {
                return this.double_1;
            }
            set
            {
                this.double_1 = value;
            }
        }
        public double Height
        {
            get
            {
                return this.double_0;
            }
            set
            {
                this.double_0 = value;
            }
        }
        public static explicit operator RPoint(RSize size)
        {
            return new RPoint(size.Width, size.Height);
        }

        public static RSize operator +(RSize sz1, RSize sz2)
        {
            return Add(sz1, sz2);
        }

        public static RSize operator -(RSize sz1, RSize sz2)
        {
            return Subtract(sz1, sz2);
        }

        public static bool operator ==(RSize sz1, RSize sz2)
        {
            return ((Math.Abs((double) (sz1.Width - sz2.Width)) < 0.001) && (Math.Abs((double) (sz1.Height - sz2.Height)) < 0.001));
        }

        public static bool operator !=(RSize sz1, RSize sz2)
        {
            return !(sz1 == sz2);
        }

        public static RSize Add(RSize sz1, RSize sz2)
        {
            return new RSize(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        public static RSize Subtract(RSize sz1, RSize sz2)
        {
            return new RSize(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RSize))
            {
                return false;
            }
            RSize size = (RSize) obj;
            return (((Math.Abs((double) (size.Width - this.Width)) < 0.001) && (Math.Abs((double) (size.Height - this.Height)) < 0.001)) && (size.GetType() == base.GetType()));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public RPoint ToPointF()
        {
            return (RPoint) this;
        }

        public override string ToString()
        {
            return string.Concat(new object[] { "{Width=", this.double_1, ", Height=", this.double_0, "}" });
        }

        static RSize()
        {
            Empty = new RSize();
        }
    }
}

