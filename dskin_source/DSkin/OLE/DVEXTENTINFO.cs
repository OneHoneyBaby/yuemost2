namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct DVEXTENTINFO
    {
        [ComAliasName("DSkin.OLE.ULONG")]
        public uint cb;
        [ComAliasName("DSkin.OLE.DWORD")]
        public uint dwExtentMode;
        [ComAliasName("DSkin.OLE.SIZEL")]
        public SIZEL sizelProposed;
    }
}

