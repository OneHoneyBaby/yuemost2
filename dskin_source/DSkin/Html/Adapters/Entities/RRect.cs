namespace DSkin.Html.Adapters.Entities
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RRect
    {
        public static readonly RRect Empty;
        private double double_0;
        private double double_1;
        private double double_2;
        private double double_3;
        public RRect(double x, double y, double width, double height)
        {
            this.double_2 = x;
            this.double_3 = y;
            this.double_1 = width;
            this.double_0 = height;
        }

        public RRect(RPoint location, RSize size)
        {
            this.double_2 = location.X;
            this.double_3 = location.Y;
            this.double_1 = size.Width;
            this.double_0 = size.Height;
        }

        public RPoint Location
        {
            get
            {
                return new RPoint(this.X, this.Y);
            }
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }
        public RSize Size
        {
            get
            {
                return new RSize(this.Width, this.Height);
            }
            set
            {
                this.Width = value.Width;
                this.Height = value.Height;
            }
        }
        public double X
        {
            get
            {
                return this.double_2;
            }
            set
            {
                this.double_2 = value;
            }
        }
        public double Y
        {
            get
            {
                return this.double_3;
            }
            set
            {
                this.double_3 = value;
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
        public double Left
        {
            get
            {
                return this.X;
            }
        }
        public double Top
        {
            get
            {
                return this.Y;
            }
        }
        public double Right
        {
            get
            {
                return (this.X + this.Width);
            }
        }
        public double Bottom
        {
            get
            {
                return (this.Y + this.Height);
            }
        }
        public bool IsEmpty
        {
            get
            {
                if (this.Width > 0.0)
                {
                    return (this.Height <= 0.0);
                }
                return true;
            }
        }
        public static bool operator ==(RRect left, RRect right)
        {
            return ((((Math.Abs((double) (left.X - right.X)) < 0.001) && (Math.Abs((double) (left.Y - right.Y)) < 0.001)) && (Math.Abs((double) (left.Width - right.Width)) < 0.001)) && (Math.Abs((double) (left.Height - right.Height)) < 0.001));
        }

        public static bool operator !=(RRect left, RRect right)
        {
            return !(left == right);
        }

        public static RRect FromLTRB(double left, double top, double right, double bottom)
        {
            return new RRect(left, top, right - left, bottom - top);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RRect))
            {
                return false;
            }
            RRect rect = (RRect) obj;
            return ((((Math.Abs((double) (rect.X - this.X)) < 0.001) && (Math.Abs((double) (rect.Y - this.Y)) < 0.001)) && (Math.Abs((double) (rect.Width - this.Width)) < 0.001)) && (Math.Abs((double) (rect.Height - this.Height)) < 0.001));
        }

        public bool Contains(double x, double y)
        {
            return ((((this.X <= x) && (x < (this.X + this.Width))) && (this.Y <= y)) && (y < (this.Y + this.Height)));
        }

        public bool Contains(RPoint pt)
        {
            return this.Contains(pt.X, pt.Y);
        }

        public bool Contains(RRect rect)
        {
            return ((((this.X <= rect.X) && ((rect.X + rect.Width) <= (this.X + this.Width))) && (this.Y <= rect.Y)) && ((rect.Y + rect.Height) <= (this.Y + this.Height)));
        }

        public void Inflate(double x, double y)
        {
            this.X -= x;
            this.Y -= y;
            this.Width += 2.0 * x;
            this.Height += 2.0 * y;
        }

        public void Inflate(RSize size)
        {
            this.Inflate(size.Width, size.Height);
        }

        public static RRect Inflate(RRect rect, double x, double y)
        {
            RRect rect2 = rect;
            rect2.Inflate(x, y);
            return rect2;
        }

        public void Intersect(RRect rect)
        {
            RRect rect2 = Intersect(rect, this);
            this.X = rect2.X;
            this.Y = rect2.Y;
            this.Width = rect2.Width;
            this.Height = rect2.Height;
        }

        public static RRect Intersect(RRect a, RRect b)
        {
            double x = Math.Max(a.X, b.X);
            double num2 = Math.Min((double) (a.X + a.Width), (double) (b.X + b.Width));
            double y = Math.Max(a.Y, b.Y);
            double num4 = Math.Min((double) (a.Y + a.Height), (double) (b.Y + b.Height));
            if ((num2 >= x) && (num4 >= y))
            {
                return new RRect(x, y, num2 - x, num4 - y);
            }
            return Empty;
        }

        public bool IntersectsWith(RRect rect)
        {
            return ((((rect.X < (this.X + this.Width)) && (this.X < (rect.X + rect.Width))) && (rect.Y < (this.Y + this.Height))) && (this.Y < (rect.Y + rect.Height)));
        }

        public static RRect Union(RRect a, RRect b)
        {
            double x = Math.Min(a.X, b.X);
            double num2 = Math.Max((double) (a.X + a.Width), (double) (b.X + b.Width));
            double y = Math.Min(a.Y, b.Y);
            double num4 = Math.Max((double) (a.Y + a.Height), (double) (b.Y + b.Height));
            return new RRect(x, y, num2 - x, num4 - y);
        }

        public void Offset(RPoint pos)
        {
            this.Offset(pos.X, pos.Y);
        }

        public void Offset(double x, double y)
        {
            this.X += x;
            this.Y += y;
        }

        public override int GetHashCode()
        {
            return (int) (((((uint) this.X) ^ ((((uint) this.Y) << 13) | (((uint) this.Y) >> 0x13))) ^ ((((uint) this.Width) << 0x1a) | (((uint) this.Width) >> 6))) ^ ((((uint) this.Height) << 7) | (((uint) this.Height) >> 0x19)));
        }

        public override string ToString()
        {
            return string.Concat(new object[] { "{X=", this.X, ",Y=", this.Y, ",Width=", this.Width, ",Height=", this.Height, "}" });
        }

        static RRect()
        {
            Empty = new RRect();
        }
    }
}

