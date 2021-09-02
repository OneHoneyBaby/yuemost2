namespace DSkin.Html.Adapters.Entities
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RPoint
    {
        public static readonly RPoint Empty;
        private double double_0;
        private double double_1;
        static RPoint()
        {
            Empty = new RPoint();
        }

        public RPoint(double x, double y)
        {
            this.double_0 = x;
            this.double_1 = y;
        }

        public bool IsEmpty
        {
            get
            {
                return ((Math.Abs((double) (this.double_0 - 0.0)) < 0.001) && (Math.Abs((double) (this.double_1 - 0.0)) < 0.001));
            }
        }
        public double X
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
        public double Y
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
        public static RPoint operator +(RPoint pt, RSize sz)
        {
            return Add(pt, sz);
        }

        public static RPoint operator -(RPoint pt, RSize sz)
        {
            return Subtract(pt, sz);
        }

        public static bool operator ==(RPoint left, RPoint right)
        {
            return ((left.X == right.X) && (left.Y == right.Y));
        }

        public static bool operator !=(RPoint left, RPoint right)
        {
            return !(left == right);
        }

        public static RPoint Add(RPoint pt, RSize sz)
        {
            return new RPoint(pt.X + sz.Width, pt.Y + sz.Height);
        }

        public static RPoint Subtract(RPoint pt, RSize sz)
        {
            return new RPoint(pt.X - sz.Width, pt.Y - sz.Height);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RPoint))
            {
                return false;
            }
            RPoint point = (RPoint) obj;
            return (((point.X == this.X) && (point.Y == this.Y)) && point.GetType().Equals(base.GetType()));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{{X={0}, Y={1}}}", new object[] { this.double_0, this.double_1 });
        }
    }
}

