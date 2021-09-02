namespace DSkin
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        public int cx;
        public int cy;
        public SIZE(int x, int y)
        {
            this.cx = x;
            this.cy = y;
        }

        public SIZE(Size size)
        {
            this.cx = size.Width;
            this.cy = size.Height;
        }
    }
}

