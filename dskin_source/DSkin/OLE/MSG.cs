namespace DSkin.OLE
{
    using DSkin;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4), ComConversionLoss]
    public struct MSG
    {
        [ComConversionLoss]
        public IntPtr hwnd;
        [ComAliasName("DSkin.OLE.UINT")]
        public uint message;
        [ComAliasName("DSkin.OLE.UINT_PTR")]
        public IntPtr wParam;
        [ComAliasName("DSkin.OLE.LONG_PTR")]
        public IntPtr lParam;
        [ComAliasName("DSkin.OLE.DWORD")]
        public uint time;
        [ComAliasName("DSkin.OLE.POINT")]
        public POINT pt;
    }
}

