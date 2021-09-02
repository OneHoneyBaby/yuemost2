namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct wkeSettings
    {
        public DSkin.DirectUI.wkeProxy proxy;
        public uint mask;
    }
}

