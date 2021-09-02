namespace DSkin.OLE
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4), ComConversionLoss]
    public struct COAUTHINFO
    {
        [ComAliasName("DSkin.OLE.DWORD")]
        public uint dwAuthnSvc;
        [ComAliasName("DSkin.OLE.DWORD")]
        public uint dwAuthzSvc;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwszServerPrincName;
        [ComAliasName("DSkin.OLE.DWORD")]
        public uint dwAuthnLevel;
        [ComAliasName("DSkin.OLE.DWORD")]
        public uint dwImpersonationLevel;
        [ComConversionLoss, ComAliasName("DSkin.OLE.COAUTHIDENTITY")]
        public IntPtr pAuthIdentityData;
        [ComAliasName("DSkin.OLE.DWORD")]
        public uint dwCapabilities;
    }
}

