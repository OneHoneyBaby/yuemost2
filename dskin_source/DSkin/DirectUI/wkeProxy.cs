namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct wkeProxy
    {
        public DSkin.DirectUI.wkeProxyType type;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=100)]
        public string hostname;
        public ushort port;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=50)]
        public string username;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=50)]
        public string password;
    }
}

