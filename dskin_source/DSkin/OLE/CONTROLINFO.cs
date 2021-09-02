namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4), ComConversionLoss]
    public struct CONTROLINFO
    {
        [ComAliasName("DSkin.OLE.ULONG")]
        public uint cb;
        [ComConversionLoss]
        public IntPtr haccel;
        [ComAliasName("DSkin.OLE.USHORT")]
        public ushort cAccel;
        [ComAliasName("DSkin.OLE.DWORD")]
        public uint dwFlags;
    }
}

