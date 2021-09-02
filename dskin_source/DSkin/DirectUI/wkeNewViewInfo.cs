namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct wkeNewViewInfo
    {
        public DSkin.DirectUI.wkeNavigationType navigationType;
        public IntPtr url;
        public IntPtr target;
        public int x;
        public int y;
        public int width;
        public int height;
        [MarshalAs(UnmanagedType.I1)]
        public bool menuBarVisible;
        [MarshalAs(UnmanagedType.I1)]
        public bool statusBarVisible;
        [MarshalAs(UnmanagedType.I1)]
        public bool toolBarVisible;
        [MarshalAs(UnmanagedType.I1)]
        public bool locationBarVisible;
        [MarshalAs(UnmanagedType.I1)]
        public bool scrollbarsVisible;
        [MarshalAs(UnmanagedType.I1)]
        public bool resizable;
        [MarshalAs(UnmanagedType.I1)]
        public bool fullscreen;
    }
}

