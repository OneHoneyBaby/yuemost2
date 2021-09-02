namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4), ComConversionLoss]
    public struct OLEINPLACEFRAMEINFO
    {
        [ComAliasName("DSkin.OLE.UINT")]
        public uint cb;
        [ComAliasName("DSkin.OLE.BOOL")]
        public int fMDIApp;
        [ComConversionLoss]
        public IntPtr hwndFrame;
        [ComConversionLoss]
        public IntPtr haccel;
        [ComAliasName("DSkin.OLE.UINT")]
        public uint cAccelEntries;
    }
}

