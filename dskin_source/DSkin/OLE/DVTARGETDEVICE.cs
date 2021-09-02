namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4), ComConversionLoss]
    public struct DVTARGETDEVICE
    {
        [ComAliasName("DSkin.OLE.DWORD")]
        public uint tdSize;
        [ComAliasName("DSkin.OLE.WORD")]
        public ushort tdDriverNameOffset;
        [ComAliasName("DSkin.OLE.WORD")]
        public ushort tdDeviceNameOffset;
        [ComAliasName("DSkin.OLE.WORD")]
        public ushort tdPortNameOffset;
        [ComAliasName("DSkin.OLE.WORD")]
        public ushort tdExtDevmodeOffset;
        [ComConversionLoss]
        public IntPtr tdData;
    }
}

