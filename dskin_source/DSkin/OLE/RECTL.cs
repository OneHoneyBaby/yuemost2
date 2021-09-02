namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct RECTL
    {
        [ComAliasName("DSkin.OLE.LONG")]
        public int left;
        [ComAliasName("DSkin.OLE.LONG")]
        public int top;
        [ComAliasName("DSkin.OLE.LONG")]
        public int right;
        [ComAliasName("DSkin.OLE.LONG")]
        public int bottom;
    }
}

