namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct POINTF
    {
        [ComAliasName("DSkin.OLE.FLOAT")]
        public float x;
        [ComAliasName("DSkin.OLE.FLOAT")]
        public float y;
    }
}

