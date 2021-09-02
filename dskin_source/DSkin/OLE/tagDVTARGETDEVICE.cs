namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public sealed class tagDVTARGETDEVICE
    {
        [MarshalAs(UnmanagedType.U4)]
        public int tdSize;
        [MarshalAs(UnmanagedType.U2)]
        public short tdDriverNameOffset;
        [MarshalAs(UnmanagedType.U2)]
        public short tdDeviceNameOffset;
        [MarshalAs(UnmanagedType.U2)]
        public short tdPortNameOffset;
        [MarshalAs(UnmanagedType.U2)]
        public short tdExtDevmodeOffset;
    }
}

