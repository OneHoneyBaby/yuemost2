namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct OLEMENUGROUPWIDTHS
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        public int[] width;
    }
}

