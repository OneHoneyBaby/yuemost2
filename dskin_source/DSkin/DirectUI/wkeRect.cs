namespace DSkin.DirectUI
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct wkeRect
    {
        public int x;
        public int y;
        public int w;
        public int h;
        public Rectangle ToRectangle()
        {
            return new Rectangle(this.x, this.y, this.w, this.h);
        }
    }
}

