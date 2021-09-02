namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct SIZEL
    {
        [ComAliasName("DSkin.OLE.LONG")]
        public int cx;
        [ComAliasName("DSkin.OLE.LONG")]
        public int cy;
    }
}

