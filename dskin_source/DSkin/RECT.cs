namespace DSkin
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public RECT(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public RECT(Rectangle rect)
        {
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Right = rect.Right;
            this.Bottom = rect.Bottom;
        }

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top);
            }
        }
        public System.Drawing.Size Size
        {
            get
            {
                return new System.Drawing.Size(this.Right - this.Left, this.Bottom - this.Top);
            }
        }
        public static DSkin.RECT FromXYWH(int x, int y, int width, int height)
        {
            return new DSkin.RECT(x, y, x + width, y + height);
        }

        public static DSkin.RECT FromRectangle(Rectangle rect)
        {
            return new DSkin.RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }
    }
}

