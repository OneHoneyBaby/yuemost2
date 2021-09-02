namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct POINTL
    {
        [ComAliasName("DSkin.OLE.LONG")]
        public int x;
        [ComAliasName("DSkin.OLE.LONG")]
        public int y;
    }
}

