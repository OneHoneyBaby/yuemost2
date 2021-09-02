namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct wkeConsoleMessage
    {
        public DSkin.DirectUI.wkeMessageSource source;
        public DSkin.DirectUI.wkeMessageType type;
        public DSkin.DirectUI.wkeMessageLevel level;
        public IntPtr message;
        public IntPtr url;
        public uint lineNumber;
    }
}

