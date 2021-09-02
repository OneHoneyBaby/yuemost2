namespace DSkin
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct PCURSORINFO
    {
        public int cbSize;
        public int flag;
        public IntPtr hCursor;
        public POINT ptScreenPos;
    }
}

